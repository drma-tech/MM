using KristofferStrube.Blazor.MediaCaptureStreams;
using KristofferStrube.Blazor.WebIDL.Exceptions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MM.Shared.Models.Profile;
using MudBlazor;

namespace MM.WEB.Modules.Profile
{
    public partial class ValidationGalleryPage
    {
        private ValidationModel? Validation { get; set; }
        private MudDialog? MudDialog { get; set; }
        private byte[] Picture { get; set; } = [];
        private byte[] PriorPicture { get; set; } = [];

        private MediaDevices? mediaDevices;
        private MediaStreamTrack? videoStreamTrack;
        private ElementReference videoElement;
        private readonly List<(string label, string id)> Cameras = [];
        private string? currentCameraId;

        protected override async Task LoadAuthenticatedDataAsync(CancellationToken token)
        {
            if (AppStateStatic.Principal == null)
            {
                await ShowWarning("Invalid operation");
                Navigation.NavigateTo($"/{Culture}/profile");
                return;
            }

            Validation = await ValidationApi.Get([], token);
            PriorPicture = await ValidationApi.GetSafetyGalleryPhoto(token);
        }

        protected async Task TakeShot()
        {
            try
            {
                var data = await JsRuntime.InvokeAsync<string>("captureFrame", Cts.Token, videoElement);
                data = data[(data.IndexOf(',', StringComparison.Ordinal) + 1)..]; // Remove the suffix added by javascript
                Picture = Convert.FromBase64String(data);

                await StopVideoTrack();

                Validation ??= new ValidationModel(AppStateStatic.UserId);
            }
            catch (Exception ex)
            {
                await ProcessException(ex);
            }
        }

        protected async Task Reset()
        {
            try
            {
                Picture = [];
                await OpenVideo();
            }
            catch (Exception ex)
            {
                await ProcessException(ex);
            }
        }

        protected async Task SendPhoto(byte[]? picture = null)
        {
            try
            {
                await AppStateStatic.ProcessingStarted.PublishAsync();
                var email = AppStateStatic.User?.Claims.SingleOrDefault(c => string.Equals(c.Type, "email", StringComparison.Ordinal))?.Value;
                Validation = await ValidationApi.UploadPhotoValidation(new MM.Shared.Requests.PhotoValidationRequest { Stream = picture ?? Picture, Email = email }, Cts.Token);
                await AppStateStatic.ProcessingFinished.PublishAsync();

                await ShowSuccess("Photo validated successfully!");
                await JsRuntime.Window().HistoryBack();
            }
            catch (Exception ex)
            {
                await ProcessException(ex);
            }
        }

        private async Task OpenVideo()
        {
            try
            {
                mediaDevices ??= await MediaDevicesService.GetMediaDevicesAsync();

                await SelectDevice(newCameraId: null);
                var deviceInfos = await mediaDevices.EnumerateDevicesAsync();
                Cameras.Clear();
                foreach (var device in deviceInfos)
                {
                    if (await device.GetKindAsync() is MediaDeviceKind.VideoInput)
                    {
                        Cameras.Add((await device.GetLabelAsync(), await device.GetDeviceIdAsync()));
                    }
                }

                currentCameraId = Cameras.FirstOrDefault().id;

                isCameraOpen = true;
            }
            catch (WebIDLException ex)
            {
                await ProcessException(new NotificationException($"{ex.GetType().Name}: {ex.Message}"));
                await StopVideoTrack();
            }
            catch (Exception ex)
            {
                await ProcessException(ex);
                await StopVideoTrack();
            }
        }

        private bool isCameraOpen;

        private void OnCameraChanged(string newCameraId)
        {
            if (string.Equals(newCameraId, currentCameraId, StringComparison.OrdinalIgnoreCase)) return;

            _ = ChangeCameraAsync(newCameraId); // fire-and-forget
        }

        private async Task ChangeCameraAsync(string? newCameraId)
        {
            currentCameraId = newCameraId;
            await SelectDevice(newCameraId);
        }

        private async Task SelectDevice(string? newCameraId)
        {
            if (videoStreamTrack is not null)
            {
                await videoStreamTrack.StopAsync();
                videoStreamTrack = null;
            }

            var mediaTrackConstraints = new MediaTrackConstraints();
            if (newCameraId is not null)
            {
                mediaTrackConstraints.DeviceId = new ConstrainDOMStringParameters() { Exact = newCameraId };
            }

            var mediaStream = await mediaDevices!.GetUserMediaAsync(new MediaStreamConstraints() { Video = mediaTrackConstraints });
            var videoTracks = await mediaStream.GetVideoTracksAsync();
            videoStreamTrack = videoTracks.FirstOrDefault();
            foreach (var unusedTrack in videoTracks.Skip(1))
            {
                await unusedTrack.DisposeAsync();
            }

            if (videoStreamTrack is null)
            {
                await ShowError("No video track found for the selected device.");
                return;
            }

            // We don't have a wrapper for HtmlMediaElement's yet so we use simple JSInterop for this part.
            var htmlMediaElement = await JsRuntime.InvokeAsync<IJSObjectReference>("getReference", Cts.Token, videoElement);
            await JsRuntime.InvokeVoidAsync("setAttribute", Cts.Token, htmlMediaElement, "srcObject", mediaStream.JSReference);
        }

        private async Task StopVideoTrack()
        {
            if (videoStreamTrack is not null)
            {
                await videoStreamTrack.StopAsync();
                videoStreamTrack = null;
            }

            currentCameraId = null;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _ = StopVideoTrack();
        }
    }
}
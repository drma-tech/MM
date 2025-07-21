using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.API.Core;

public class StorageHelper(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    public async Task UploadPhoto(PhotoType type, Stream stream, string fileName, string userId, CancellationToken cancellationToken)
    {
        var container = new BlobContainerClient(Configuration.GetValue<string>("Azure:BlobConnectionString"), GetPhotoContainer(type));
        var client = container.GetBlobClient(fileName);

        var headers = new BlobHttpHeaders { ContentType = "image/jpeg" };

        await client.UploadAsync(stream, headers, new Dictionary<string, string> { { "id", userId } }, cancellationToken: cancellationToken);
    }

    public async Task DeletePhoto(PhotoType type, string? pictureId, CancellationToken cancellationToken)
    {
        if (pictureId.Empty()) throw new ArgumentNullException(nameof(pictureId));

        var container = new BlobContainerClient(Configuration.GetValue<string>("Azure:BlobConnectionString"), GetPhotoContainer(type));
        var blob = container.GetBlobClient(pictureId);

        if (await blob.ExistsAsync(cancellationToken))
            await blob.DeleteAsync(DeleteSnapshotsOption.IncludeSnapshots, cancellationToken: cancellationToken);
    }
}
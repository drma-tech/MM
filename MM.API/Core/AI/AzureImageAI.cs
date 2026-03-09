using Azure;
using Azure.AI.Vision.Face;

namespace MM.API.Core.AI;

public static class AzureImageAI
{
    private static readonly string SubscriptionKey = Environment.GetEnvironmentVariable("FACE_APIKEY") ?? "<apikey>";
    private static readonly string Endpoint = Environment.GetEnvironmentVariable("FACE_ENDPOINT") ?? "<endpoint>";

    public static async Task<List<FaceDetectionResult>> AnalyzeImage(BinaryData data, CancellationToken cancellationToken)
    {
        //var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(ApiStartup.Configurations.Azure!.CognitiveKey))
        //{
        //    Endpoint = ApiStartup.Configurations.Azure!.CognitiveEndpoint
        //};

        //var features = new List<VisualFeatureTypes?>
        //{
        //    VisualFeatureTypes.Faces,
        //    VisualFeatureTypes.Adult,
        //    VisualFeatureTypes.Objects
        //};

        FaceRecognitionModel RecognitionModel4 = FaceRecognitionModel.Recognition04;

        FaceClient client = Authenticate(Endpoint, SubscriptionKey);

        //return await client.AnalyzeImageInStreamAsync(stream, features, cancellationToken: cancellationToken);
        return await DetectFaceRecognize(client, data, RecognitionModel4);
    }

    public static FaceClient Authenticate(string endpoint, string key)
    {
        return new FaceClient(new Uri(endpoint), new AzureKeyCredential(key));
    }

    private static async Task<List<FaceDetectionResult>> DetectFaceRecognize(FaceClient faceClient, BinaryData data, FaceRecognitionModel recognitionModel)
    {
        var attributes = new List<FaceAttributeType>
        {
            FaceAttributeType.QualityForRecognition,
            FaceAttributeType.Glasses,
            FaceAttributeType.Mask
        };
        var response = await faceClient.DetectAsync(data, FaceDetectionModel.Detection03, recognitionModel, true, attributes);
        IReadOnlyList<FaceDetectionResult> detectedFaces = response.Value;
        List<FaceDetectionResult> sufficientQualityFaces = [];
        foreach (FaceDetectionResult detectedFace in detectedFaces)
        {
            QualityForRecognition? faceQualityForRecognition = detectedFace.FaceAttributes.QualityForRecognition;
            if (faceQualityForRecognition.HasValue && (faceQualityForRecognition.Value != QualityForRecognition.Low))
            {
                sufficientQualityFaces.Add(detectedFace);
            }
        }

        return sufficientQualityFaces;
    }
}
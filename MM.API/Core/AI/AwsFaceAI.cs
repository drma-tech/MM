using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace MM.API.Core.AI
{
    public static class AwsFaceAI
    {
        public static async Task<DetectFacesResponse> DetectFaces(MemoryStream stream, CancellationToken cancellationToken)
        {
            var rekognitionClient = new AmazonRekognitionClient(ApiStartup.Configurations.AWS!.AccessKey, ApiStartup.Configurations.AWS!.SecretKey, RegionEndpoint.USWest1);

            var image = new Image { Bytes = stream };

            var request = new DetectFacesRequest
            {
                Image = image,
                Attributes = ["ALL"]
            };

            return await rekognitionClient.DetectFacesAsync(request, cancellationToken);
        }

        public static async Task<DetectLabelsResponse> DetectLabels(MemoryStream stream, CancellationToken cancellationToken)
        {
            var rekognitionClient = new AmazonRekognitionClient(ApiStartup.Configurations.AWS!.AccessKey, ApiStartup.Configurations.AWS!.SecretKey, RegionEndpoint.USWest1);

            var image = new Image { Bytes = stream };

            var request = new DetectLabelsRequest
            {
                Image = image,
                MaxLabels = 20,
                MinConfidence = 70F
            };

            return await rekognitionClient.DetectLabelsAsync(request, cancellationToken);
        }

        public static async Task<DetectModerationLabelsResponse> DetectAdultContent(MemoryStream stream, CancellationToken cancellationToken)
        {
            var rekognitionClient = new AmazonRekognitionClient(ApiStartup.Configurations.AWS!.AccessKey, ApiStartup.Configurations.AWS!.SecretKey, RegionEndpoint.USWest1);

            var image = new Image { Bytes = stream };

            var request = new DetectModerationLabelsRequest
            {
                Image = image,
                MinConfidence = 80F
            };

            return await rekognitionClient.DetectModerationLabelsAsync(request, cancellationToken);
        }

        public static async Task<CompareFacesResponse> CompareFaces(MemoryStream source, MemoryStream target, CancellationToken cancellationToken)
        {
            var rekognitionClient = new AmazonRekognitionClient(ApiStartup.Configurations.AWS!.AccessKey, ApiStartup.Configurations.AWS!.SecretKey, RegionEndpoint.USWest1);

            var sourceImage = new Image { Bytes = source };
            var targetImage = new Image { Bytes = target };

            var compareFacesRequest = new CompareFacesRequest
            {
                SourceImage = sourceImage,
                TargetImage = targetImage,
                SimilarityThreshold = 80F //80% similarity threshold
            };

            return await rekognitionClient.CompareFacesAsync(compareFacesRequest, cancellationToken);
        }
    }
}
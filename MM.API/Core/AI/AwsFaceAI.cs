using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace MM.API.Core.AI
{
    public static class AwsFaceAI
    {
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
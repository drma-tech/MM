using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Extensions.Configuration;

namespace MM.API.Core
{
    public class ComputerVisionHelper(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;

        /// <summary>
        /// still using version 3.2 (old version)
        ///
        /// https://learn.microsoft.com/en-us/azure/ai-services/computer-vision/quickstarts-sdk/image-analysis-client-library?pivots=programming-language-csharp&tabs=windows%2Cvisual-studio
        /// 
        /// update when adult content is available
        /// 
        /// https://learn.microsoft.com/en-us/azure/ai-services/computer-vision/overview-image-analysis?tabs=4-0
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ImageAnalysis> AnalyzeImage(Stream stream, CancellationToken cancellationToken)
        {
            var endpoint = Configuration.GetValue<string>("Azure:CognitiveEndpoint");
            var key = Configuration.GetValue<string>("Azure:CognitiveKey");

            var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(key)) { Endpoint = endpoint };

            var features = new List<VisualFeatureTypes?>()
            {
                VisualFeatureTypes.Adult, VisualFeatureTypes.Faces
            };

            return await client.AnalyzeImageInStreamAsync(stream, visualFeatures: features, cancellationToken: cancellationToken);
        }
    }
}
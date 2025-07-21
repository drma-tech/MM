using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace MM.API.Core.AI;

public static class AzureImageAI
{
    /// <summary>
    ///     still using version 3.2 (old version - year 2021)
    ///     https://learn.microsoft.com/en-us/azure/ai-services/computer-vision/quickstarts-sdk/image-analysis-client-library?pivots=programming-language-csharp&tabs=windows%2Cvisual-studio
    ///     todo: update (4.0 or more recent) when adult content is available
    ///     https://learn.microsoft.com/en-us/azure/ai-services/computer-vision/overview-image-analysis?tabs=4-0
    /// </summary>
    /// <param name="url"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<ImageAnalysis> AnalyzeImage(Stream stream, CancellationToken cancellationToken)
    {
        var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(ApiStartup.Configurations.Azure!.CognitiveKey))
        {
            Endpoint = ApiStartup.Configurations.Azure!.CognitiveEndpoint
        };

        var features = new List<VisualFeatureTypes?>
        {
            VisualFeatureTypes.Faces,
            VisualFeatureTypes.Adult,
            VisualFeatureTypes.Objects
        };

        return await client.AnalyzeImageInStreamAsync(stream, features, cancellationToken: cancellationToken);
    }
}
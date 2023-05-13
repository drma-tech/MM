namespace MM.API.Functions
{
    public class CacheFunction
    {
        private readonly CosmosCacheRepository _cacheRepo;

        public CacheFunction(CosmosCacheRepository cacheRepo)
        {
            _cacheRepo = cacheRepo;
        }

        ////[Function("CacheNew")]
        //////[FixedDelayRetry(5, "00:00:10")] //TODO: still not available in isolated function
        ////public async Task<CacheDocument<NewsModel>?> CacheNew(
        ////   [HttpTrigger(AuthorizationLevel.Anonymous, Method.GET, Route = "Public/Cache/News")] HttpRequestData req, CancellationToken cancellationToken)
        ////{
        ////    try
        ////    {
        ////        var mode = req.GetQueryParameters()["mode"];
        ////        var model = await _cacheRepo.Get<NewsModel>($"lastnews_{mode}", cancellationToken);

        ////        if (model == null)
        ////        {
        ////            using var http = new HttpClient();
        ////            var obj = await http.GetNewsByFlixter<Flixster>(cancellationToken);
        ////            if (obj == null) return null;

        ////            //compact

        ////            var compactModels = new NewsModel();

        ////            foreach (var item in obj.data?.newsStories.Take(8) ?? Enumerable.Empty<NewsStory>())
        ////            {
        ////                if (item == null) continue;
        ////                compactModels.Items.Add(new Shared.Models.News.Item(item.id, item.title, item.mainImage?.url, item.link));
        ////            }

        ////            var compactResult = await _cacheRepo.Add(new FlixsterCache(compactModels, "lastnews_compact"), cancellationToken);

        ////            //full

        ////            var fullModels = new NewsModel();

        ////            foreach (var item in obj.data?.newsStories ?? Enumerable.Empty<NewsStory>())
        ////            {
        ////                if (item == null) continue;
        ////                fullModels.Items.Add(new Shared.Models.News.Item(item.id, item.title, item.mainImage?.url, item.link));
        ////            }

        ////            var fullResult = await _cacheRepo.Add(new FlixsterCache(fullModels, "lastnews_full"), cancellationToken);

        ////            if (mode == "compact")
        ////                return compactResult;
        ////            else
        ////                return fullResult;
        ////        }
        ////        else
        ////        {
        ////            return model;
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        req.ProcessException(ex);
        ////        throw new UnhandledException(ex.BuildException());
        ////    }
        ////}
    }
}
using LikeButtonProject.Contracts;
using LikeButtonProject.Service.Contracts;

namespace LikeButtonProject.Service;
public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IArticleService> _articleService;
    private readonly Lazy<IArticleLikeService> _articleLikeService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
    {
        _articleService = new Lazy<IArticleService>(() => new ArticleService(repositoryManager, logger));
        _articleLikeService = new Lazy<IArticleLikeService>(() => new ArticleLikeService(repositoryManager, logger));
    }

    public IArticleService ArticleService => _articleService.Value;
    public IArticleLikeService ArticleLikeService => _articleLikeService.Value;
}
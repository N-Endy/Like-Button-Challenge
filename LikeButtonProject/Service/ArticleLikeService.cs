using LikeButtonProject.Contracts;
using LikeButtonProject.Service.Contracts;

namespace LikeButtonProject.Service;

internal sealed class ArticleLikeService : IArticleLikeService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public ArticleLikeService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
}
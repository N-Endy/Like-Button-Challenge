using LikeButtonProject.Contracts;
using LikeButtonProject.Entities.Dtos;
using LikeButtonProject.Entities.Exceptions;
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

    public IEnumerable<ArticleLikeDto> GetArticleLikes(int articleId, bool trackChanges)
    {
        _ = _repository.Article.GetArticle(articleId, trackChanges) ?? throw new ArticleNotFoundException(articleId);

        var articleLikes = _repository.ArticleLike.GetArticleLikes(articleId, trackChanges);

        return articleLikes.Select(a => new ArticleLikeDto(a.Id, a.ArticleId, a.UserId, a.LikedAt)).ToList();
    }
}
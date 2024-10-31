using LikeButtonProject.Contracts;
using LikeButtonProject.Entities.Dtos;
using LikeButtonProject.Entities.Exceptions;
using LikeButtonProject.Entities.Models;
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

    public ArticleLikeDto AddArticleLike(int articleId, int userId,  ArticleLikeForCreation articleLikeForCreation, bool trackChanges)
    {
        _ = _repository.Article.GetArticle(articleId, trackChanges) ?? throw new ArticleNotFoundException(articleId);

        var existingLike = _repository.ArticleLike.GetArticleLikes(articleId, trackChanges)
            .FirstOrDefault(l => l.ArticleId == articleId && l.UserId == userId);

        if (existingLike != null)
            throw new DuplicateLikeException(userId);

        var articleLike = new ArticleLike
        {
            ArticleId = articleId,
            UserId = articleLikeForCreation.UserId,
            LikedAt = DateTime.UtcNow
        };

        _repository.ArticleLike.AddArticleLike(articleId, articleLike);
        _repository.Save();

        return new ArticleLikeDto(articleLike.Id, articleLike.ArticleId, articleLike.UserId, articleLike.LikedAt);
    }
}
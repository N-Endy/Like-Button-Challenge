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

    public async Task<IEnumerable<ArticleLikeDto>> GetArticleLikesAsync(int articleId, bool trackChanges)
    {
        _ = await _repository.Article.GetArticleAsync(articleId, trackChanges) ?? throw new ArticleNotFoundException(articleId);

        var articleLikes = await _repository.ArticleLike.GetArticleLikesAsync(articleId, trackChanges);

        return articleLikes.Select(a => new ArticleLikeDto(a.Id, a.ArticleId, a.UserId, a.LikedAt)).ToList();
    }

    public async Task<ArticleLikeDto> AddArticleLikeAsync(int articleId, ArticleLikeForCreation articleLikeForCreation, bool trackChanges)
    {
        _ = await _repository.Article.GetArticleAsync(articleId, trackChanges) ?? throw new ArticleNotFoundException(articleId);

        var articleLikes = await _repository.ArticleLike.GetArticleLikesAsync(articleId, trackChanges);
        var existingLike = articleLikes.FirstOrDefault(l => l.ArticleId == articleId && l.UserId == articleLikeForCreation.UserId);

        if (existingLike != null)
            throw new DuplicateLikeException(articleLikeForCreation.UserId);

        var articleLike = new ArticleLike
        {
            ArticleId = articleId,
            UserId = articleLikeForCreation.UserId,
            LikedAt = DateTime.UtcNow
        };

        _repository.ArticleLike.AddArticleLike(articleId, articleLike);
        await _repository.SaveAsync();

        return new ArticleLikeDto(articleLike.Id, articleLike.ArticleId, articleLike.UserId, articleLike.LikedAt);
    }
}
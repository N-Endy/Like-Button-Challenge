using LikeButtonProject.Entities.Models;

namespace LikeButtonProject.Contracts;
public interface IArticleLikeRepository
{
    Task<IEnumerable<ArticleLike>> GetArticleLikesAsync(int articleId, bool trackChanges);
    void AddArticleLike(int articleId, ArticleLike articleLike);
}
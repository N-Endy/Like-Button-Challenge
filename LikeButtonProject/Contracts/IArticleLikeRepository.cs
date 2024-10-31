using LikeButtonProject.Entities.Models;

namespace LikeButtonProject.Contracts;
public interface IArticleLikeRepository
{
    IEnumerable<ArticleLike> GetArticleLikes(int articleId, bool trackChanges);
}
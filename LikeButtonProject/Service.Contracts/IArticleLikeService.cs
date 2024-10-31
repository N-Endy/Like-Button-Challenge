using LikeButtonProject.Entities.Dtos;

namespace LikeButtonProject.Service.Contracts;
public interface IArticleLikeService
{
    IEnumerable<ArticleLikeDto> GetArticleLikes(int id, bool trackChanges);
    ArticleLikeDto AddArticleLike(int articleId, int userId, ArticleLikeForCreation articleLikeForCreation, bool trackChanges);
}
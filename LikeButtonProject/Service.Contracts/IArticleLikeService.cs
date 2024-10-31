using LikeButtonProject.Entities.Dtos;

namespace LikeButtonProject.Service.Contracts;
public interface IArticleLikeService
{
    Task<IEnumerable<ArticleLikeDto>> GetArticleLikesAsync(int id, bool trackChanges);
    Task<ArticleLikeDto> AddArticleLikeAsync(int articleId, ArticleLikeForCreation articleLikeForCreation, bool trackChanges);
}
using LikeButtonProject.Contracts;
using LikeButtonProject.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LikeButtonProject.Repository;
public class ArticleLikeRepository : RepositoryBase<ArticleLike>, IArticleLikeRepository
{
    public ArticleLikeRepository(RepositoryContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<ArticleLike>> GetArticleLikesAsync(int articleId, bool trackChanges) =>
            await FindByCondition(a => a.ArticleId == articleId, trackChanges).ToListAsync();

    public void AddArticleLike(int articleId, ArticleLike articleLike) =>
        Add(articleLike);
}
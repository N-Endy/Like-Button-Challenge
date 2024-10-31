using LikeButtonProject.Contracts;
using LikeButtonProject.Entities.Models;

namespace LikeButtonProject.Repository;
public class ArticleLikeRepository : RepositoryBase<ArticleLike>, IArticleLikeRepository
{
    public ArticleLikeRepository(RepositoryContext context) : base(context)
    {
        
    }

    public IEnumerable<ArticleLike> GetArticleLikes(int articleId, bool trackChanges) =>
            FindByCondition(a => a.ArticleId == articleId, trackChanges).ToList();
}
namespace LikeButtonProject.Contracts;
public interface IRepositoryManager
{
    IArticleRepository Article { get; }
    IArticleLikeRepository ArticleLike { get; }
    void Save();
}
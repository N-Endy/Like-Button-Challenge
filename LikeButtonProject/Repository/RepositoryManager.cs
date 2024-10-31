using LikeButtonProject.Contracts;

namespace LikeButtonProject.Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IArticleRepository> _articleRepository;
        private readonly Lazy<IArticleLikeRepository> _articleLikeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _articleRepository = new Lazy<IArticleRepository>(() => new ArticleRepository(repositoryContext));
            _articleLikeRepository = new Lazy<IArticleLikeRepository>(() => new ArticleLikeRepository(repositoryContext));
        }

        public IArticleRepository Article => _articleRepository.Value;
        public IArticleLikeRepository ArticleLike => _articleLikeRepository.Value;
        public void Save() => _repositoryContext.SaveChanges();
    }
}
using LikeButtonProject.Entities.Models;
using LikeButtonProject.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LikeButtonProject.Repository;
public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ArticleConfiguration());
    }

    public DbSet<Article> Articles { get; set;}
    public DbSet<ArticleLike> ArticleLikes { get; set;}
}
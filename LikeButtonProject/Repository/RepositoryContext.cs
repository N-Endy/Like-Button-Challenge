using LikeButtonProject.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LikeButtonProject.Repository;
public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<User> Users { get; set;}
    public DbSet<Article> Articles { get; set;}
    public DbSet<ArticleLike> ArticleLikes { get; set;}
}
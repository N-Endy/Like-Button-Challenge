using LikeButtonProject.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LikeButtonProject.Repository.Configuration;
public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.HasData
        (
            new Article
            {
                Id = 1,
                Title = "Sample Article",
                Content = "This is a sample article for demonstration purposes."
            },
            new Article
            {
                Id = 2,
                Title = "Another Sample Article",
                Content = "This is another sample article for demonstration purposes."
            },
            new Article
            {
                Id = 3,
                Title = "Yet Another Sample Article",
                Content = "This is yet another sample article for demonstration purposes."
            }
        );
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LikeButtonProject.Entities.Models;
public class Article
{
    [Column("ArticleId")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Title is 60 characters.")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Title is a required field.")]
    public string? Content { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual ICollection<ArticleLike>? ArticleLikes { get; set; }
}
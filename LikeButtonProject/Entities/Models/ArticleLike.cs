using System.ComponentModel.DataAnnotations.Schema;

namespace LikeButtonProject.Entities.Models;
public class ArticleLike
{
    [Column("ArticleLikeId")]
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public int UserId { get; set; }
    public DateTime LikedAt { get; set; }
    public virtual Article? Article { get; set; }
}
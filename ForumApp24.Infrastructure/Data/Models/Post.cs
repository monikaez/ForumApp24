using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static ForumApp24.Infrastructure.Constants.ValidationConstants;

namespace ForumApp24.Infrastructure.Data.Models
{
    [Comment("Post Table")]
    public class Post
    {
        [Key]
        [Comment("Post Identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Post Title")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(ContentMaxLength)]
        [Comment("Post Content")]
        public string Content { get; set; } = string.Empty;
    }
}

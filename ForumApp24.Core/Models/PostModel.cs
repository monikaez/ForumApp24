using System.ComponentModel.DataAnnotations;
using static ForumApp24.Infrastructure.Constants.ValidationConstants;

namespace ForumApp24.Core.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage =RequiredErrorMessage)]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength, ErrorMessage = StringLengthErrorMessage)]

        public string Content { get; set; } = string.Empty;
    }
}

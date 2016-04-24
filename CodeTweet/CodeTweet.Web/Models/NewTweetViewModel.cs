using System.ComponentModel.DataAnnotations;

namespace CodeTweet.Web.Models
{
    public class NewTweetViewModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(140)]
        public string Text { get; set; }
    }
}
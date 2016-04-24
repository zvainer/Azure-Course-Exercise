using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeTweet.TweetsDal.Model
{
    [Table("Tweets")]
    public class TweetEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        [Index]
        public DateTime Timestamp { get; set; }
    }
}
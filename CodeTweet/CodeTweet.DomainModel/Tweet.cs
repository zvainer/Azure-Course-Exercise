using System;

namespace CodeTweet.DomainModel
{
    public class Tweet
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
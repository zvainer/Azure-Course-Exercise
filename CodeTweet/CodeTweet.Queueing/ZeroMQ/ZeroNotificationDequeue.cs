using System;
using System.Configuration;
using CodeTweet.DomainModel;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;

namespace CodeTweet.Queueing.ZeroMQ
{
    public sealed class ZeroNotificationDequeue : INotificationDequeue
    {
        private static readonly string QueueAddress = ConfigurationManager.AppSettings["ZeroMqAddress"];

        private readonly NetMQContext _context;
        private readonly PullSocket _client;

        public ZeroNotificationDequeue()
        {
            _context = NetMQContext.Create();
            _client = _context.CreatePullSocket();
            _client.Bind(QueueAddress);
        }

        public Tweet[] Dequeue()
        {
            string serializedTweet;
            if (!_client.TryReceiveFrameString(TimeSpan.FromSeconds(1), out serializedTweet))
                return new Tweet[0];

            var tweet = JsonConvert.DeserializeObject<Tweet>(serializedTweet);
            return new[] {tweet};
        }

        public void Dispose()
        {
            _client.Dispose();
            _context.Dispose();
        }
    }
}
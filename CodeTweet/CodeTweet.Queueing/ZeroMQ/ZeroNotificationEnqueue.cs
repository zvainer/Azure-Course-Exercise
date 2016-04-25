using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using CodeTweet.DomainModel;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;

namespace CodeTweet.Queueing.ZeroMQ
{
    public sealed class ZeroNotificationEnqueue : INotificationEnqueue, IDisposable
    {
        private static readonly string QueueAddress = ConfigurationManager.AppSettings["ZeroMqAddress"];

        private readonly NetMQContext _context;
        private readonly Poller _poller;
        private readonly PushSocket _client;
        private readonly NetMQScheduler _scheduler;


        public ZeroNotificationEnqueue()
        {
            _context = NetMQContext.Create();
            _poller = new Poller();
            _client = _context.CreatePushSocket();
            _client.Connect(QueueAddress);
            _scheduler = new NetMQScheduler(_context, _poller);
            Task.Factory.StartNew(_poller.PollTillCancelled, TaskCreationOptions.LongRunning);
        }

        public Task EnqueueNotificationAsync(Tweet tweet)
        {
            var serializedObject = JsonConvert.SerializeObject(tweet);
            return Task.Factory.StartNew(() => _client.TrySendFrame(TimeSpan.FromSeconds(1), serializedObject), CancellationToken.None, TaskCreationOptions.None, _scheduler);
        }

        public void Dispose()
        {
            _scheduler.Dispose();
            _client.Dispose();
            _poller.CancelAndJoin();
            _poller.Dispose();
            _context.Dispose();
        }
    }
}
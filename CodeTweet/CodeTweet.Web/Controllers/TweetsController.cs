using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using CodeTweet.DomainModel;
using CodeTweet.Queueing;
using CodeTweet.TweetsDal;
using CodeTweet.Web.Models;
using Microsoft.AspNet.Identity;

namespace CodeTweet.Web.Controllers
{
    [Authorize]
    public class TweetsController : Controller
    {
        private readonly ITweetsRepository _repository;
        private readonly INotificationEnqueue _queue;

        public TweetsController(ITweetsRepository repository, INotificationEnqueue queue)
        {
            _repository = repository;
            _queue = queue;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _repository.GetAllTweetsAsync());
        }

        public async Task<ActionResult> Me()
        {
            string userName = User.Identity.GetUserName();
            return View(await _repository.GetTweets(userName));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Text")] NewTweetViewModel newTweet)
        {
            if (ModelState.IsValid)
            {
                var tweet = new Tweet
                {
                    Id = Guid.NewGuid(),
                    Author = User.Identity.GetUserName(),
                    Text = newTweet.Text,
                    Timestamp = DateTime.UtcNow
                };
                await _repository.CreateTweetAsync(tweet);
                await _queue.EnqueueNotificationAsync(tweet);
                return RedirectToAction("Index");
            }

            return View(newTweet);
        }
    }
}
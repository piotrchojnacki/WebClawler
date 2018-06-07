using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using WebCrawler.Crawler.Interfaces;
using Tweetinvi;
using Tweetinvi.Models;
using WebCrawler.Settings.Interfaces;
using System.Reactive.Linq;

namespace WebCrawler.Crawler
{
    public class TwitterCrawler : ITwitterCrawler
    {
        private IAuthenticatedUser _user;
        private readonly string _tweetSearchParameter;
        public TwitterCrawler(ITwitterSettings twitterSettings)
        {
            _tweetSearchParameter = twitterSettings.TweetSearchParameter();

            Initialize(
                twitterSettings.ConsumerKey(), 
                twitterSettings.ConsumerSecret(),
                twitterSettings.UserAccessToken(),
                twitterSettings.UserAccessSecret());

            System.Console.WriteLine("Udało sie chyba");
            System.Console.WriteLine("User.Name: " + _user.Name);
            System.Console.ReadKey();
        }

        public void Initialize(string consumerKey, string consumerSecret, string userAccessToken, string userAccessSecret)
        {
            Auth.SetUserCredentials(consumerKey, consumerSecret, userAccessToken, userAccessSecret);
            _user = User.GetAuthenticatedUser();
            Work();
        }

        public void Work()
        {
            var tweets = Observable.Interval(TimeSpan.FromSeconds(120)).Subscribe(_ => { SearchForTweets(); });
        }

        public void SearchForTweets()
        {
            var searchParameter = Search.CreateTweetSearchParameter(_tweetSearchParameter);
            DateTime now = DateTime.Now;
            searchParameter.Since = now.AddMinutes(-2);

            var tweets = Search.SearchTweets(searchParameter);

            foreach (var tweet in tweets)
            {
                Console.WriteLine("***********************Next tweet: ");
                Console.WriteLine(tweet.Text);
            }

            Console.WriteLine("#############################");

        }


    }
}

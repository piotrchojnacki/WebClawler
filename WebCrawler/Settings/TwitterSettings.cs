using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Settings.Interfaces;

namespace WebCrawler.Settings
{
    public class TwitterSettings : ITwitterSettings
    {
        private string _consumerKey;
        private string _consumerSecret;
        private string _userAccessToken;
        private string _userAccessSecret;
        private string _tweetSearchParameter;

        public TwitterSettings()
        {
            _consumerKey = ConfigurationManager.AppSettings["consumerKey"];
            _consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
            _userAccessToken = ConfigurationManager.AppSettings["userAccessToken"];
            _userAccessSecret = ConfigurationManager.AppSettings["userAccessSecret"];
            _tweetSearchParameter = ConfigurationManager.AppSettings["tweetSearchParameter"];
        }

        public string ConsumerKey() { return _consumerKey; }
        public string ConsumerSecret() { return _consumerSecret; }
        public string UserAccessToken() { return _userAccessToken; }
        public string UserAccessSecret() { return _userAccessSecret; }
        public string TweetSearchParameter() { return _tweetSearchParameter; }
    }
}

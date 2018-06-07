using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Settings.Interfaces
{
    public interface ITwitterSettings
    {
        string ConsumerKey();
        string ConsumerSecret();
        string UserAccessToken();
        string UserAccessSecret();
        string TweetSearchParameter();
    }
}

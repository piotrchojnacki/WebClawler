using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;
using FluentAssertions;
using WebCrawler.Settings.Interfaces;
using WebCrawler.Services.Interfaces;
using WebCrawler.Mapping.Interfaces;
using WebCrawler.Contexts;
using WebCrawler.Crawler;
using System.Threading.Tasks;

namespace WebCrawlerTests
{
    public class OpenWeatherMapCrawlerTest
    {
        [Fact]
        public void OpenWeatherMapCrawler_SetInterval10_After10SecondsTriggerOnce()
        {
            //Arrange
            var openWeatherMapSettings = new Mock<IOpenWeatherMapSettings>();
            var openWeatherMapRestClient = new Mock<IOpenWeatherMapRestClient>();
            var weatherMapper = new Mock<IWeatherMapper>();
            var weatherContext = new Mock<WeatherContext>();

            openWeatherMapSettings.Setup(_ => _.OpenWeatherMapTimeSpan).Returns(TimeSpan.FromSeconds(10));

            //Act
            int eventFired = 0;

            var openWeatherMapCrawler = new OpenWeatherMapCrawler(openWeatherMapSettings.Object,
              openWeatherMapRestClient.Object,
              weatherMapper.Object,
              weatherContext.Object);

            openWeatherMapCrawler.WeatherSource.Subscribe(_ => eventFired++);

            Task.Delay(10000);

            //Assert
            eventFired.Equals(1);
        }

        [Fact]
        public void OpenWeatherMapCrawler_SetInterval10_After20SecondsTriggerTwice()
        {
            //Arrange
            var openWeatherMapSettings = new Mock<IOpenWeatherMapSettings>();
            var openWeatherMapRestClient = new Mock<IOpenWeatherMapRestClient>();
            var weatherMapper = new Mock<IWeatherMapper>();
            var weatherContext = new Mock<WeatherContext>();

            openWeatherMapSettings.Setup(_ => _.OpenWeatherMapTimeSpan).Returns(TimeSpan.FromSeconds(10));

            //Act
            int eventFired = 0;

            var openWeatherMapCrawler = new OpenWeatherMapCrawler(openWeatherMapSettings.Object,
              openWeatherMapRestClient.Object,
              weatherMapper.Object,
              weatherContext.Object);

            openWeatherMapCrawler.WeatherSource.Subscribe(_ => eventFired++);

            Task.Delay(20000);

            //Assert
            eventFired.Equals(2);
        }

        [Fact]
        public void OpenWeatherMapCrawler_SetInterval10_After0SecondsNonTrigger()
        {
            //Arrange
            var openWeatherMapSettings = new Mock<IOpenWeatherMapSettings>();
            var openWeatherMapRestClient = new Mock<IOpenWeatherMapRestClient>();
            var weatherMapper = new Mock<IWeatherMapper>();
            var weatherContext = new Mock<WeatherContext>();

            openWeatherMapSettings.Setup(_ => _.OpenWeatherMapTimeSpan).Returns(TimeSpan.FromSeconds(10));

            //Act
            int eventFired = 0;

            var openWeatherMapCrawler = new OpenWeatherMapCrawler(openWeatherMapSettings.Object,
              openWeatherMapRestClient.Object,
              weatherMapper.Object,
              weatherContext.Object);

            openWeatherMapCrawler.WeatherSource.Subscribe(_ => eventFired++);

            Task.Delay(0);

            //Assert
            eventFired.Equals(0);
        }
    }
}

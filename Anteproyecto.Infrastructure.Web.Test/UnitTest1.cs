using NUnit.Framework;
using OpenQA.Selenium;

namespace Anteproyecto.Infrastructure.Web.Test
{
    public class Tests
    {
        private IWebDriver driver;
        private string appUrl;
        [SetUp]
        public void Setup()
        {
            appUrl = "https://www.bing.com/?setlang=es";
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
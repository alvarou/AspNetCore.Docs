using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RazorPagesMovie.Test.UI
{
    [TestClass]
    public partial class RazorPagesMovieUITest
    {
        IWebDriver driver;
        readonly string url = @"https://localhost:44375/";

        public TestContext TestContext { get; set; }

        #region Browser navigation

        [TestMethod]
        public void NavigateTo()
        {
            //arrange
            var title = "Movie";

            //act
            driver.Navigate().GoToUrl(url);

            //assert
            Assert.IsTrue(driver.Title.Contains(title));
        }

        [TestMethod]
        public void GetCurrentURL()
        {
            //arrange
            var moviesUrl = url + "Movies";

            //act
            driver.Navigate().GoToUrl(moviesUrl);

            //assert
            Assert.AreEqual(driver.Url, moviesUrl);
        }

        [TestMethod]
        public void Back()
        {
            //arrange
            var anotherUrl = "https://www.google.com/";

            //act
            driver.Navigate().GoToUrl(anotherUrl);
            driver.Navigate().Back();

            //assert
            Assert.AreNotEqual(driver.Url, anotherUrl);
        }

        [TestMethod]
        public void Forward()
        {
            //arrange
            var anotherUrl = "https://www.google.com.mx/";

            //act
            driver.Navigate().GoToUrl(anotherUrl);
            driver.Navigate().Back();
            driver.Navigate().Forward();

            //assert
            Assert.AreEqual(driver.Url, anotherUrl);
        }

        [TestMethod]
        public void Refresh()
        {
            //arrange
            var title = "Movie";

            //act
            driver.Navigate().Refresh();

            //assert
            Assert.IsTrue(driver.Title.Contains(title));
        }

        [TestMethod]
        public void GetTitle()
        {
            //arrange
            var anotherUrl = "https://www.google.com/";
            var title = string.Empty; //Unnecessary assignment

            //act
            driver.Navigate().GoToUrl(anotherUrl);
            title = driver.Title;

            //assert
            Assert.IsTrue(title.Contains("Google"));
        }
        #endregion


        #region Test Setup
        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver(@"C:\WebDriver\bin");
            driver.Navigate().GoToUrl(url);

        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
        #endregion
    }
}

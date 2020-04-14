using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Runtime.ConstrainedExecution;

namespace RazorPagesMovie.Test.UI
{
    public partial class RazorPagesMovieUITest
    {
        [TestMethod]
        public void FindAndClickElementByClassName()
        {
            //arrange
            IWebElement rmovies = driver.FindElement(By.ClassName("navbar-brand"));
            IWebElement index;
            
            //act
            rmovies.Click();
            index = driver.FindElement(By.CssSelector("body > div > main > h1"));
            
            //assert
            Assert.AreEqual(index.Text, "Index");
        }

        [TestMethod]
        public void FindAndClickElementByXPath()
        {
            //arrange
            IWebElement rmovies = driver.FindElement(By.ClassName("navbar-brand"));
            IWebElement createNew;
            IWebElement create;

            //act
            rmovies.Click();
            createNew = driver.FindElement(By.XPath("/html/body/div/main/p/a"));
            createNew.Click();
            create = driver.FindElement(By.CssSelector("body > div > main > h1"));

            //assert
            Assert.AreEqual(create.Text, "Create");
        }

        [TestMethod]
        public void FindAndTypeOnElementById()
        {
            //arrange
            IWebElement rmovies = driver.FindElement(By.ClassName("navbar-brand"));
            IWebElement createNew;
            IWebElement movieTitle;
            var movieTitletoType = "Dune";

            //act
            rmovies.Click();
            createNew = driver.FindElement(By.XPath("/html/body/div/main/p/a"));
            createNew.Click();

            movieTitle = driver.FindElement(By.Id("Movie_Title"));
            movieTitle.SendKeys(movieTitletoType);

            //assert
            Assert.AreEqual(movieTitletoType, movieTitle.GetAttribute("value") );
        }

        [TestMethod]
        public void ValidateRequiredFields()
        {
            //arrange
            IWebElement rmovies = driver.FindElement(By.ClassName("navbar-brand"));
            IWebElement createNew;
            IWebElement create;
            IWebElement MovieTitleError;
            IWebElement MovieReleaseDateError;
            IWebElement MovieGenreError;
            IWebElement MoviePriceError;
            IWebElement MovieRatingError;

            //act
            rmovies.Click();
            createNew = driver.FindElement(By.XPath("/html/body/div/main/p/a"));
            createNew.Click();

            create = driver.FindElement(By.CssSelector("body > div > main > div.row > div > form > div:nth-child(6) > input"));
            create.Click();

            MovieTitleError = driver.FindElement(By.CssSelector("#Movie_Title-error"));
            MovieReleaseDateError = driver.FindElement(By.CssSelector("#Movie_ReleaseDate-error"));
            MovieGenreError = driver.FindElement(By.CssSelector("#Movie_Genre-error"));
            MoviePriceError = driver.FindElement(By.CssSelector("#Movie_Price-error"));
            MovieRatingError = driver.FindElement(By.CssSelector("#Movie_Rating-error"));

            //assert
            Assert.AreEqual(true, MovieTitleError.Displayed &&
                                    MovieReleaseDateError.Displayed && 
                                    MovieGenreError.Displayed &&
                                    MoviePriceError.Displayed &&
                                    MovieRatingError.Displayed);
        }
    }
}

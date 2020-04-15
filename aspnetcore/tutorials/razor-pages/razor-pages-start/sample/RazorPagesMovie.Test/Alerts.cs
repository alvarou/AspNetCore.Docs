using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace RazorPagesMovie.Test.UI
{
    public partial class RazorPagesMovieUITest
    {
        [TestMethod]
        public void Alert()
        {
            //arrange
            driver.Url+="Privacy";
            IWebElement button = driver.FindElement(By.Id("MyButton"));

            //act
            button.Click();

            //Wait for the alert to be displayed and store it in a variable
            IAlert alert = new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.AlertIsPresent());

            //Press the OK button
            alert.Accept();

            //assert
            Assert.AreEqual(true, true);
        }
    }
}

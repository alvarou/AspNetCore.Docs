using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.Linq;

namespace RazorPagesMovie.Test.UI
{
    public partial class RazorPagesMovieUITest
    {
        [TestMethod]
        public void SwitchingWindowsOrTabs()
        {
            //arrange
            //Store the ID of the original window
            var originalWindow = driver.CurrentWindowHandle;
            var link = driver.FindElement(By.Id("link"));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //act
            //Click the link which opens in a new window
            link.Click();

            //Wait for the new window or tab
            wait.Until(wd => wd.WindowHandles.Count == 2);

            //Loop through until we find a new window handle
            foreach (string window in driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
            //Wait for the new tab to finish loading content
            wait.Until(wd => wd.Title.Contains("ASP.NET documentation"));

            //assert
            //Check we have other windows open already
            Assert.AreEqual(driver.WindowHandles.Count, 2);            
        }

        [TestMethod]
        public void ClosingAWindowOrTab()
        {
            //arrange
            //Store the ID of the original window
            var originalWindow = driver.CurrentWindowHandle;

            //act
            driver.FindElement(By.Id("link")).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            //Close the tab or window
            driver.Close();

            //assert
            //Check we have other windows open already
            Assert.AreEqual(driver.WindowHandles.Count, 1);
        }

        [TestMethod]
        public void SetWindowSize()
        {
            //arrange
            Size size = new Size(1024, 768);

            //act
            driver.Manage().Window.Size = size;

            //assert
            Assert.AreEqual(size, driver.Manage().Window.Size);
        }

        [TestMethod]
        public void MaximiseWindow()
        {
            //arrange
            Size size = new Size(1024, 768);

            //act
            driver.Manage().Window.Size = size;
            driver.Manage().Window.Maximize();
            
            //assert
            Assert.AreNotEqual(size, driver.Manage().Window.Size);
        }
    }
}

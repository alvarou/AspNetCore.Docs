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
        public void ImplicitWait()
        {
            //arrange
            //var conditions = new ChromeNetworkConditions
            //{
            //    DownloadThroughput = 45 * 1000,
            //    UploadThroughput = 10 * 1000,
            //    Latency = TimeSpan.FromMilliseconds(1)
            //};

            //(driver as ChromeDriver).NetworkConditions = conditions;

            driver.Url = "http://axnqadnp.southcentralus.cloudapp.azure.com/";
            IWebElement user = driver.FindElement(By.Id("UserName"));
            IWebElement password = driver.FindElement(By.Id("Password"));
            IWebElement entra = driver.FindElement(By.XPath("//*[@id='login']/form/div[3]/div/button"));

            var userToType = "mmendez";
            var passwordtoType = "123456";

            IWebElement estatusPorEtapa;

            //act
            user.SendKeys(userToType);
            password.SendKeys(passwordtoType);

            entra.Click();

            //Error
            //estatusPorEtapa = driver.FindElement(By.Id("stdt1"));

            //Solution Implicit Wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//Try 5
            estatusPorEtapa = driver.FindElement(By.Id("stdt1"));

            Assert.AreEqual(true, estatusPorEtapa.Displayed);
        }

        [TestMethod]
       public void ExplicitWait()
        {
            //arrange
            //Try this
            //var conditions = new ChromeNetworkConditions
            //{
            //    DownloadThroughput = 45 * 1000,
            //    UploadThroughput = 10 * 1000,
            //    Latency = TimeSpan.FromMilliseconds(1)
            //};

            //(driver as ChromeDriver).NetworkConditions = conditions;


            driver.Url = "http://axnqadnp.southcentralus.cloudapp.azure.com/";
            IWebElement user = driver.FindElement(By.Id("UserName"));
            IWebElement password = driver.FindElement(By.Id("Password"));
            IWebElement entra = driver.FindElement(By.XPath("//*[@id='login']/form/div[3]/div/button"));

            var userToType = "mmendez";
            var passwordtoType = "123456";
            
            IWebElement estatusPorEtapa;

            //act
            user.SendKeys(userToType);
            password.SendKeys(passwordtoType);

            entra.Click();

            //Error
            //estatusPorEtapa = driver.FindElement(By.Id("stdt1"));

            //Solution ExpectedConditions
            //https://www.selenium.dev/selenium/docs/api/dotnet/html/T_OpenQA_Selenium_Support_UI_ExpectedConditions.htm
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.Id("stdt1")));

            estatusPorEtapa = driver.FindElement(By.Id("stdt1"));

            Assert.AreEqual(true, estatusPorEtapa.Displayed);
        }
    }
}

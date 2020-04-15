using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Data;

namespace RazorPagesMovie.Test.UI
{
    public partial class RazorPagesMovieUITest
    {
        [TestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(1, 1, 2)]
        [DataRow(2, 1, 3)]
        [DataRow(80, 2, 82)]
        [DataTestMethod]
        public void GivenTwoNumbersReturnsResultsOk(int number1, int number2, int result)
        {
            var actual = number1+number2;
            Assert.AreEqual(result, actual);
        }
       
    }
}

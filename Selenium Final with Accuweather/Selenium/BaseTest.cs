using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Final_with_Accuweather.Selenium
{
    internal class BaseTest
    {
        protected WebDriver driver;

        protected static readonly string url = "https://www.accuweather.com/";
        protected static readonly string preciseTextXpath = "//*[text()='{0}']";
        protected static readonly string partialTextXpath = "//*[contains(text(),'{0}')]";
        protected static readonly string relativePathFolder = @"..\Resources\";
        protected WebDriverWait wait = null;
        protected static readonly int maxWait = 10;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWait));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Final_with_Accuweather.Selenium
{
    internal class AccweatherTest: BaseTest
    {
        private static readonly By iUnderstandBtn = By.XPath(string.Format(preciseTextXpath,"I Understand"));
        private static readonly By searchInput = By.CssSelector("input.search-input[name='query']");
        private static readonly By resultContainer = By.XPath("//div[@class='results-container']");
        private static readonly By firstSearchResult = By.XPath("//div[@class='search-bar-result search-result source-radar']");
        private static readonly By locationHeader = By.XPath("//h1[contains(@class, 'header-loc')]");
        private static readonly string locationToSearch = "New York";


        [Test]
        public void AccweatherWebTest()
        {
            // accept cookies
            IWebElement acceptButton = driver.FindElement(iUnderstandBtn);
            acceptButton.Click();

            // Input "New York" in the Search field
            IWebElement searchInputField = driver.FindElement(searchInput);
            searchInputField.Click();
            searchInputField.SendKeys(locationToSearch);

            // Click on the first search result.
            IWebElement firstResultContainer = wait.Until(ExpectedConditions.ElementIsVisible(resultContainer));
            IWebElement firstSearchResultElement = firstResultContainer.FindElement(firstSearchResult);
            firstSearchResultElement.Click();



            //Check the whether City weather page header contains city name from the search.
            IWebElement cityWeatherHeader = wait.Until(ExpectedConditions.ElementIsVisible(locationHeader));
            Assert.IsTrue(cityWeatherHeader.Text.Contains(locationToSearch), $"City name in header does not match: Expected {locationToSearch}, Actual {cityWeatherHeader.Text}");

        }
        
    }
}

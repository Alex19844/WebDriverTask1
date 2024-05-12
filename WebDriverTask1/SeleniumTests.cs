using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverTask1
{
    
    public class Tests
    {
        private IWebDriver driver { get; set; }
        private const string url = "https://pastebin.com/";
        private const string expirationValue = "10 Minutes";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); // Set implicit wait for elements
        }

        [Test]
        public void WebDriverTest()
        {
            // Navigate to pastebin.com
            driver.Navigate().GoToUrl(url);

            // Find 'NewPaste' button and click
            IWebElement newpasteElement = driver.FindElement(By.CssSelector("a.header__btn"));
            newpasteElement.Click();

            // Find 'New Paste' form and enter the text
            driver.FindElement(By.Id("postform-text")).SendKeys("Hello from WebDriver");

            // Scroll down the window
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,500)", "");

            // Find drop-down list 'Paste Expiration' and click on it
            var dropdownElement = driver.FindElement(By.XPath("//*[contains(@class, 'field-postform-expiration')]//span"));
            dropdownElement.Click();

            // Find '10 Minutes' option and click on it
            var dropdownOptions = driver.FindElements(By.CssSelector("li[class *= 'select2-results__option']"));
            dropdownOptions.FirstOrDefault(x => x.Text.Equals(expirationValue)).Click();

            // Find 'PasteName/Title' textbox and enter the text
            driver.FindElement(By.Id("postform-name")).SendKeys("helloweb");
        
            Assert.Pass(); // Instruction for Breakpoint
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
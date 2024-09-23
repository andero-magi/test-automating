using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumProj
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }

        [Test]
        public async Task Test1()
        {
            await driver.Navigate().GoToUrlAsync("https://google.com");

            IWebElement textarea = driver.FindElement(By.Name("q"));
            IWebElement searchButton = driver.FindElement(By.Name("btnK"));

            textarea.SendKeys("WebDriver");
            searchButton.Click();

            Thread.Sleep(3000);
        }
    }
}
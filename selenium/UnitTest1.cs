using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium;

public class Tests
{
    private IWebDriver? driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver!.Navigate().GoToUrl("http://localhost:8000/index.html");
    }

    [TearDown]
    public void Shutdown() 
    {
        driver.Dispose();
    }

    [Test]
    public void Should_TopbarButtons_Exist()
    {
        int buttonCount = 6;

        for (int i = 1; i < buttonCount; i++)
        {
            string btnId = $"link{i}";
            var element = driver.FindElement(By.Id(btnId));
            Assert.NotNull(element);
        }        
    }

    [Test]
    public void Should_TitleChange_Work()
    {
        var textArea = driver!.FindElement(By.Id("change-title-box"));
        var submitButton = driver!.FindElement(By.Id("btn"));

        Assert.NotNull(textArea);
        Assert.NotNull(submitButton);

        const string newTitle = "A new Title";

        textArea.SendKeys(newTitle);
        submitButton.Click();

        var titleAreas = driver!.FindElements(By.Name("site-title-area"));

        Assert.AreEqual(titleAreas.Count, 2);

        foreach (var element in titleAreas) 
        {
            Assert.AreEqual(element.Text, newTitle);
        }
    }
}
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace NUnit_Test_Project;

[Binding]
public class ExampleSteps
{
    IWebDriver driver;

    [Given(@"I open example.com")]
    public void OpenExample()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://example.com");
    }

    [Then(@"the title contains ""(.*)""")]
    public void CheckTitle(string text)
    {
        Assert.That(driver.Title, Does.Contain(text));
        driver.Quit();
    }
}
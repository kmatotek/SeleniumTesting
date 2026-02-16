using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace NUnit_Test_Project;

[Binding]
public class HappyLangSteps
{
    private readonly DriverContext _context;

    public HappyLangSteps(DriverContext context)
    {
        _context = context;
    }

    [When(@"I click the button with id ""(.*)""")]
    public void WhenIClickRunButton(string id)
    {
        var wait = new WebDriverWait(_context.Driver, TimeSpan.FromSeconds(10));
        var button = wait.Until(
            ExpectedConditions.ElementToBeClickable(By.Id(id))
        );
        button.Click();
    }

    [Then(@"The output should contain ""(.*)""")]
    public void ThenTheOutputShouldContain(string text)
    {
        var wait = new WebDriverWait(_context.Driver, TimeSpan.FromSeconds(10));
        var output = wait.Until(
            ExpectedConditions.ElementIsVisible(By.Id("output"))
        );

        Assert.That(output.Text, Does.Contain(text));
    }
}
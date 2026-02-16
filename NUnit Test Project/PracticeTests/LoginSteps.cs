using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace NUnit_Test_Project.PracticeTests;

[Binding]
public class LoginSteps
{
    private readonly DriverContext _context;

    public LoginSteps(DriverContext context)
    {
        _context = context;
    }

    [When(@"I type ""(.*)"" into the username box with id ""(.*)""")]
    public void WhenITypeUsername(string username, string id)
    {
        var wait = new WebDriverWait(_context.Driver, TimeSpan.FromSeconds(10));
        var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
        element.Clear();
        element.SendKeys(username);
    }

    // ⭐ THIS WAS MISSING
    [When(@"I type ""(.*)"" into the password box with id ""(.*)""")]
    public void WhenITypePassword(string password, string id)
    {
        var wait = new WebDriverWait(_context.Driver, TimeSpan.FromSeconds(10));
        var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
        element.Clear();
        element.SendKeys(password);
    }

    [When(@"I click the submit button with id ""(.*)""")]
    public void WhenIClickSubmit(string id)
    {
        var wait = new WebDriverWait(_context.Driver, TimeSpan.FromSeconds(10));
        var button = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(id)));
        button.Click();
    }

    [Then(@"The new page URL should contain ""(.*)""")]
    public void ThenUrlContains(string url)
    {
        var wait = new WebDriverWait(_context.Driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.Url.Contains(url));
        Assert.That(_context.Driver.Url, Does.Contain(url));
    }

    [Then(@"The page should contain text ""(.*)""")]
    public void ThenThePageShouldContainText(string text)
    {
        var wait = new WebDriverWait(_context.Driver, TimeSpan.FromSeconds(10));
        var body = wait.Until(d => d.FindElement(By.TagName("body")));
        Assert.That(body.Text.ToLower(), Does.Contain(text.ToLower()));
    }

    [Then(@"The logout button should be visible")]
    public void ThenTheLogoutButtonShouldBeVisible()
    {
        var wait = new WebDriverWait(_context.Driver, TimeSpan.FromSeconds(10));

        var logoutButton = wait.Until(
            ExpectedConditions.ElementIsVisible(
                By.CssSelector("a.wp-block-button__link")
            )
        );

        Assert.That(logoutButton.Displayed, Is.True);
    }

    [Then(@"The message with id ""(.*)"" is displayed")]
    public void ThenTheMessageWithIdIsDisplayed(string id)
    {
        var wait = new WebDriverWait(_context.Driver, TimeSpan.FromSeconds(10));
        var message = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
        Assert.That(message.Displayed, Is.True);
    }


    [Then(@"The message with id ""(.*)"" should contain ""(.*)""")]
    public void ThenTheMessageWithIdShouldContain(string id, string expected)
    {
        var wait = new WebDriverWait(_context.Driver, TimeSpan.FromSeconds(10));
        var message = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
        Assert.That(message.Text, Does.Contain(expected));
    }

    [AfterScenario]
    public void Cleanup()
    {
        _context.Driver?.Quit();
    }
}

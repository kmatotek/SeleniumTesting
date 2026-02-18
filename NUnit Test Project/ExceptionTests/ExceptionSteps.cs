namespace NUnit_Test_Project.ExceptionTests;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

[Binding]
public class ExceptionSteps
{
    private readonly DriverContext _context;

    public ExceptionSteps (DriverContext context)
    {
        _context = context;
    }

    [Given(@"I open exception site ""(.*)""")]
    public void GivenIOpenExceptionSite(string url)
    {
        _context.Driver = new ChromeDriver();
        _context.Driver.Navigate().GoToUrl(url);
    }

    [When(@"I click the add button with id ""(.*)""")]
    public void WhenIClickTheAddButtonWithId(string id)
    {
        _context.Driver.FindElement(By.Id(id)).Click();
    }

    [When(@"I click on the text box on row with id ""(.*)"" and type ""(.*)""")]
    public void WhenIClickOnTheTextboxOnRowWithId(string id, String thingToType)
    {
        var wait = new WebDriverWait(_context.Driver, TimeSpan.FromSeconds(10));
        var row = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
        var inputField = row.FindElement(By.ClassName("input-field"));
        inputField.Click();
        inputField.SendKeys(thingToType);
    }

    [When(@"I click on the save button with name ""(.*)""")]
    public void WhenIClickOnTheSaveButtonWithName(string name)
    {
        // If we don't get the row element first, we will get ElementNotInteractableException
        // since there is another element with name "Save"
        
        var row = _context.Driver.FindElement(By.Id("row2"));
        var saveButton = row.FindElement(By.Name("Save"));
        
        //var saveButton = _context.Driver.FindElement(By.Name(name));
        
        saveButton.Click();
    }
    

    [Then(@"There should be a second row with id ""(.*)""")]
    public void ThenThereShouldBeASecondRowWithId(string id)
    {
        var wait = new WebDriverWait(_context.Driver, TimeSpan.FromSeconds(10));
        var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
        _context.Driver.FindElement(By.Id(id)).Click();
    }
}
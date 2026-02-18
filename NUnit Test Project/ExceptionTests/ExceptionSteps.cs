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

    [When(@"I clear the input field")]
    public void WhenIClearTheInputField()
    {
        var wait = new WebDriverWait(_context.Driver, TimeSpan.FromSeconds(10));
        var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("row1")));
        var textField = element.FindElement(By.ClassName("input-field"));
        
        // The input field is disabled. Trying to clear the disabled field
        // will throw InvalidElementStateException.
        // textField.Clear();
        // Instead we need to hit the edit button first, then we can clear it
        
    }

    [When(@"I find the instructions and click on the add button with id ""(.*)""")]
    public void WhenIFindTheInstructionsAndClickOnTheAddButtonWithId(string id)
    {
        var wait = new WebDriverWait(_context.Driver, TimeSpan.FromSeconds(10));
        var instructionElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("instructions")));
        
        var rowElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("row1")));
        
        var addButton = rowElement.FindElement(By.Id(id));
        addButton.Click();
        
        // The instructions element is removed from the page when the second row is added
        // Hence a StaleElementReferenceException is thrown
        Assert.IsTrue(instructionElement.Displayed);
        
    }

    [When(@"I wait three seconds and check input field")]
    public void WhenIWaitThreeSecondsAndCheckInputField()
    {
        var wait = new WebDriverWait(_context.Driver, TimeSpan.FromSeconds(3));
        
        // This will throw a TimeoutException, since we are only waiting 3 seconds,
        // But it takes 5 seconds for the row2 element to show up
        var row2 = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("row2")));
        
    }
}
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace NUnit_Test_Project;

[Binding]
public class CommonSteps
{
    private readonly DriverContext _context;

    public CommonSteps(DriverContext context)
    {
        _context = context;
    }

    [Given(@"I open ""(.*)""")]
    public void GivenIOpen(string url)
    {
        _context.Driver = new ChromeDriver();
        _context.Driver.Navigate().GoToUrl(url);
        _context.Driver.Manage().Window.Maximize();
    }
}
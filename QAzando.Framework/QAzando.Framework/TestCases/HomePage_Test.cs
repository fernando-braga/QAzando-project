using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QAzando.Framework.Pages;
using System.Linq;

namespace QAzando.Framework.TestCases
{
    [TestFixture]

    public class HomePage_Tests
    {
        private IWebDriver driver;
        private HomePage homePage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            homePage = new HomePage(driver);
            homePage.LoadConfigAndNavigate();
        }

        [Test]
        public void registerNewUser()
        {
            homePage.ClickLoginIcon();
            homePage.EnterUserCredentials();
            homePage.SubmitForm(); 
            homePage.VerifyWelcomeMessage();
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}

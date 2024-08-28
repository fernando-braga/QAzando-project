using NUnit.Framework;
using OpenQA.Selenium;
using QAzando.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAzando.Framework.Pages
{
    public class HomePage : BaseSettings
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public void ClickLoginIcon()
        {
            Driver.FindElement(By.CssSelector(".fa.fa-lock")).Click();
        }

        public void EnterUserCredentials()
        {
            DataGenerator.GenerateUserData();

            Driver.FindElement(By.Id("user")).SendKeys(DataGenerator.FirstName);
            Driver.FindElement(By.Id("email")).SendKeys(DataGenerator.Email);
            Driver.FindElement(By.Id("password")).SendKeys(DataGenerator.Password);           
        }

        public void SubmitForm()
        {
            Driver.FindElement(By.Id("btnRegister")).Click();
        }

        public void VerifyWelcomeMessage()
        {
            string welcomeMessage = Driver.FindElement(By.Id("swal2-html-container")).Text;
            string expectedMessage = $"Bem-vindo {DataGenerator.FirstName}";
            Assert.That(welcomeMessage, Does.Contain(expectedMessage));
        }

    }
}

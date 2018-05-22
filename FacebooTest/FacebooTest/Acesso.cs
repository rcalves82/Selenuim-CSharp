using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace FacebooTest
{
    [TestClass]
    public class Acesso
    {
        private object verificationErrors;

        [TestMethod]
        public void acessoFace()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.linkedin.com/");
            driver.Manage().Window.Maximize();

            IWebElement campoEmail = driver.FindElement(By.Name("session_key"));
            IWebElement campoSenha = driver.FindElement(By.Name("session_password"));
            IWebElement btnEntrar = driver.FindElement(By.Id("login-submit"));

            campoEmail.SendKeys("rodrigo_clarindo@yahoo.com.br");
            campoSenha.SendKeys("ro020482");

            btnEntrar.Click();

            driver.FindElement(By.CssSelector("li-icon[type=\"caret-filled-down-icon\"] > svg.artdeco-icon")).Click();
            Thread.Sleep(1000);

            driver.Quit();

        }
    }
}

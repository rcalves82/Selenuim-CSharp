using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UsuariosSystemTest
{
    [TestClass]
    public class UsuariosSystemTest1
    {
        private IWebDriver driver;

        public void URL()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:8080/usuarios");
            driver.FindElement(By.LinkText("Novo Usuário")).Click();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void DeveCadastrarUsuario()
        {
            URL();

            IWebElement campoNome = driver.FindElement(By.Name("usuario.nome"));
            IWebElement campoEmail = driver.FindElement(By.Name("usuario.email"));
            IWebElement btnSalvar = driver.FindElement(By.Id("btnSalvar"));

            campoNome.SendKeys("Rodrigo Clarindo");
            campoEmail.SendKeys("rodrigo.teste@teste.com.br");
            btnSalvar.Click();

            bool achouNome = driver.PageSource.Contains("Rodrigo Clarindo");
            bool achouEmail = driver.PageSource.Contains("rodrigo.teste@teste.com.br");

            Assert.IsTrue(achouNome);
            Assert.IsTrue(achouEmail);

            driver.Quit();
        }

        [TestMethod]
        public void NomeObrigatorio()
        {
            URL();

            IWebElement campoEmail = driver.FindElement(By.Name("usuario.email"));
            IWebElement btnSalvar = driver.FindElement(By.Id("btnSalvar"));

            campoEmail.SendKeys("rodrigo.teste@teste.com.br");
            btnSalvar.Click();

            bool achouMensagemDeErro = driver.PageSource.Contains("Nome obrigatorio!");

            driver.Quit();

        }

        [TestMethod]
        public void EmailObrigatorio()
        {
            URL();

            IWebElement campoNome = driver.FindElement(By.Name("usuario.nome"));
            IWebElement btnSalvar = driver.FindElement(By.Id("btnSalvar"));

            campoNome.SendKeys("Teste Email");
            btnSalvar.Click();

            bool achouMensagemDeErro = driver.PageSource.Contains("E-mail obrigatorio!");

            driver.Quit();
        }
    }
}

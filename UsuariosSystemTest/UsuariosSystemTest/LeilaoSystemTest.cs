using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UsuariosSystemTest
{
    [TestClass]
    public class LeilaoSystemTest
    {
        private IWebDriver driver;

        public void URL()
        {
            driver = new PhantomJSDriver();
            driver.Navigate().GoToUrl("http://localhost:8080/leiloes");
            driver.FindElement(By.LinkText("Novo Leilão")).Click();
            driver.Manage().Window.Maximize();
        }
        [TestMethod]
        public void DeveCadastrarLeilao()
        {
            URL();
            IWebElement campoLeilaoNome = driver.FindElement(By.Name("leilao.nome"));
            IWebElement campoValorLeilao = driver.FindElement(By.Name("leilao.valorInicial"));
            IWebElement usado = driver.FindElement(By.Name("leilao.usado"));
            IWebElement btnSalvar = driver.FindElement(By.XPath("//button[@type='submit']"));
            
            campoLeilaoNome.SendKeys("Samsung Galax S9");
            campoValorLeilao.SendKeys(Convert.ToString("2500"));
            
            SelectElement cdUsuario = new SelectElement(driver.FindElement(By.Name("leilao.usuario.id")));
            cdUsuario.SelectByText("Marciele");

            //usado.Click();
            btnSalvar.Click();

            bool achouNomeLeilao = driver.PageSource.Contains("Samsung Galax S9");
            bool achouValorLeiao = driver.PageSource.Contains("2500");

            Assert.IsTrue(achouNomeLeilao);
            Assert.IsTrue(achouValorLeiao);

            driver.Quit();

        }
    }
}

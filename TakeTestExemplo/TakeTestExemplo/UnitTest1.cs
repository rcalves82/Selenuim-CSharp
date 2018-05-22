using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TakeTestExemplo
{
    [TestClass]
    public class TestExemplost1
    {
        private IWebDriver driver = new ChromeDriver();

       
        //Cenário 1
        [TestMethod]
       
        public void VerificarSobreNaTela()
        {
            URL();

            var textoSobre = driver.FindElement(By.Id("menu-item-19"));
            textoSobre.Text.Equals("Sobre");

            Exit();
            
        }
        //Cenário 2
        [TestMethod]
        public void VerificarCategoriaNaTela()
        {
            URL();

            var textoCategoria = driver.FindElement(By.Id("menu-item-18"));
            textoCategoria.Text.Equals(value: "Categorias");

            Exit();
        }

        public void Exit()
        {
            driver.Quit();
        }

        public void URL()
        {

            driver.Navigate().GoToUrl("http://www.taketest.com.br/");
            driver.Manage().Window.Maximize();
        }

    }
}

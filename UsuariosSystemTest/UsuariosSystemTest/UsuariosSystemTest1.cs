using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;

namespace UsuariosSystemTest
{
    [TestClass]
    public class UsuariosSystemTest1
    {
        private IWebDriver driver;
        //private pages.UsuarioPage usuario;
        
        //public void abreNavegador()
        //{
        //    driver = new PhantomJSDriver();
        //    usuario = new pages.UsuarioPage(driver);
        //}

        public void URL()
        {
            driver = new PhantomJSDriver();
            driver.Navigate().GoToUrl("http://localhost:8080/usuarios");
            driver.FindElement(By.LinkText("Novo Usuário")).Click();
            driver.Manage().Window.Maximize();
        }
        [TestMethod]
       
        public void DeveCadastrarUsuario()
        {
            //usuario.Visita();

            //usuario.Novo();

            //usuario.Novo().Cadastra("Rodrigo", "rodrigo.qa@teste.com.br");

            //Assert.IsTrue(usuario.existeNaListagem("Rodrigo", "rodrigo.qa@teste.com.br"));

            URL();

            IWebElement campoNome = driver.FindElement(By.Name("usuario.nome"));
            IWebElement campoEmail = driver.FindElement(By.Name("usuario.email"));
            IWebElement btnSalvar = driver.FindElement(By.Id("btnSalvar"));

            campoNome.SendKeys("Marciele");
            campoEmail.SendKeys("marciele.teste@teste.com.br");
            btnSalvar.Click();

            bool achouNome = driver.PageSource.Contains("Marciele");
            bool achouEmail = driver.PageSource.Contains("marciele.teste@teste.com.br");

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

        [TestMethod]

        public void excluirCadastro()
        {
            URL();

            int posicao = 1; // queremos o 1o botao da pagina
            driver.FindElements(By.TagName("button"))[posicao - 1].Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            driver.Quit();

        }

        [TestMethod]

        public void editarUsuario()
        {
            URL();

            //int posicao = 1; // queremos o 1o botao da pagina
            //driver.FindElements(By.LinkText("editar"))[posicao - 1].Click();

            IWebElement linkEditarNome = driver.FindElement(By.XPath("(//a[contains(text(),'editar')])[2]"));
            linkEditarNome.Click();

            IWebElement editarNome = driver.FindElement(By.Name("usuario.nome"));
            IWebElement btnSalvar = driver.FindElement(By.Id("btnSalvar"));

            editarNome.SendKeys("Marciele Cardoso");
            btnSalvar.Click();

            driver.Quit();

        }
    }
}

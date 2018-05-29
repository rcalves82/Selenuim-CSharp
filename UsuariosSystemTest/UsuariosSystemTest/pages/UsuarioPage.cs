using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace UsuariosSystemTest.pages
{
    public class UsuarioPage
    {
        private IWebDriver driver;

        public UsuarioPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Visita()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/usuarios");
        }

        public NovoUsuarioPage Novo()
        {
            driver.FindElement(By.LinkText("Novo Usuário")).Click();
            return new NovoUsuarioPage(driver);
        }

        public bool existeNaListagem(string nome, string email)
        {
            return driver.PageSource.Contains(nome) &&
            driver.PageSource.Contains(email);

        }

    }
}
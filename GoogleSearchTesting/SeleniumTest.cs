using GoogleSearchAutomation.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;


namespace GoogleSearchTesting
{
    [TestClass]
    public class SeleniumTest
    {

        /// <summary>
        /// Caso 1. 
        /// Ir a Google.
        /// Digitar el texto de búsqueda.
        /// Hacer clic en el botón de búsqueda.
        /// Seleccionar el primer elemento de la página de resultados.
        /// </summary>
        [TestMethod]
        public void SelectFirstResult()
        {
            try
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://www.google.com");
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                HomePage homePage = new HomePage(driver);
                homePage.SendQuery("The name of the wind by P");
                homePage.PerformSearch();

                ResultsPage resultsPage = new ResultsPage(driver);
                resultsPage.SelectFirstResult();

                Thread.Sleep(1000);
                driver.Close();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Caso 2 
        /// Ir a Google.
        /// Digitar el texto de búsqueda.
        /// Seleccionar el primer elemento de la lista de sugerencias.
        /// Seleccionar el primer elemento de la página de resultados.
        /// </summary>
        [TestMethod]
        public void SelectFirstSuggestion()
        {
            try
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://www.google.com");
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                HomePage homePage = new HomePage(driver);
                homePage.SendQuery("The name of the wind by P");
                homePage.SelectFirstSuggestion();

                ResultsPage resultsPage = new ResultsPage(driver);
                resultsPage.SelectFirstResult();

                Thread.Sleep(1000);
                driver.Close();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}

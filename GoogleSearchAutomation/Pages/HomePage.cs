using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace GoogleSearchAutomation.Pages
{
    /// <summary>
    /// Representa la página principal
    /// </summary>
    public class HomePage
    {
        /// <summary>
        /// Driver que controla el navegador.
        /// </summary>
        private IWebDriver Driver;

        /// <summary>
        /// Caja de búsqueda.
        /// </summary>
        public IWebElement SearchBox;

        /// <summary>
        /// Botón de búsqueda.
        /// </summary>
        public IWebElement SearchButton;

        /// <summary>
        /// Lista de sugerencias de la búsqueda.
        /// </summary>
        public IReadOnlyCollection<IWebElement> Suggestions;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="driver"></param>
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
            SearchBox = Driver.FindElement(By.Name("q"));
            SearchButton = Driver.FindElement(By.Name("btnK"));
        }

        /// <summary>
        /// Digita el texto de búsqueda.
        /// </summary>
        /// <param name="query"></param>
        public void SendQuery(string query)
        {
            SearchBox.SendKeys(query);
        }

        /// <summary>
        /// Realiza la búsqueda en Google.
        /// </summary>
        public void PerformSearch()
        {
            SearchButton.Click();
        }

        /// <summary>
        /// Selecciona la primera sugerencia.
        /// </summary>
        public void SelectFirstSuggestion()
        {
            Suggestions = Driver.FindElements(By.ClassName("sbct"));
            Thread.Sleep(1500);
            SearchBox.SendKeys(Keys.Down);
            SearchBox.SendKeys(Keys.Enter);
        }
    }
}

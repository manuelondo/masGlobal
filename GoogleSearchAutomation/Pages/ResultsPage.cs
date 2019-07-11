using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace GoogleSearchAutomation.Pages
{
    /// <summary>
    /// Representa la página de resultados.
    /// </summary>
    public class ResultsPage
    {
        /// <summary>
        /// Driver que controla el navegador.
        /// </summary>
        private IWebDriver Driver;

        /// <summary>
        /// Lista de resultados de la búsqueda.
        /// </summary>
        public IReadOnlyCollection<IWebElement> Results;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="driver"></param>
        public ResultsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Selecciona el primer resultado de búsqueda.
        /// </summary>
        public void SelectFirstResult()
        {
            Results = Driver.FindElements(By.ClassName("r"));
            Thread.Sleep(1500);
            foreach (var item in Results)
            {
                item.Click();
                break;
            }
        }
    }
}

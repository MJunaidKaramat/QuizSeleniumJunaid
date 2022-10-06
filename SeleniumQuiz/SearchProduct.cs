using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace SeleniumQuiz
{
    public class SearchProduct:GeneralMethodsClass
    {
        #region search_product
        By productsButton = By.XPath("//a[contains(text(),' Products')]");
        By searchBoxInput = By.XPath("//input[@id='search_product']");
        By searchButton = By.XPath("//button[@id='submit_search']");
        #endregion
        public void searchPage()
        {
            clickAction(productsButton);
        }
        public void searchProduct(string search)
        {
            
            inputTextAction(searchBoxInput, search);
            clickAction(searchButton);
        }
    }
}

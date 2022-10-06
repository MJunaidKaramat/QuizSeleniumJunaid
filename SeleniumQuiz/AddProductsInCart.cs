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
    public class AddProductsInCart:GeneralMethodsClass
    {
        #region search_product
        By productsButton = By.XPath("//a[contains(text(),' Products')]");
        By selectProduct1 = By.XPath("(//i[@class='fa fa-shopping-cart'])[2]");
        By selectProduct2 = By.XPath("(//i[@class='fa fa-shopping-cart'])[4]");
        //By selectProduct1 = By.XPath("(//a[@data-product-id='1'])[2]");
        //By selectProduct2 = By.XPath("(//a[@data-product-id='2'])[2]");
        By continueShoppingButton = By.XPath("//button[contains(text(),'Continue Shopping')]");
        By cartButton = By.XPath("//a[contains(text(),' Cart')]");

        #endregion
        public void productPage()
        {
            scrollToElement(selectProduct1);
            scrollToElementClick(selectProduct1);
            clickAction(continueShoppingButton);
            scrollToElement(selectProduct2);
            scrollToElementClick(selectProduct2);
            clickAction(continueShoppingButton);
            clickAction(cartButton);
        }
    }
}

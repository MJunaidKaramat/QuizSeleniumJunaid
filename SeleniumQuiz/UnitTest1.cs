using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContext;
        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }
        string url = "https://automationexercise.com/";
        string browserName = "Chrome";

        [TestMethod]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "dataSource.xml", "SignUpValid", DataAccessMethod.Sequential)]
        public void UserRegisterationTestCase()
        {
            #region signUp
            By verifySignUp = By.XPath("//p[contains(text(),'Congratulations! Your new ')]");
            By verifyLogin = By.XPath("//b");
            By verifyHome = By.XPath("//a[text()=' Home']");
            By verifySignUpPage = By.XPath("//h2[contains(text(),'New User')]");
            By verifyAccountDetailPage = By.XPath("//b[contains(text(),'Enter')]");
            #endregion

            #region xml_file_data
            string userName = "Junaid Ali";
            string email = "junaidJunaidAli144@gmail.com";
            string password = "ABCabc123@@@";
            string date = "10";
            string month = "5";
            string year = "2000";
            string firstName = "Junaid";
            string lastName = "Ali";
            string company = "Contour Software";
            string address1 = "Gulberg";
            string address2 = "Lahore";
            string country = "Canada";
            string state = "Toranto";
            string city = "Toranto";
            string zipCode = "ABC1234";
            string phone = "03121234567";
            #endregion
            UserRegisteration registerUserObj = new UserRegisteration();
            registerUserObj.browserSelection(browserName);
            registerUserObj.mainPage(url);
            Assert.IsTrue(registerUserObj.verifyElementIsVisible(verifyHome));
            registerUserObj.TakeScreenShot();
            registerUserObj.SignUpPage();

            Assert.IsTrue(registerUserObj.verifyElementIsVisible(verifySignUpPage));
            registerUserObj.TakeScreenShot();
            registerUserObj.RegisterNewUser(userName, email, password, date, month, year, firstName,
                lastName, company, address1, address2, country, state, city, zipCode, phone);
            
            string expected = "Congratulations! Your new account has been successfully created!";
            string actual = registerUserObj.getText(verifySignUp);
            Assert.AreEqual(expected, actual);
            registerUserObj.TakeScreenShot();
            registerUserObj.confirmRegisteration();
            string expectedUserName = userName;
            string actualUserName = registerUserObj.getText(verifyLogin);
            Assert.AreEqual(expectedUserName, actualUserName);
            registerUserObj.closeBrowser();
        }
        [TestMethod]
        public void userLogin()
        {
            By verifyLogin = By.XPath("//b");
            By verifyHome = By.XPath("//a[text()=' Home']");
            By verifySignInPage = By.XPath("//h2[contains(text(),'New User')]");

            userSignIn loginObj = new userSignIn();
            loginObj.browserSelection(browserName);
            loginObj.mainPage(url);
            Assert.IsTrue(loginObj.verifyElementIsVisible(verifyHome));
            loginObj.loginUserPage();
            Assert.IsTrue(loginObj.verifyElementIsVisible(verifySignInPage));
            loginObj.loginFunctionality("junaidjuaidunaid@gmail.com", "Junaid123@");

            string expected = "Junaid";
            string actual = loginObj.getText(verifyLogin);
            Assert.AreEqual(expected , actual);
            loginObj.TakeScreenShot();
            loginObj.closeBrowser();
        }
        [TestMethod]
        public void userLogout()
        {
            By verifyLogOut = By.XPath("//div[@class='login-form']/h2");

            logoutMethod logoutMethodObj = new logoutMethod();
            logoutMethodObj.browserSelection(browserName);
            logoutMethodObj.mainPage(url);
            logoutMethodObj.logoutFunctionality("junaidjuaidunaid@gmail.com", "Junaid123@");
            string expectedUserName = "Login to your account";
            string actualUserName = logoutMethodObj.getText(verifyLogOut);
            Assert.AreEqual(expectedUserName, actualUserName);
            logoutMethodObj.TakeScreenShot();
            logoutMethodObj.closeBrowser();
        }
        [TestMethod]
        public void TC_4_SearchProduct()
        {
            By verifySearchProductPage = By.XPath("//h2[contains(text(),'All Products')]");
            By verifySearchedProductsPage = By.XPath("//h2[contains(text(),'Searched Products')]");
            By verifyHome = By.XPath("//a[text()=' Home']");

            SearchProduct searchObj = new SearchProduct();
            searchObj.browserSelection(browserName);
            searchObj.mainPage(url);
            Assert.IsTrue(searchObj.verifyElementIsVisible(verifyHome));
            searchObj.TakeScreenShot();
            searchObj.searchPage();
            Assert.IsTrue(searchObj.verifyElementIsVisible(verifySearchProductPage));
            searchObj.TakeScreenShot();
            searchObj.searchProduct("shirts");
            Assert.IsTrue(searchObj.verifyElementIsVisible(verifySearchedProductsPage));
            searchObj.TakeScreenShot();
            searchObj.closeBrowser();
        }
        [TestMethod]
        public void TC_5_DownloadInvoiceAfterPurchaseOrder()
        {
            By verifyHome = By.XPath("//a[text()=' Home']");
            By VerifyCartPage = By.XPath("//li[text()='Shopping Cart']");

            DownloadInvoiceClass obj = new DownloadInvoiceClass();

            #region xml_file_data
            string userName = "Junaid Ali";
            string email = "junaidJunaidAli131@gmail.com";
            string password = "ABCabc142@@@";
            string date = "10";
            string month = "5";
            string year = "2000";
            string firstName = "Junaid";
            string lastName = "Ali";
            string company = "Contour Software";
            string address1 = "Gulberg";
            string address2 = "Lahore";
            string country = "Canada";
            string state = "Toranto";
            string city = "Toranto";
            string zipCode = "ABC1234";
            string phone = "03121234567";
            #endregion
            obj.browserSelection(browserName);
            obj.mainPage(url);
            Assert.IsTrue(obj.verifyElementIsVisible(verifyHome));
            obj.addProductsToCart();
            obj.cartPage();
            Assert.IsTrue(obj.verifyElementIsVisible(VerifyCartPage));
            obj.proceedToCheckOut();
            obj.RegisterNewUser(userName, email, password, date, month, year, firstName,
                lastName, company, address1, address2, country, state, city, zipCode, phone);
            obj.confirmRegisteration();
            obj.cartPage();
            obj.TakeScreenShot();
            obj.proceedToCheckOutAfterLogin();
            obj.placeOrder();
            obj.TakeScreenShot();

            #region cardDetails
            string cardName = "Junaid";
            string cardNumber = "1234 1234 1234 1234";
            string CVC = "123";
            string exMonth = "07";
            string exYear = "2022";
            #endregion

            obj.cardDetails(cardName, cardNumber, CVC, exMonth, exYear);
            obj.closeBrowser();
        }
        [TestMethod]
        public void TC_6_AddProductsToCart()
        {
            By verifyHome = By.XPath("//a[text()=' Home']");
            By VerifyCartPage = By.XPath("//li[text()='Shopping Cart']");

            AddProductsInCart obj = new AddProductsInCart();
            obj.browserSelection(browserName);
            obj.mainPage(url);
            Assert.IsTrue(obj.verifyElementIsVisible(verifyHome));
            obj.productPage();
            obj.TakeScreenShot();
            obj.closeBrowser();
        }
        [TestMethod]
        public void TC_7_PlaceOrder_RegisterWhileCheckOut()
        {
            By verifyHome = By.XPath("//a[text()=' Home']");
            By VerifyCartPage = By.XPath("//li[text()='Shopping Cart']");

            RegisterWhileCheckOut obj = new RegisterWhileCheckOut();

            #region xml_file_data
            string userName = "Junaid Ali";
            string email = "junaidJunaidAli141@gmail.com";
            string password = "ABCabc123@@@";
            string date = "10";
            string month = "5";
            string year = "2000";
            string firstName = "Junaid";
            string lastName = "Ali";
            string company = "Contour Software";
            string address1 = "Gulberg";
            string address2 = "Lahore";
            string country = "Canada";
            string state = "Toranto";
            string city = "Toranto";
            string zipCode = "ABC1234";
            string phone = "03121234567";
            #endregion

            obj.browserSelection(browserName);
            obj.mainPage(url);
            Assert.IsTrue(obj.verifyElementIsVisible(verifyHome));
            obj.addProductsToCart();
            obj.cartPage();
            Assert.IsTrue(obj.verifyElementIsVisible(VerifyCartPage));
            obj.proceedToCheckOut();
            obj.RegisterNewUser(userName, email, password, date, month, year, firstName,
                lastName, company, address1, address2, country, state, city, zipCode, phone);
            obj.confirmRegisteration();
            obj.TakeScreenShot();
            obj.cartPage();
            obj.proceedToCheckOutAfterLogin();
            obj.placeOrder();

            #region cardDetails
            string cardName = "Junaid";
            string cardNumber = "1234 1234 1234 1234";
            string CVC = "123";
            string exMonth = "07";
            string exYear = "2022";
            #endregion

            obj.cardDetails(cardName, cardNumber, CVC, exMonth, exYear);
            obj.TakeScreenShot();
            obj.closeBrowser();
        }
    }
}

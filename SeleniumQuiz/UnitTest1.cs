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
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "dataSource.xml", "SignUpValid", DataAccessMethod.Sequential)]
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
            string userName = TestContext.DataRow["userName"].ToString();
            string email = TestContext.DataRow["userEmail"].ToString();
            string password = TestContext.DataRow["userPassword"].ToString();
            string date = TestContext.DataRow["date"].ToString();
            string month = TestContext.DataRow["month"].ToString();
            string year = TestContext.DataRow["year"].ToString();
            string firstName = TestContext.DataRow["firstName"].ToString();
            string lastName = TestContext.DataRow["lastName"].ToString();
            string company = TestContext.DataRow["company"].ToString();
            string address1 = TestContext.DataRow["userAddress1"].ToString();
            string address2 = TestContext.DataRow["userAddress2"].ToString();
            string country = TestContext.DataRow["country"].ToString();
            string state = TestContext.DataRow["state"].ToString();
            string city = TestContext.DataRow["userCity"].ToString();
            string zipCode = TestContext.DataRow["zipcode"].ToString();
            string phone = TestContext.DataRow["userPhone"].ToString();
            #endregion
            UserRegisteration registerUserObj = new UserRegisteration();
            registerUserObj.browserSelection(browserName);
            registerUserObj.mainPage(url);
            Assert.IsTrue(registerUserObj.verifyElementIsVisible(verifyHome));
            registerUserObj.SignUpPage();

            Assert.IsTrue(registerUserObj.verifyElementIsVisible(verifySignUpPage));
            registerUserObj.RegisterNewUser(userName, email, password, date, month, year, firstName,
                lastName, company, address1, address2, country, state, city, zipCode, phone);
            
            string expected = "Congratulations! Your new account has been successfully created!";
            string actual = registerUserObj.getText(verifySignUp);
            Assert.AreEqual(expected, actual);
            
            registerUserObj.confirmRegisteration();
            string expectedUserName = "Junaid";
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
            searchObj.searchPage();
            Assert.IsTrue(searchObj.verifyElementIsVisible(verifySearchProductPage));
            searchObj.searchProduct("shirts");
            Assert.IsTrue(searchObj.verifyElementIsVisible(verifySearchedProductsPage));
            searchObj.closeBrowser();
        }
        [TestMethod]
        public void TC_5_DownloadInvoiceAfterPurchaseOrder()
        {
            By verifyHome = By.XPath("//a[text()=' Home']");
            By VerifyCartPage = By.XPath("//li[text()='Shopping Cart']");

            DownloadInvoiceClass obj = new DownloadInvoiceClass();

            obj.browserSelection(browserName);
            obj.mainPage(url);
            Assert.IsTrue(obj.verifyElementIsVisible(verifyHome));
            obj.addProductsToCart();
            obj.cartPage();
            Assert.IsTrue(obj.verifyElementIsVisible(VerifyCartPage));
            obj.proceedToCheckOut();
            obj.RegisterNewUser("Junaid", "junaidjuaiadjunaid125@gmail.com", "Junaid123@", "5", "4", "2000", "Junaid",
                "Junaid", "Contour", "Muridke", "Lahore", "Canada", "Toranto", "ABCZY", "39000", "0300-1234567");
            obj.confirmRegisteration();
            obj.cartPage();
            obj.proceedToCheckOutAfterLogin();
            obj.placeOrder();
            obj.cardDetails("Junaid", "1234 1234 1234 1234", "123", "07", "2022");
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
            //Assert.IsTrue(obj.verifyElementIsVisible(VerifyCartPage));
        }
    }
}

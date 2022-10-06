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
    public class DownloadInvoiceClass:GeneralMethodsClass
    {
        #region search_product
        By selectProduct1 = By.XPath("(//i[@class='fa fa-shopping-cart'])[2]");
        By selectProduct2 = By.XPath("(//i[@class='fa fa-shopping-cart'])[4]");
        By selectProduct3 = By.XPath("(//i[@class='fa fa-shopping-cart'])[12]");
        By selectProduct4 = By.XPath("(//i[@class='fa fa-shopping-cart'])[22]");
        By continueShoppingButton = By.XPath("//button[contains(text(),'Continue Shopping')]");
        By cartButton = By.XPath("//a[contains(text(),' Cart')]");
        By checkOutButton = By.XPath("//a[text()='Proceed To Checkout']");
        By loginAsUserButton = By.XPath("//u[text()='Register / Login']");
        By commentBox = By.XPath("//textarea[@name='message']");
        By placeOrderButton = By.XPath("//a[contains(text(),'Place Order')]");
        By cardNameInput = By.Name("name_on_card");
        By cardNumberInput = By.Name("card_number");
        By cvcInput = By.XPath("//input[@name='cvc']");
        By expiryMonthInput = By.Name("expiry_month");
        By expiryYearInput = By.Name("expiry_year");
        By confirmOrderButton = By.XPath("//button[@id='submit']");
        By downloadInvoiceButton = By.XPath("//a[text()='Download Invoice']");
        By continueAfterCheckOutButton = By.XPath("//a[text()='Continue']");


        #endregion

        public void addProductsToCart()
        {
            scrollToElement(selectProduct1);
            scrollToElementClick(selectProduct1);
            clickAction(continueShoppingButton);
            scrollToElement(selectProduct2);
            scrollToElementClick(selectProduct2);
            clickAction(continueShoppingButton);
            scrollToElement(selectProduct3);
            scrollToElementClick(selectProduct3);
            clickAction(continueShoppingButton);
            scrollToElement(selectProduct4);
            scrollToElementClick(selectProduct4);
            clickAction(continueShoppingButton);
        }
        public void cartPage()
        {
            scrollToElementClick(cartButton);
        }
        public void proceedToCheckOut()
        {
            clickAction(checkOutButton);
            clickAction(loginAsUserButton);
        }
        public void proceedToCheckOutAfterLogin()
        {
            clickAction(checkOutButton);
        }

        //SignUp Functionality
        #region UserRegisterationElements
        By signUp = By.XPath("//a[@href='/login']");
        By nameField = By.XPath("//input[@placeholder='Name']");
        By emailField = By.XPath("//form[@action='/signup']/input[@placeholder='Email Address']");
        By signUpButton = By.XPath("//button[contains(text(),'Signup')]");
        By radioTitle = By.XPath("//label[@for='id_gender1']");
        By passwordField = By.XPath("//input[@name='password']");
        By dateDrpDown = By.XPath("//select[@name='days']");
        By monthDrpDown = By.XPath("//select[@name='months']");
        By yearDrpDown = By.XPath("//select[@name='years']");
        By newsLetterCheck = By.XPath("//input[@name='newsletter']");
        By specialOffersCheck = By.XPath("//input[@name='optin']");
        By firstNameField = By.XPath("//input[@name='first_name']");
        By lastNameField = By.XPath("//input[@name='last_name']");
        By companyField = By.XPath("//input[@name='company']");
        By addressField1 = By.XPath("//input[@name='address1']");
        By addressField2 = By.XPath("//input[@name='address2']");
        By countryDrpDown = By.XPath("//select[@name='country']");
        By stateField = By.XPath("//input[@name='state']");
        By cityField = By.XPath("//input[@name='city']");
        By zipCodeField = By.XPath("//input[@name='zipcode']");
        By contactField = By.XPath("//input[@name='mobile_number']");
        By completeSignUpButton = By.XPath("//button[contains(text(),'Create Account')]");
        By continueButton = By.XPath("//a[contains(text(),'Continue')]");
        #endregion

        public void RegisterNewUser(string name, string email, string pass, string date, string month, string year,
            string fName, string lName, string company, string address1, string address2, string country, string state,
            string city, string zip, string contact)
        {

            inputTextAction(nameField, name);
            inputTextAction(emailField, email);
            clickAction(signUpButton);
            clickAction(radioTitle);
            inputTextAction(passwordField, pass);
            selectFromDropDown(dateDrpDown, date);
            selectFromDropDown(monthDrpDown, month);
            selectFromDropDown(yearDrpDown, year);
            clickCheckBox(newsLetterCheck);
            clickCheckBox(specialOffersCheck);
            scrollToInputElement(firstNameField, fName);
            scrollToInputElement(lastNameField, lName);
            scrollToInputElement(companyField, company);
            scrollToInputElement(addressField1, address1);
            scrollToInputElement(addressField2, address2);
            scrollToInputElement(countryDrpDown, country);
            scrollToInputElement(stateField, state);
            scrollToInputElement(cityField, city);
            scrollToInputElement(zipCodeField, zip);
            scrollToInputElement(contactField, contact);
            scrollToElementClick(completeSignUpButton);
        }
        public void confirmRegisteration()
        {
            clickAction(continueButton);
        }
        public void placeOrder()
        {
            inputTextAction(commentBox, "Just Comments");
            clickAction(placeOrderButton);
        }
        public void cardDetails(string cardName, string cardNo, string cvc, string exMonth, string exYear)
        {
            inputTextAction(cardNameInput, cardName);
            inputTextAction(cardNumberInput, cardNo);
            inputTextAction(cvcInput, cvc);
            inputTextAction(expiryMonthInput, exMonth);
            inputTextAction(expiryYearInput, exYear);
            clickAction(confirmOrderButton);
            clickAction(downloadInvoiceButton);
            clickAction(continueAfterCheckOutButton);

        }
    }
}

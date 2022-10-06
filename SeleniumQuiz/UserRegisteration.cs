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
    public class UserRegisteration:GeneralMethodsClass
    {
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

        public void SignUpPage()
        {
            clickAction(signUp);
        }
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
    }
}

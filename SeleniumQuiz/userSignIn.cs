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
    public class userSignIn:GeneralMethodsClass
    {
        #region loginObjects
        By signInButton = By.XPath("//a[@href='/login']");
        By emailField = By.XPath("//form[@action='/login']/input[@name='email']");
        By passwordField = By.XPath("//form[@action='/login']/input[@name='password']");
        By loginButton = By.XPath("//form[@action='/login']/button[@type='submit']");
        #endregion

        public void loginUserPage()
        {
            clickAction(signInButton);
        }
        public void loginFunctionality(string email, string pass)
        {
            inputTextAction(emailField, email);
            inputTextAction(passwordField, pass);
            clickAction(loginButton);
        }
    }
}

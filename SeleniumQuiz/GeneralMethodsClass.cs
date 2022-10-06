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
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumQuiz
{
    public class GeneralMethodsClass
    {
        private IWebDriver driver;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void browserSelection(string br)
        {
            if(br.Equals("Chrome", StringComparison.InvariantCultureIgnoreCase))
            {
                driver = new ChromeDriver();
                log.Info(br + " browser has been loaded");
            }
            else if(br.Equals("Edge", StringComparison.InvariantCultureIgnoreCase))
            {
                driver = new EdgeDriver();
                log.Info(br + " browser has been loaded");
            }
            else if(br.Equals("FireFox", StringComparison.InvariantCultureIgnoreCase))
            {
                driver = new FirefoxDriver();
                log.Info(br + " browser has been loaded");
            }

            driver.Manage().Window.Maximize();
        }
        public void mainPage(string u)
        {
            driver.Url = u;
            log.Info(u + " Url has been Loaded Successfully");
        }
        public IWebElement findElement(By path)
        {
            IWebElement element = ExplicitWaitForElement(path);
            log.Info("Element found sucessfully");
            return element;
        }
        public void clickAction(By path)
        {
            IWebElement element = findElement(path);
            log.Info("Element is Clicked.");
            element.Click();
        }
        public void inputTextAction(By path, string data)
        {
            IWebElement element = findElement(path);
            element.SendKeys(data);
            log.Info(data + " has been entered in Text Box");
        }
        public IWebElement ExplicitWaitForElement(By path)
        {
            IWebElement element;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(path));
            log.Info(wait + " waited for element to be visible");
            return element;
        }
        public void clickCheckBox(By path)
        {
            IWebElement element = findElement(path);
            if (element.Enabled)
            {
                element.Click();
                log.Info("Check Box has been checked.");
            }
            
        }
        public void selectFromDropDown(By path, string obj)
        {
            IWebElement element = findElement(path);
            SelectElement drpDownItem = new SelectElement(element);
            drpDownItem.SelectByValue(obj);
            log.Info(obj + " has been selected from drop down.");
        }
        public void scrollToElementClick(By path)
        {
            IJavaScriptExecutor scroller = (IJavaScriptExecutor)driver;
            IWebElement element = ExplicitWaitForElement(path);
            scroller.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            clickAction(path);
            log.Info("Scrolled to element and click action is performed.");
        }
        public void scrollToElement(By path)
        {
            IJavaScriptExecutor scroller = (IJavaScriptExecutor)driver;
            IWebElement element = ExplicitWaitForElement(path);
            scroller.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            log.Info("Scrolled to element");
        }
        public void scrollToInputElement(By path, string data)
        {
            IJavaScriptExecutor scroller = (IJavaScriptExecutor)driver;
            IWebElement element = ExplicitWaitForElement(path);
            scroller.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.SendKeys(data);
            log.Info("Scrolled to element and " + data + " has been entered.");
        }
        public string getText(By path)
        {
            string str = "";
            IWebElement element = ExplicitWaitForElement(path);
            str = element.GetAttribute("innerHTML");
            log.Info(str + " text has been collected");
            return str;
        }
        public bool verifyElementIsVisible(By path)
        {
            IWebElement element = findElement(path);
            bool result = element.Displayed || element.Enabled ? true : false;
            return result;
        }
        public void closeBrowser()
        {
            driver.Close();
            log.Info("Browser is successfully closed after completion of test Case.");
        }
        public void hoverAction(By path)
        {
            IWebElement webElement = findElement(path);
            Actions action = new Actions(driver);
            action.MoveToElement(webElement).Click().Perform();
        }
    }
}

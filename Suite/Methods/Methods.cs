using System;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace AutomationAcceptanceTests.StepDefs
{
    public class Methods : Utils.Locators
    {
        //driver instance
        public static IWebDriver driver = null;
        public static string browserType;
        public static string userType;

        [BeforeScenario]
        public void Initialize()
        {
            //pass browser name on which want to run the tests
            browserType = "Chrome";
            //browserType = "IE";
            //browserType = "Firefox";
        }

        //closes the driver after every scenario
        [AfterScenario]
        public void CleanUp()
        {
            driver.Quit();
        }

        //picks the browser type which we have passed above from the list
        [SetUp]
        internal void SetUp()
        {
            switch (browserType)
            {
                case "Chrome":
                    string chromeDriverDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var options = new ChromeOptions();
                    options.AddArgument("-no-sandbox");
                    driver = new ChromeDriver(chromeDriverDirectory, options, TimeSpan.FromMinutes(10));
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                case "Firefox":
                    string firefoxDriverDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("-no-sandbox");
                    driver = new FirefoxDriver(firefoxDriverDirectory, firefoxOptions, TimeSpan.FromMinutes(10));
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(3);
                    break;
            }
            driver.Manage().Window.Maximize();
        }

        //to log in with different user types
        public void UserLogin(string Type)
        {
            switch (Type)
            {
                case "Anonymous":
                    break;
                case "Admin":
                    driver.FindElement(By.Id("edit-name")).SendKeys("");
                    driver.FindElement(By.Id("edit-pass")).SendKeys("");
                    break;
            }
        }

        //to enter an input into a particular input field
        public void EnterInputIntoField(string input, string field)
        {
            driver.FindElement(By.Id(Utils.Locators.ElementLocator(field))).SendKeys(input);
        }

        //to check a particular text on the page
        public void CheckForTextOnPage(string text)
        {
            IWebElement body = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(body.Text.Contains(text));
        }

        //to check a particular page header
        public void CheckPageHeader(string pageHeader)
        {
            driver.PageSource.Contains(pageHeader);
        }

        //to check for an error message
        public void ThenAnErrorIsDisplayed(string errorMessage, string ErrorFor)
        {
            string message = driver.FindElement(By.CssSelector(Utils.Locators.ElementLocator(ErrorFor))).Text;
            Assert.IsTrue(message.Contains(errorMessage));
        }

        //to check does element exist with id
        public void DoesElementIdExist(string id)
        {
            try
            {
                driver.FindElement(By.Id(Utils.Locators.ElementLocator(id)));
            }
            catch (NoSuchElementException)
            {
            }
        }

        //to perform a scroll to element
        public void ScrollToElement(string id)
        {
            var element = driver.FindElement(By.CssSelector(Utils.Locators.ElementLocator(id)));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        //to perform click action on links
        public void ClickLink(string link)
        {
            driver.FindElement(By.LinkText(Utils.Locators.ElementLocator(link))).Click();
        }

        //to perform click action on image links
        public void ClickImageLink(string link)
        {
            driver.FindElement(By.CssSelector(Utils.Locators.ElementLocator(link))).Click();
        }

        //to check does the text present on the page
        public void DoesTextExits(string content)
        {
            String text = driver.FindElement(By.XPath("")).Text;
            Assert.Equals("", text);
        }

        //to perform a back action in the browser
        public void BrowserBack()
        {
            driver.Navigate().Back();
        }

        //to perform a forward action in the browser
        public void BrowserForward()
        {
            driver.Navigate().Forward();
        }

        //to perform a browser refresh
        public void BrowserRefresh()
        {
            driver.Navigate().Refresh();
        }

        //to match the page with current one
        public void PageMatch(string elementURL)
        {
            string currentUrl = driver.Url;
            string compareUrl = baseURL + (Utils.Locators.LinksUrlSearch(elementURL));
            Assert.IsTrue(currentUrl.Equals(compareUrl));

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(baseURL));
        }

        //to match the external page with current one
        public void ExternalPageMatch(string page)
        {
            string currentUrl = driver.Url;
            string compareUrl = page;
            currentUrl.Equals(compareUrl);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(currentUrl));
        }

        //to check the page title
        public void PageTitle(string title)
        {
            String titleOfPage = driver.Title;
            Assert.IsTrue(titleOfPage.Contains(title));
        }

        //to perform a click action on button
        public void ClickOnButton(string button)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.FindElement(By.XPath(Utils.Locators.ElementLocator(button))).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(baseURL));
        }

        //to perform a click action on a different button type
        public void ClickOnOtherButton(string button)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.FindElement(By.CssSelector(Utils.Locators.ElementLocator(button))).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(baseURL));
        }

        //to select an item from dropdown list
        public void SelectSingleDropDownList(string text, string dropDown)
        {
            //need to pass element id for "Element_ID"
            SelectElement oSelect = new SelectElement(driver.FindElement(By.Id(Utils.Locators.ElementLocator(dropDown))));
            //SelectElement oSelect = new SelectElement(driver.FindElement(By.CssSelector(Utils.Locators.ElementLocator(dropDown))));
            //SelectElement oSelect = new SelectElement(driver.FindElement(By.XPath(Utils.Locators.ElementLocator(dropDown))));
            //need to pass for "Text" anything from - index/value/text/options
            oSelect.SelectByText(Utils.Locators.TextLocator(text));
        }

        //to check a certain type of content on the page
        public void ContentOnPage(string text, string link)
        {
            driver.FindElement(By.CssSelector(Utils.Locators.ElementLocator(link))).Text.Equals(Utils.Locators.TextLocator(text));
        }

        //to perfrom a click on radio button
        public void SelectRadioButton(string radioButton)
        {
            driver.FindElement(By.CssSelector(Utils.Locators.ElementLocator(radioButton))).Click();
        }

        //to check if a radio button button is already selected
        public void DefaultRadioButton(string radio)
        {
            bool defaultRadio = driver.FindElement(By.Id(Utils.Locators.ElementLocator(radio))).Selected;
        }

        //to perfrom a click on check box
        public void SelectCheckBox(string checkBox)
        {
            driver.FindElement(By.CssSelector(Utils.Locators.ElementLocator(checkBox))).Click();
        }

        //to perform a click action on file upload buttton
        public void ClickOnFileUploadButton(string button)
        {
            driver.FindElement(By.Id(Utils.Locators.ElementLocator(button))).Click();
        }

        //to perform a file upload
        public void AFileUpload(string file)
        {
            string testPathDir = AppDomain.CurrentDomain.BaseDirectory + "FileUploads\\";
            string fileType = Path.Combine(testPathDir + @file);
            Thread.Sleep(2000);

            SendKeys.SendWait(fileType);

            SendKeys.SendWait("{Enter}");
            Thread.Sleep(3000);
        }

        //to check a particular text not available on the page
        public void CheckForTextOnPageNotAvailable(string text)
        {
            IWebElement body = driver.FindElement(By.TagName("body"));
            Assert.IsFalse(body.Text.Contains(text));
        }

        //to enter a input into a particular text area
        public void EnterInputIntoTextArea(string input, string field)
        {
            driver.FindElement(By.Id(Utils.Locators.ElementLocator(field))).SendKeys(Utils.Locators.TextLocator(input));
        }

        //to check if the submitted application has displayed the correct alert message
        public void ApplicationSubmitted(string message)
        {
            switch (message)
            {
                case "Successful":
                    Thread.Sleep(2000);
                    String successMessage = driver.FindElement(By.CssSelector("Example")).Text;
                    Assert.IsTrue(successMessage.Contains("Example"));
                    break;
                case "Pending":
                    Thread.Sleep(2000);
                    String pendingMessage = driver.FindElement(By.CssSelector("Example")).Text;
                    Assert.IsTrue(pendingMessage.Contains("Example"));
                    break;
                case "Failed":
                    Thread.Sleep(2000);
                    String failedMessage = driver.FindElement(By.CssSelector("Example")).Text;
                    Assert.IsTrue(failedMessage.Contains("Example"));
                    break;
            }
        }
    }
}
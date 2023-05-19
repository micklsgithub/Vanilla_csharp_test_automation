using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace AutomationAcceptanceTests.StepDefs
{
    [Binding]
    public class CommonSteps : StepDefs.Methods
    {
        [When(@"I scroll to ""(.*)"" on the page")]
        public void WhenIScrollToOnThePage(string id)
        {
            ScrollToElement(id);
        }

        [When(@"I wait for ""(.*)"" milliseconds")]
        public void WhenIWaitForMilliseconds(int waitTime)
        {
            Thread.Sleep(waitTime);
        }

        [When(@"I select ""(.*)"" radio button")]
        public void WhenISelectRadioButton(string radio)
        {
            SelectRadioButton(radio);
        }

        [Given(@"I navigate to ""(.*)"" page as a ""(.*)"" user")]
        public void GivenINavigateToPageAsAUser(string page, string userType)
        {
            SetUp();
            var URL = baseURL + (Utils.Locators.LinksUrlSearch(page));
            driver.Navigate().GoToUrl(URL);
            UserLogin(userType);
        }

        [When(@"I click ""(.*)"" link")]
        public void WhenIClickLink(string link)
        {
            Thread.Sleep(500);
            ClickLink(link);
        }

        [When(@"I click image ""(.*)"" link")]
        public void WhenIClickImageLink(string link)
        {
            Thread.Sleep(500);
            ClickImageLink(link);
        }

        [When(@"I click the ""(.*)"" button")]
        public void WhenIClickTheButton(string button)
        {
            Thread.Sleep(500);
            ClickOnButton(button);
        }

        [When(@"I click the other ""(.*)"" button type")]
        public void WhenIClickTheOtherButtonType(string button)
        {
            Thread.Sleep(500);
            ClickOnOtherButton(button);
        }

        [When(@"I enter ""(.*)"" in the ""(.*)"" input field")]
        public void WhenIEnterInTheInputField(string input, string inputField)
        {
            EnterInputIntoField(input, inputField);
        }

        [When(@"I select ""(.*)"" from the ""(.*)"" list")]
        public void WhenISelectFromTheList(string text, string dropDown)
        {
            Thread.Sleep(500);
            SelectSingleDropDownList(text, dropDown);
        }

        [Then(@"I should be on the ""(.*)"" page")]
        public void ThenIShouldBeOnThePage(string page)
        {
            Thread.Sleep(500);
            PageMatch(page);
        }

        [Then(@"I should be on the ""(.*)"" external page")]
        public void ThenIShouldBeOnTheExternalPage(string page)
        {
            Thread.Sleep(500);
            ExternalPageMatch(page);
        }

        [Then(@"The ""(.*)"" element shouldn't exist on the page")]
        public void ThenThisElementShouldntExistOnPage(string id)
        {
            Thread.Sleep(500);
            DoesElementIdExist(id);
        }

        [Then(@"I should see the page header as ""(.*)""")]
        public void ThenIShouldSeeThePageHeaderAs(string header)
        {
            CheckPageHeader(header);
        }

        [Then(@"I should see the ""(.*)"" radio button has already been selected")]
        public void ThenIShouldSeeTheRadioButtonHasAlreadyBeenSelected(string radio)
        {
            DefaultRadioButton(radio);
        }

        [Then(@"I should see the text on the page as ""(.*)""")]
        public void ThenIShouldSeeTheTextOnThePageAs(string text)
        {
            CheckForTextOnPage(text);
        }

        [When(@"I upload a ""(.*)"" from file explorer")]
        public void WhenIUploadAFromFileExplorer(string file)
        {
            AFileUpload(file);
        }

        [When(@"I click on ""(.*)"" upload button")]
        public void WhenIClickOnTheUploadButton(string button)
        {
            ClickOnFileUploadButton(button);
        }

        [Then(@"I should not see the text on the page as ""(.*)""")]
        public void ThenIShouldNotSeeTheTextOnThePageAs(string text)
        {
            CheckForTextOnPageNotAvailable(text);
        }

        [When(@"I enter ""(.*)"" in the ""(.*)"" text area")]
        public void WhenIEnterInTheTextArea(string input, string inputField)
        {
            EnterInputIntoTextArea(input, inputField);
        }

        [When(@"I click on the ""(.*)"" form button")]
        public void WhenIClickOnTheFormButton(string button)
        {
            driver.FindElement(By.Id(Utils.Locators.ElementLocator(button))).Click();
        }

        [Then(@"I should see the application submitted as ""(.*)"" status")]
        public void ThenIShouldSeeTheApplicationSubmittedAsStatus(String message)
        {
            ApplicationSubmitted(message);
        }

        [When(@"I select ""(.*)"" checkbox")]
        public void WhenISelectCheckbox(string checkBox)
        {
            SelectCheckBox(checkBox);
        }

        [When(@"I go back in the browser")]
        public void WhenIGoBackInTheBrowser()
        {
            BrowserBack();
        }

        [When(@"I go forward in the browser")]
        public void WhenIGoForwardInTheBrowser()
        {
            BrowserForward();
        }

        [When(@"I refresh the browser")]
        public void WhenIGoRefreshTheBrowser()
        {
            BrowserRefresh();
        }
    }
}
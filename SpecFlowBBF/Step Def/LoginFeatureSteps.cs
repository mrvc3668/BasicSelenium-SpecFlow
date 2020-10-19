using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowBBF.Step_Def
{
    [Binding]
    public class LoginFeatureSteps: IDisposable
    {
        private ChromeDriver driver;
        private String username = "test";
        private String password = "pass";

        public LoginFeatureSteps()
        {
            driver = new ChromeDriver();
        }

        [Given(@"the user is at the login page")]
        public void GivenTheUserIsAtTheLoginPage()
        {
            driver.Url = "https://s2.demo.opensourcecms.com/orangehrm/symfony/web/index.php/auth/login";
        }

        [When(@"the user types in the'(.*)' and '(.*)' then clicks the login button")]
        public void WhenTheUserTypesInTheAndThenClicksTheLoginButton(string user, string pass)
        {
            this.username = user.ToLower();
            this.password = pass.ToLower();
            var usernameElem = driver.FindElementById("txtUsername");
            var passwordElem = driver.FindElementById("txtPassword");
            var signbuttonElem = driver.FindElementById("btnLogin");

            usernameElem.SendKeys(username);
            passwordElem.SendKeys(password);

            signbuttonElem.Click();

        }

        [Then(@"the user will be directed to the home page")]
        public void ThenTheUserWillBeDirectedToTheHomePage()
        {
            String homepage = driver.FindElementByXPath("//*[text()='Welcome Admin']").Text;
            System.Console.WriteLine("homepa: " + homepage);
            Assert.AreEqual(homepage, "Welcome Admin");
        }

        [When(@"the user is at the home page and clicks the logout button")]
        public void WhenTheUserIsAtTheHomePageAndClicksTheLogoutButton()
        {
            var logoutElem = driver.FindElementByXPath("//*[text()='Logout']");
            logoutElem.Click();
        }

        [Then(@"the user will be directed to the login page")]
        public void ThenTheUserWillBeDirectedToTheLoginPage()
        {
            var loginElem = driver.FindElementByXPath("//div[text()='LOGIN Panel']").Text;
            Assert.AreEqual("LOGIN Panel", loginElem);
        }



/// <summary>
/// Dispose release unused resources
/// </summary>
        public void Dispose()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver = null;
            }
        }
    }
}

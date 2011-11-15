using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Should.Fluent;
using TechTalk.SpecFlow;

namespace AtddDotNetSpecs.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        private FirefoxDriver driver;

        [BeforeScenario()]
        public void OpenBrowser()
        {
            driver = new FirefoxDriver();
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            driver.Close();
            driver.Dispose();
        }

        [Given(@"I am in the address book")]
        public void GivenIAmInTheAddressBook()
        {
            driver.Navigate().GoToUrl("http://localhost:21985/addressbook");
        }

        [When(@"I enter the name John Doe")]
        public void WhenIEnterTheNameJohnDoe()
        {
            driver.FindElementByCssSelector("#newperson #name").SendKeys("John Doe");
        }

        [When(@"I press return")]
        public void WhenIPressReturn()
        {
            driver.Keyboard.PressKey(Keys.Enter);
        }

        [Then(@"John Doe should be added to the address book")]
        public void ThenJohnDoeShouldBeAddedToTheAddressBook()
        {
            driver.FindElementByCssSelector("#people a#johndoe").Should().Not.Be.Null();
        }

        [Then(@"John Doe should highlighted")]
        public void ThenJohnDoeShouldHighlighted()
        {
            driver.FindElementByCssSelector("a#johndoe").GetAttribute("class").Should().Contain("recentlyadded");
        }

    }

}

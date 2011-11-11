using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Should.Fluent;
using TechTalk.SpecFlow;

namespace AtddDotNetSpecs.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        private FirefoxDriver driver = new FirefoxDriver();

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
            driver.FindElementByCssSelector("#people a#johndoe").GetAttribute("class").Should().Contain("recentlyadded");
        }
    
    }

}

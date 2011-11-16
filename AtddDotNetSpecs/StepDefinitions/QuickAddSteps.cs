using AtddDotNetSpecs.Pages;
using Should.Fluent;
using TechTalk.SpecFlow;

namespace AtddDotNetSpecs.StepDefinitions
{
    [Binding]
    public class QuickAddSteps
    {
        private AddressBookPage page;

        [AfterScenario]
        public void CloseBrowser()
        {
            AtddSite.Close();
        }

        [Given(@"I am in the address book")]
        public void GivenIAmInTheAddressBook()
        {
            page = AtddSite.GotoAddressBook();
        }

        [When(@"I quick add John Doe")]
        public void WhenIEnterTheNameJohnDoe()
        {
            page.QuickAdd("John Doe");
        }

        [Then(@"John Doe should be added to the address book")]
        public void ThenJohnDoeShouldBeAddedToTheAddressBook()
        {
            page.ContainsPersonNamed("John Doe");
        }

        [Then(@"John Doe should highlighted")]
        public void ThenJohnDoeShouldHighlighted()
        {
            page.IsPersonHighlighted("John Doe");
        }

        [Then(@"Quick add name should be cleared")]
        public void ThenQuickAddNameShouldBeCleared()
        {
            page.Title.Should().Be.Empty();
        }
    }
}

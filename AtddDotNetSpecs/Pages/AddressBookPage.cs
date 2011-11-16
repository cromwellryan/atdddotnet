using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using Should.Fluent;

namespace AtddDotNetSpecs.Pages
{
    public class AddressBookPage
    {
        private readonly IWebDriver driver;
        private readonly IFindsByCssSelector cssSelector;
        private readonly IHasInputDevices inputDevices;

        public AddressBookPage(IWebDriver driver, IFindsByCssSelector cssSelector, IHasInputDevices inputDevices)
        {
            this.driver = driver;
            this.cssSelector = cssSelector;
            this.inputDevices = inputDevices;
        }

        public string Title
        {
            get { return cssSelector.FindElementByCssSelector("#newperson #name").Text; }
        }

        public void Show()
        {
            driver.Navigate().GoToUrl("http://localhost:21985/addressbook/");
        }

        public void QuickAdd(string name)
        {
            cssSelector.FindElementByCssSelector("#newperson #name").SendKeys(name);
        }

        public void PressEnter()
        {
            inputDevices.Keyboard.PressKey(Keys.Enter);
        }

        public void ContainsPersonNamed(string name)
        {
            cssSelector.FindElementByCssSelector("#people a#" + NameAsAnchorId(name)).Should().Not.Be.Null();
        }

        public void IsPersonHighlighted(string name)
        {
            cssSelector.FindElementByCssSelector("#people a#" + NameAsAnchorId(name)).GetAttribute("class").Should().Contain("recentlyadded");
        }

        private static string NameAsAnchorId(string name)
        {
            return name.Replace(" ", "").ToLower();
        }

    }
}
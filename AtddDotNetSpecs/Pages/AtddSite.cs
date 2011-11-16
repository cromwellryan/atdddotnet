using AtddDotNetSpecs.StepDefinitions;

namespace AtddDotNetSpecs.Pages
{
    public static class AtddSite
    {

        public static AddressBookPage GotoAddressBook()
        {
            var addressBookPage = new AddressBookPage(DriverFactory.Driver, DriverFactory.CssSelector, DriverFactory.InputDevices);

            addressBookPage.Show("http://localhost:21985");
           
            return addressBookPage;
        }


        public static void Close()
        {
            DriverFactory.Driver.Close();
            DriverFactory.Driver.Dispose();
        }
    }
}
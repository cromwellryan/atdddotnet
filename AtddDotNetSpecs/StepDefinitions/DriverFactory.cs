using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Internal;

namespace AtddDotNetSpecs.StepDefinitions
{
    public class DriverFactory
    {
        private static FirefoxDriver currentWebDriver;

        public static IWebDriver Driver
        {
            get { return GetCurrentFireFox(); }
        }

        public static IFindsByCssSelector CssSelector
        {
            get { return GetCurrentFireFox(); }
        }

        public static IHasInputDevices InputDevices
        {
            get { return GetCurrentFireFox(); }
        }

        private static FirefoxDriver GetCurrentFireFox()
        {
            return currentWebDriver ?? CreateNewFirefoxDriver();
        }

        private static FirefoxDriver CreateNewFirefoxDriver()
        {
            Console.WriteLine("Creating new firefox driver");
            return (currentWebDriver = new FirefoxDriver());
        }
    }
}
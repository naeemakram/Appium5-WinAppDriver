using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using Xunit.Abstractions;

namespace Appium5WAD
{
    public class WinowsAppiumFiveTests:IDisposable
    {
        WindowsDriver? calcDriver;
        ITestOutputHelper? output;
        public WinowsAppiumFiveTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void Dispose()
        {
            if (calcDriver != null)
            {
                calcDriver.Dispose();
            }
        }

        [Fact]
        public void TestLaunchCalculator()
        {

            // pre-requisites:
            // You must have installed Appium 2.0
            // command for updating Appium is given below
            // appium driver install--source = npm appium - windows - driver
            // Command to see the list of installed appium drivers
            // appium driver list --installed
            // You must have installed appium windows driver 
            // command for appium windows driver installation

            var appiumLocalService = new AppiumServiceBuilder()
                .UsingAnyFreePort()
                .WithLogFile(new FileInfo(@"E:\logs\TestLog.txt"))
                .WithStartUpTimeOut(TimeSpan.FromSeconds(60))
                .Build();

            appiumLocalService.Start();

            // alaram = "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App"            
            
            AppiumOptions appiumOptions = new AppiumOptions();
            appiumOptions.App = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
            appiumOptions.AutomationName = "Windows";// you must specify this name
            appiumOptions.AddAdditionalAppiumOption("ms:WaitForAppLaunch", "120");            
            
            
            calcDriver = new WindowsDriver(appiumLocalService, appiumOptions);

            Assert.NotNull(calcDriver);

            // TODO: Figure out how to avoid using CSS by default
            calcDriver?.FindElement("One".XPathByName()).Click();
            calcDriver?.FindElement("Plus".XPathByName()).Click();
            calcDriver?.FindElement("One".XPathByName()).Click();
            calcDriver?.FindElement("Equals".XPathByName()).Click();

            var results = calcDriver?.FindElement("AutomationId".XPathByAttributeAndValue("CalculatorResults"));

            output?.WriteLine(results?.Text);

            Assert.True(results?.Text.Trim().EndsWith("2"));
        }

    }
}  
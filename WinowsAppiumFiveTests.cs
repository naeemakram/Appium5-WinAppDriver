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
            // You must have installed Node.JS and Appium 2.0
            // command for updating existing Appium installation is given below
            // appium driver install--source = npm appium - windows - driver
            // Command to see the list of installed appium drivers
            // appium driver list --installed
            // You must have installed appium windows driver 
            // command for appium windows driver installation
            // appium driver install --source=npm appium-windows-driver

            var appiumLocalService = new AppiumServiceBuilder()
                .UsingAnyFreePort()
                .WithLogFile(new FileInfo(@"E:\logs\TestLog.txt"))
                .WithStartUpTimeOut(TimeSpan.FromSeconds(60))
                .Build();

            appiumLocalService.Start();

            
            AppiumOptions appiumOptions = new AppiumOptions();
            appiumOptions.App = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
            appiumOptions.AutomationName = "Windows";// you must specify this name
            appiumOptions.AddAdditionalAppiumOption("ms:WaitForAppLaunch", "120");            
                        
            calcDriver = new WindowsDriver(appiumLocalService, appiumOptions);

            Assert.NotNull(calcDriver);

            // TODO: Figure out how to avoid using CSS by default
            calcDriver?.FindElement(EasyXPath.AnywhereAnythingByName(name: "One")).Click();
            calcDriver?.FindElement(EasyXPath.AnywhereAnythingByName(name: "Plus")).Click();
            calcDriver?.FindElement(EasyXPath.AnywhereAnythingByName(name: "One")).Click();
            calcDriver?.FindElement(EasyXPath.AnywhereAnythingByName(name: "Equals")).Click();

            var results = calcDriver?.FindElement(EasyXPath.AnywhereAnythingByAutomationId("CalculatorResults"));

            output?.WriteLine(results?.Text);

            Assert.True(results?.Text.Trim().EndsWith("2"));
        }

    }
}  
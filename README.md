# How to run WinAppDriver with Appium 5
---


## Pre-requisites:
* You must have installed Node.JS and Appium 2.0
* The command for updating existing Appium installation is given below
`appium driver install--source = npm appium - windows - driver `
* The command to see the list of installed appium drivers
`appium driver list --installed `
* You must have installed appium windows driver 
* The command for appium windows driver installation
`appium driver install --source=npm appium-windows-driver `


## The differnce between Appium 4 and Appium 5, how it impacts WinAppDriver automation

In the past, it was possible for your scripts to directly talk to the WinAppDriver.
But in the latest version of Appium, everything must flow through an Appium Dribver. 
In case of Windows this driver is appium-windows-driver.
The Appium Windows Driver has a separate repository on GitHub. You also need to 
install WinAppDriver on the machine where you want to run the automation.

There's one more caveat, if you use `By.Id` or `By.Name` in Appium 5 they get translated
to `By.Css` under the hood. When this happens, the WinAppDriver is unable to locate 
controls for you.
My solution to this problem is using `By.XPath` as following:
```
        public static By XPathById(this string id)
        {
            Assert.NotNull(id);
            return By.XPath($"//*[@Id='{id}']");
        }
```

These extension methods are also available herein. 
This code sample shows you how you can run WinAppDriver based automation with 
Appium 5.

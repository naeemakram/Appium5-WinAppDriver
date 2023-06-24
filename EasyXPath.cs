using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Appium5WAD
{
    public static class EasyXPath
    {
        public static By XPathById(this string id)
        {
            Assert.NotNull(id);
            return By.XPath($"//*[@Id='{id}']");
        }

        public static By AnywhereAnythingByName(this string name)
        {
            Assert.NotNull(name);
            return By.XPath($"//*[@Name='{name}']");
        }

        public static By AnywhereByIdAndTag(this string id, string tag)
        {
            Assert.NotNull(id);
            Assert.NotNull(tag);
            return By.XPath($"//{tag}[@Id='{id}']");
        }

        public static By AnywhereByNameAndTag(this string name, string tag)
        {
            Assert.NotNull(name);
            Assert.NotNull(tag);
            return By.XPath($"//{tag}[@Name='{name}']");
        }

        public static By AnythingAnywhereByAttributeAndValue(this string attribute, string value)
        {
            Assert.NotNull(attribute);
            Assert.NotNull(value);
            return By.XPath($"//*[@{attribute}='{value}']");
        }

        public static By AnythingAnywhereByClassContains(this string value)
        {
            Assert.NotNull(value);
            return By.XPath($"//*[contains(@class, '{value}')]");
        }
        public static By AnythingAnywhereByTextContains(this string value)
        {
            Assert.NotNull(value);
            return By.XPath($"//*[contains(Text(), '{value}')]");
        }

        public static By AnywhereAnythingByAutomationId(this string automationId)
        {
            Assert.NotNull(automationId);
            return By.XPath($"//*[@AutomationId='{automationId}']");
        }
    }
}

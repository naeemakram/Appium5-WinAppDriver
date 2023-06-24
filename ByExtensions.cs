using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Appium5WAD
{
    public static class ByExtensions
    {
        public static By XPathById(this string id)
        {
            Assert.NotNull(id);
            return By.XPath($"//*[@Id='{id}']");
        }

        public static By XPathByName(this string name)
        {
            Assert.NotNull(name);
            return By.XPath($"//*[@Name='{name}']");
        }

        public static By XPathByAttributeAndValue(this string attribute, string value)
        {
            Assert.NotNull(attribute);
            Assert.NotNull(value);
            return By.XPath($"//*[@{attribute}='{value}']");
        }

        public static By XPathByClassContains(this string value)
        {
            Assert.NotNull(value);
            return By.XPath($"//*[contains(@class, '{value}')]");
        }
        public static By XPathByTextContains(this string value)
        {
            Assert.NotNull(value);
            return By.XPath($"//*[contains(Text(), '{value}')]");
        }
    }
}

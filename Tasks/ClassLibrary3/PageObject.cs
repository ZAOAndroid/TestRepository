using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.Extensions;

using Microsoft.Practices.Unity;
using TestActions;

namespace PageObject
{
    public class PageObject
    {
        protected IWebDriver Webdriver;

        private IWebElement field;

        private IWebElement button;

        public PageObject(IWebDriver WebDriver)
        {
            this.Webdriver = WebDriver;
        }

        public void Open(string url)
        {
            Webdriver.Navigate().GoToUrl(url);
        }

        public void LogIn(IWebElement button)
        {
            button.Click();
        }

        public void Print(string text, IWebElement field)
        {
            field.SendKeys(text);
        }

        public string GetTitle()
        {
            return Webdriver.Title;
        }

        public IWebElement FindElementById(string id)
        {
            return Webdriver.FindElement(By.Id(id));
        }

        public IWebElement FindElementByClass(string classname)
        {
            return Webdriver.FindElement(By.ClassName(classname));
        }

        public void Wait()
        {
            Webdriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
        }

        public void Close()
        {
            Webdriver.Quit();
        }
    }
}

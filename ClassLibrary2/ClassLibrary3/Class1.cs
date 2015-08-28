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

namespace ClassLibrary3
{
    public class RegPage
    {
        protected IWebDriver Webdriver;

        private IWebElement field;

        private IWebElement button;

        public RegPage(IWebDriver WebDriver)
        {
            this.Webdriver = WebDriver;
        }

        public void Open(string url)
        {
            Webdriver.Navigate().GoToUrl("https://planeta.2gis.ru");
        }

        public void LogIn()
        {
            button.Click();
        }

        public void Print(string text)
        {
            field.SendKeys(text);
        }

        public string GetTitle()
        {
            return Webdriver.Title;
        }

        public void Close()
        {
            Webdriver.Quit();
        }
    }

    public class UserWantTologIn
    {
        private RegPage page;

        [TestFixtureSetUp]

        public void OpenPage()
        {
           // page = PageFactory.InitElements(new ChromeDriver(), (new RegPage(this.page)));
            // у меня нет RegPage.Class, не пойму почему. Нашла как написано выше, но ему тоже не нравится

            page.Open("https://planeta.2gis.ru");
        }

        [TestFixtureTearDown]

        public void ClosePage()
        {
            page.Close();
        }

        [Test]

        public void Test1()
        {
            Assert.IsTrue(page.GetTitle()=="Вход на сайт / Планета 2ГИС");
        }
    }
}

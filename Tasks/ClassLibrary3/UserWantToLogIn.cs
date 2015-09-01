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
    public class UserWantTologIn
    {
        PageObject page = new PageObject(new ChromeDriver());

        [TestFixtureSetUp]

        public void OpenPage()
        {
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
            page.Print("a.zykova", page.FindElementById("login"));

            page.Print("123", page.FindElementById("password"));

            page.LogIn(page.FindElementByClass("input_submit"));

            page.Wait();

            Assert.IsTrue(page.FindElementById("login").GetAttribute("value") == "a.zykova");

            Assert.IsTrue(page.GetTitle() == "Вход на сайт / Планета 2ГИС");

            Assert.IsTrue(page.FindElementById("password").GetAttribute("value") == "123");
        }
    }
}

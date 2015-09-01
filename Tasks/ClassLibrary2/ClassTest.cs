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
using ClassLibrary2;

namespace ClassLibrary2
{
    public class ClassTest
    {
        protected OpenQA.Selenium.IWebDriver Driver { get; set; }

        [TestFixtureSetUp]

        public void BeforeClass()
        {
            Driver = new ChromeDriver();

            Driver.Navigate().GoToUrl("https://planeta.2gis.ru");
        }

        [TestFixtureTearDown]

        public void AfterClass()
        {
            Driver.Quit();
        }
    }
}

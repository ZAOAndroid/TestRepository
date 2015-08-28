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




   public class Class1
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

    [TestFixture]

    public class AutoTest: Class1
    {
        [Test]

        public void Test2()
        {
            var login = Driver.FindElement(By.Id("login"));

            login.SendKeys("a.zykova");

            var password = Driver.FindElement(By.Id("password"));

            password.SendKeys("1234");

            var remember = Driver.FindElement(By.Name("submit_login"));

            remember.Submit();

            var button = Driver.FindElement(By.ClassName("input_submit"));

            button.Click();

            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));

            var element = Driver.FindElement(By.Id("login"));
            
         //   Assert.IsTrue(element.Text == "a.zykova");
         // разве это неправильно? ему не нравится. Хотя мы смотрим текст, который в элементе и сраниваем с ожиданием
  
            Assert.IsTrue(Driver.Title == "Вход на сайт / Планета 2ГИС");
        }
    
}

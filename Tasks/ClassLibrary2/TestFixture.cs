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

[TestFixture]

public class AutoTest : ClassTest
{
    [Test]

    public void TestFailPassword()
    {
        // Залогинились
        var login = Driver.FindElement(By.Id("login"));

        login.SendKeys("a.zykova");

        var password = Driver.FindElement(By.Id("password"));

        password.SendKeys("123");

        // запоминание логина, ставим галку
        var remember = Driver.FindElement(By.Name("submit_login"));

        remember.Submit();

        // жмем войти
        var button = Driver.FindElement(By.ClassName("input_submit"));

        button.Click();

        Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));

        //проверим, вернулся ли он на начальную страницу оставив логн тот же, т.к. пароль неккоректный
        // а если ввести корректно, то тестыупадут
        var element = Driver.FindElement(By.Id("login")).GetAttribute("value");

        Assert.IsTrue(element == "a.zykova");

        Assert.IsTrue(Driver.Title == "Вход на сайт / Планета 2ГИС");
    }
}

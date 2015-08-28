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

namespace ClassLibrary1
{
    public interface IUser
    {
        string UserName { get; }

        string Password { get; }
    }

    public class TestUser1 : IUser
    {
        public string UserName { get { return "User";} }

        public string Password { get { return "123";} }
    }

    public class TestUser2 : IUser
    {
        public string UserName { get { return "a.zykova";} }

        public string Password { get { return "...";} } // здесь пробовала со своим паролем
    }

    public class LogOut
    {
        private  IWebElement button;
        
        public void Exit()
        {
            // Здесь он бы искал кнопку и кликал
            button.Click();
        }
    }

    [SetUpFixture]

    public class TestsSetUp
    {
        public static UserTestAction<IUser> UserTestAction { get; set; }

        [SetUp]

        public void RunBeforeAnyTests()
        {
            UserTestAction = new UserTestAction<IUser>();

            UserTestAction.RegisterUser<IUser>();
        }
    }

    public class Test
    {
        [Test]

        public void Test1()
        {
            var action = TestsSetUp.UserTestAction;

            action.RegisterUser<TestUser1>();

            action.SetCurrentUser<TestUser1>();

            Assert.Pass();
        }

        public void Test2()
        {
            var action = TestsSetUp.UserTestAction;

            action.RegisterUser<TestUser1>();

            action.SetCurrentUser<TestUser1>();

            // Выйдем из аккаунта
            action.Resolve<LogOut>();

            // Надо проверить, что нет текущего пользователя, но GetUser - не то
        }
    }

}

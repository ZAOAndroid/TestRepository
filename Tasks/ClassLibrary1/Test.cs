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

namespace Action
{
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

        [Test]

        public void Test2()
        {
            var action = TestsSetUp.UserTestAction;

            action.RegisterUser<TestUser1>();

            action.SetCurrentUser<TestUser1>();

            Assert.IsTrue(action.GetUser().UserName == "User");
        }
    }
}

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
}

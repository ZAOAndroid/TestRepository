using System;
using System.Security.Cryptography.X509Certificates;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace UnitTestProject2
{
    [TestFixture]

    public class TestForDB
    {
        [SetUp]

        public void SetUp()
        {

        }

        [TearDown]

        public void TearDown()
        {

        }

        [Test]
        [TestCase(1, 2, 1234, 1, "name")]
        [TestCase(54, 3, 441234, 1, "Anothername")]
        public void Test1 (int branch, int id, long syncode, int statustype, string name)
        {
            using (var dbContext = new TestDBEntities())
            {
                var newCard = new Cards();
                {
                    newCard.BranchId = branch;
                    newCard.Id = id;
                    newCard.SynCode = syncode;
                    newCard.StatusTypeId = statustype;
                    newCard.Name = name;
                };

                newCard.Contacts.Add(new Contacts() { ContactTypeId = 2, Value = "123@123.ru" });

                dbContext.Cards.Add(newCard);

                dbContext.SaveChanges();

                Assert.AreEqual((from m in dbContext.Cards select m.Name).ToList().Last(), newCard.Name);
            }
        }
    }
}

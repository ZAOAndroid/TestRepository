using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // Создание карточку и прочитать ее
        [TestMethod]

        public void MakeAndLoad()
        {
            using (var dbContext = new TestDBEntities())
            {
                var newCard = new Cards();
                {
                    newCard.BranchId = 1;
                    newCard.Id = 2;
                    newCard.SynCode = 12345;
                    newCard.StatusTypeId = 1;
                    newCard.Name = "Name";
                };

                newCard.Contacts.Add(new Contacts() { ContactTypeId = 2, Value = "123@123.ru" });

                dbContext.Cards.Add(newCard);
                
                dbContext.SaveChanges();

                Assert.AreEqual((from m in dbContext.Cards select m.Name).ToList().Last(), newCard.Name);
            }
        }
    }
}

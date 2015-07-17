using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Linq;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;



namespace UnitTestProject1
{

    [TestClass]
    public class UnitTest1
    {

        //Создать карту для всех тестов
        private Card card;
        [TestInitialize()]
        public void myTestInitialize()
        {
            card = new Card();
            card.Name = "Name";
            card.Id = 1;
            card.ProjectId = 1;
            card.SynCode = 1;
        }

        //Тест на клонирование карты
        [TestMethod]
        public void ClonningTest()
        {
            myTestInitialize();

            Card clone = (Card)card.Clone();

            Assert.AreEqual(card.Name, clone.Name);
            Assert.AreNotEqual(card.Id, clone.Id);
        }

        //Сравнение контактов
        [TestMethod]
        public void CompareContactsTest()
        {
            NumbContact contact1 = new NumbContact();
            contact1.contact = "123";
            contact1.parametr = "321";

            NumbContact contact2 = new NumbContact();
            contact1.contact = "123";
            contact1.parametr = "321";

            Assert.AreEqual(contact1.CompareTo(contact2), 2);
        }

        //Тест на сравнение карточек
        [TestMethod]
        public void CompareToTest()
        {
            myTestInitialize();

            Card card2 = new Card();
            card2.Name = "Name";
            card2.Id = 2;
            card2.ProjectId = 1;
            card2.SynCode = 1;

            int a = card.CompareTo(card2);
            Assert.AreEqual(a, 0);
        }

        //Дбавление и удаление контакта
        [TestMethod]
        public void AddDelContactTest()
        {

            MailContact Mail = new MailContact();
            Mail.contact = "aaa";
            Mail.parametr = "bbb";

            card.AddContact(Mail);

            Assert.IsNotNull(card);
            Assert.IsNotNull(card.readContact());

            card.DelContact();
            card.k = false;

            string[] lines = new string[1] { null };

            Assert.AreEqual(card.readContact().ToString(), lines.ToString());
        }

        //Верно считывает контакты и корректно преобразует контакт в формат toString
        [TestMethod]
        public void readTest()
        {
            MailContact Mail = new MailContact();
            Mail.contact = "aaa";
            Mail.parametr = "bbb";

            card.AddContact(Mail);

            string[] lines = new string[1] { "aaa_bbb" };

            Assert.AreEqual(card.readContact().ToString(), lines.ToString());
        }

        // сортировка
        [TestMethod]
        public void SortMailTest()
        {
            MailContact contact1 = new MailContact();
            contact1.contact = "mail.рф";
            contact1.parametr = "second name";
            MailContact contact2 = new MailContact();
            contact2.contact = "mail";
            contact2.parametr = "second name";

            string[] lines = new string[1] { "mail.рф_second name" };

            Assert.AreEqual(card.toLINQMailContact().ToString(), lines.ToString());
        }

       /* [TestMethod]
        public void xmlTest()
        {
            Assert.IsNotNull(card.toXml());
          //  XElement x = new XElement("Name", new XAttribute("Id", Id), new XAttribute("Name", Name), new XAttribute("IdOfProject", ProjectId), new XAttribute("SysCode", SynCode));
        }*/

    }
}


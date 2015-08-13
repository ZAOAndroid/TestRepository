using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string k = "";

            while (k != "4")
            {

                Console.WriteLine("Choose one of this" + "\n" + "1 - Write cards from DB" + "\n" +
                                  "2 - Load card to DB from XML" + "\n" + "3 - Add card" + "\n" + "4 - Exit");

                k = Console.ReadLine();
                switch (k)
                {
                    case "1":
                        WriteCardsFromDB();
                        break;
                    case "2":
                        LoadCardFromXML();
                        break;
                    case "3":
                        AddCard();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Try again" + "\n");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
                Console.ReadKey();
            }

            Console.ReadLine();
        }


        // Получение сожержимого БД
        private static void WriteCardsFromDB()
        {
            using (var dbContext = new TestDBEntities())
            {
                foreach (var card in dbContext.Cards)
                {
                    Console.WriteLine("Card Id: {0}, Name: {1}", card.Id, card.Name);
                    foreach (var contact in card.Contacts)
                    {
                        Console.WriteLine("\tContact Id: {0}, Name: {1}", contact.Id, contact.Value);
                    }
                    Console.WriteLine();
                }
            }
        }

        // Загрузка карты из файла
        private static void LoadCardFromXML()
        {
            using (var dbContext = new TestDBEntities())
            {
                // read xml-file
                XDocument xdoc = XDocument.Load(@"D:\Репозиторий\TestRepository\Realization\Realization\bin\Debug\xml");
                Console.WriteLine(xdoc);

                int newId = Convert.ToInt32(xdoc.Element("Name").Attribute("Id").Value);
                bool boolID = false;

                foreach (var card in dbContext.Cards)
                {
                         // если разные Id, то создаем новый
                    if (card.Id != newId)
                    {
                        boolID = true;
                    }
                        // если равые Id, то обновляем поля
                    else 
                    {
                        card.BranchId = Convert.ToUInt32(xdoc.Element("Name").Attribute("BranchId").Value);
                        card.Id = Convert.ToInt32(xdoc.Element("Name").Attribute("Id").Value);
                        card.SynCode = Convert.ToInt64(xdoc.Element("Name").Attribute("SynCode").Value);
                        card.StatusTypeId = Convert.ToInt32(xdoc.Element("Name").Attribute("StatusTypeId").Value);
                        card.Name = xdoc.Element("Name").Attribute("Name").Value;
                    }
                }

                if (boolID)
                {
                    var newCard = new Cards();
                    {
                        newCard.BranchId = Convert.ToUInt32(xdoc.Element("Name").Attribute("BranchId").Value);
                        newCard.Id = Convert.ToInt32(xdoc.Element("Name").Attribute("Id").Value);
                        newCard.SynCode = Convert.ToInt64(xdoc.Element("Name").Attribute("SynCode").Value);
                        newCard.StatusTypeId = Convert.ToInt32(xdoc.Element("Name").Attribute("StatusTypeId").Value);
                        newCard.Name = xdoc.Element("Name").Attribute("Name").Value;
                    };

                    newCard.Contacts.Add(new Contacts() { ContactTypeId = 2, Value = "123@123.ru" });

                    dbContext.Cards.Add(newCard);

                    dbContext.SaveChanges();
                }
            }
        }


        // Добавление карты
        private static void AddCard()
        {
            using (var dbContext = new TestDBEntities())
            {
                var newCard = new Cards();
                {
                    newCard.BranchId = 54;
                    newCard.Id = 2;
                    newCard.SynCode = 123456789;
                    newCard.StatusTypeId = 1;
                    newCard.Name = "Name of the place";
                };

                newCard.Contacts.Add(new Contacts() { ContactTypeId = 2, Value = "123@123.ru" });

                dbContext.Cards.Add(newCard);

                dbContext.SaveChanges();
            }
        }

        // work with contacts

    }
}


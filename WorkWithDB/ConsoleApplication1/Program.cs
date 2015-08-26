using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            while (k != "5")
            {

                Console.WriteLine("Choose one of this" + "\n" + "1 - Write cards from DB" + "\n" +
                                  "2 - Load card to DB from XML" + "\n" + "3 - Add card" + "\n" + "4 - Refresh contacts" + "\n" + "5 - Make xml-file" + "\n" + "6 - Exit");

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
                        CheckContacts();
                        break;
                    case "6":
                        break;
                    case "5":
                        MakeXmlfromDB();
                        break;
                    case "7":
                        xmlfile();
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

                Console.WriteLine((from m in dbContext.Cards select m.Name).ToList().Last());

            }
        }

        // make an xml file
        // ToDo: сделать короче, добавить один метод, а в нем по условию есть или нет XElement c контактом
        private static void MakeXmlfromDB()
        {
            using (var dbContext = new TestDBEntities())
            {
                var cardForWork = dbContext.Cards.First();

                if (cardForWork.Contacts.Any())
                {

                    XDocument XDoc = new XDocument(
                        new XElement("Body",
                            new XElement("Name",
                                new XAttribute("Id", cardForWork.Id),
                                new XAttribute("Name", cardForWork.Name),
                                new XAttribute("BranchId", cardForWork.BranchId),
                                new XAttribute("SynCode", cardForWork.SynCode),
                                new XAttribute("StatusTypeId", cardForWork.StatusTypeId)),

                            new XElement("Contacts",
                                new XAttribute("Id", cardForWork.Contacts.First().Id),
                                new XAttribute("Value", cardForWork.Contacts.First().Value))
                            )
                        );

                    XDoc.Save("xmlfromDB");
                    Console.WriteLine(XDoc);
                }

                else
                {
                    XDocument XDoc = new XDocument(
                        new XElement("Body",
                            new XElement("Name",
                                new XAttribute("Id", cardForWork.Id),
                                new XAttribute("Name", cardForWork.Name),
                                new XAttribute("BranchId", cardForWork.BranchId),
                                new XAttribute("SynCode", cardForWork.SynCode),
                                new XAttribute("StatusTypeId", cardForWork.StatusTypeId))

                            )
                            )
                        ;

                    XDoc.Save("xmlfromDB");
                    Console.WriteLine(XDoc);
                }
            }
        }


        // Загрузка карты из файла
        private static void LoadCardFromXML()
        {
            using (var dbContext = new TestDBEntities())
            {
                // read xml-file

                XDocument xdoc = XDocument.Load(@"D:\Репозиторий\TestRepository\WorkWithDB\ConsoleApplication1\bin\Debug\xmlfromDB");
                Console.WriteLine(xdoc);

                int newId = Convert.ToInt32(xdoc.Element("Body").Element("Name").Attribute("Id").Value);
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
                        card.BranchId = Convert.ToUInt32(xdoc.Element("Body").Element("Name").Attribute("BranchId").Value);
                        card.Id = Convert.ToInt32(xdoc.Element("Body").Element("Name").Attribute("Id").Value);
                        card.SynCode = Convert.ToInt64(xdoc.Element("Body").Element("Name").Attribute("SynCode").Value);
                        card.StatusTypeId = Convert.ToInt32(xdoc.Element("Body").Element("Name").Attribute("StatusTypeId").Value);
                        card.Name = xdoc.Element("Body").Element("Name").Attribute("Name").Value;
                    }
                }

                if (boolID)
                {
                    var newCard = new Cards();
                    {
                        newCard.BranchId = Convert.ToUInt32(xdoc.Element("Body").Element("Name").Attribute("BranchId").Value);
                        newCard.Id = Convert.ToInt32(xdoc.Element("Body").Element("Name").Attribute("Id").Value);
                        newCard.SynCode = Convert.ToInt64(xdoc.Element("Body").Element("Name").Attribute("SynCode").Value);
                        newCard.StatusTypeId = Convert.ToInt32(xdoc.Element("Body").Element("Name").Attribute("StatusTypeId").Value);
                        newCard.Name = xdoc.Element("Body").Element("Name").Attribute("Name").Value;
                    };

                    newCard.Contacts.Add(new Contacts() { ContactTypeId = 2, Value = "123@123.ru" });

                    dbContext.Cards.Add(newCard);

                    dbContext.SaveChanges();
                }
            }
        }


        // Добавление карты
        // Ввела какие-то значения, но по сути можно сделать ввод с консоли и рандомно
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
        // ToDo: I want to make column isDeleted, and contacts will stay in table anyway, but now only delete
        public static void CheckContacts()
        {
            using (var dbContext = new TestDBEntities())
            {
                // Repeat reading from the xml-file
                XDocument xdoc = XDocument.Load(@"D:\Репозиторий\TestRepository\WorkWithDB\ConsoleApplication1\bin\Debug\xmlfromDB");
                Console.WriteLine(xdoc);

                int newId = Convert.ToInt32(xdoc.Element("Body").Element("Name").Attribute("Id").Value);

                foreach (var card in dbContext.Cards)
                {
                    if ((card.Id == newId) & (xdoc.Element("Body").FirstNode != xdoc.Element("Body").LastNode))
                    {
                        string valueContact = xdoc.Element("Body").Element("Contacts").Attribute("Value").Value;

                        foreach (var contacts in card.Contacts)
                        {
                            card.Contacts.First().Value = valueContact;
                            Console.WriteLine("Contacte were refreshed");
                        }
                    }

                    else
                    {
                        // it can delete first. Should delete the one u want

                        if (card.Contacts.Count == 0)
                        {
                            Console.WriteLine("There is no contact");
                        }

                        else
                        {
                            if (card.Id == newId)
                            {
                                Console.WriteLine(card.Contacts.Count); //Это для проверки было, пусть будет

                                var cardwithcontacts = dbContext.Cards.First(c => c.Contacts.Any());

                                card.Contacts.Remove(dbContext.Contacts.First());

                                dbContext.Contacts.Remove(dbContext.Contacts.First());

                                //    cardwithcontacts.Contacts.ToList().RemoveAll(c => c.CardId == cardwithcontacts.Id);


                                Console.WriteLine("All contatcts were deleted");
                            }

                            else
                            {
                                // if card with another Id
                                Console.WriteLine("Don't touch this card");
                            }
                        }
                    }
                }
                dbContext.SaveChanges();
            }
        }
    }
}


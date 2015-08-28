using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ConsoleApplication2
{
    using HttpRequestHelper;
    using ServiceReference1;
    using Newtonsoft.Json;
    using TestActions;

    class Program
    {
         
        public class RequestCountContact
        {
            public string Count { get; set; }
        }

        public class RequestAddContact
        {
            public string Name { get; set; }

            public string Phone { get; set; }
        }

        public class RequestGetContacts
        {
            public string Count { get; set; }

            public string Name { get; set; }

            public string Phone { get; set; }
        }

        static void Main(string[] args)
        {
            // Хватаем количество

            var requestCount = new GetRequest("http://uk-autoqa01/wsc-test/ContactsService/service.asmx/GetCount");

            string r1 = requestCount.GetResponse().StringData();

            string count = JsonConvert.DeserializeObject<RequestCountContact>(r1).Count;

            int countOfContacts = Convert.ToInt32(count);

            // Регаем юзера

            var requestContact = new GetRequest("http://uk-autoqa01/wsc-test/ContactsService/service.asmx/AddContact?Name=Человек&Phone=113");

            string r2 = requestContact.GetResponse().StringData();

            // Запрашиваем новое количество контактов

            var requestCount2 = new GetRequest("http://uk-autoqa01/wsc-test/ContactsService/service.asmx/GetCount");

            string r3 = requestCount2.GetResponse().StringData();

            string NewCount = JsonConvert.DeserializeObject<RequestCountContact>(r3).Count;

            // Проверим, что количество изменилось. Здесь стоит делать не +1, а сам факт изменения, а то вдруг кто параллельно регает

            Assert.IsTrue(Convert.ToInt32(NewCount) == countOfContacts + 1);

            // Проверим, что контакт добавился правильно
            // Запросим все контакты и посмотрим есть ли там то, что мы добавили. 
            // Проверила на номере, имя надо преобразовта, а чет не могу конвертировать в нормальный юникод

            var requestContacts = new GetRequest("http://uk-autoqa01/wsc-test/ContactsService/service.asmx/GetContacts?Count=45");

            string r4 = requestContacts.GetResponse().StringData().Normalize();

            Assert.IsTrue(r4.Split(' ', '{', '}', '"', ':').Contains("113"));

            Console.WriteLine("Ok");

            Console.ReadLine();
        }
    }
}


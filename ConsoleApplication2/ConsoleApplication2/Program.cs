using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using HttpRequestHelper;

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
            public string count { get; set; }
        }

        public class RequestAddContact
        {
            public string name { get; set; }

            public string phone {get;set;}
        }

        public class RequestGetContacts
        {
            public string count {get;set;}
        }

        static void Main(string[] args)
        {
            // Проверка количества контактов

            var requestCount = new GetRequest("http://uk-autoqa01/wsc-test/ContactsService/service.asmx/GetCount");

            string r1 = requestCount.GetResponse().StringData();

            string count = JsonConvert.DeserializeObject<RequestCountContact>(r1).count;

            try
            {
                Assert.AreEqual("20", count);

                Console.WriteLine(count);
            }
            catch (Exception e) // AssertFailedException() надо найти
            {
                Console.WriteLine("Получено некорректное значение");
            }

            //Проверка получения контакта

            
            var requestAdd = new GetRequest("http://uk-autoqa01/wsc-test/ContactsService/service.asmx/AddContact") ;
            var requestAdd2 = new GetRequest("http://uk-autoqa01/wsc-test/ContactsService/service.asmx?op=AddContact");

            string r2 = requestAdd.GetResponse().StringData();
            string r22 = requestAdd2.GetResponse().StringData();

            
            Console.WriteLine(r2.ToString());

            JsonConvert.DeserializeObject<RequestAddContact>(r24).name = "777";

            Newtonsoft.Json.Linq.JObject.Parse(r22);


         //   Console.WriteLine(name);

            Console.ReadLine();
        }
    }
}


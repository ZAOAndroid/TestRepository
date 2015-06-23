using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
    
        //консолюшка вся
        static void Main(string[] args)
        {
            //создали
            data.Card card = new data.Card("text", 12345, 12345, "");
            //запишем значения
            Console.WriteLine("Новое название карты");
            card.setname(Console.ReadLine());
            Console.WriteLine("Новый Id");
            card.setId((long)Convert.ToInt64(Console.ReadLine()));
            Console.WriteLine("Новый код");
            card.Code = Convert.ToInt64( Console.ReadLine());
            //Значение карточки
            Console.WriteLine("Значение карточки:"+" "+card.getname() + " " + card.getId()+" "+card.Code.ToString());
            //список контактов
            Console.WriteLine("Для создания контакта с номером введите - 1, для почты - 2");
            string k="";
            
            //варианты событий
                while (k != "4")
                {
                    card.setV(Console.ReadLine());
                    k = card.getV();
                    switch (k)
                    { 
                        case "1":
                            card.MakeContacts();
                            break;
                        case "2":
                            card.MakeContacts();
                            break;
                        case "5":
                            card.Wr();
                            break;
                        case "6":
                            card.Del();
                            break;
                    }
                }

               
            

            
            Console.ReadLine();
        }
    }
}
// новый проект
namespace data
{
    //класс карточки
    class Card
    {
        string V;
        private string Name;
        private long SynCode, ProjectId;
        public Card(string name, long synCode, long projectId, string v)
        {
            Name = name;
            SynCode = synCode;
            ProjectId = projectId;
            V = v;
        }
        public long getId()
        {
            return ProjectId;
        }
        public string getname()
        {
            return Name;
        }
        public string setname(string valueN)
        { 
            Name = valueN;
            return Name;
        }
        public long setId(long valueId)
        {
            ProjectId = valueId;
            return ProjectId;
        }
        //другим способом
        public long Code
        {
            get { return SynCode; }
            set { SynCode = value; }
        }
        public string setV(string valueV)
        {
            V = valueV;
            return V;
        }
        public string getV()
        { return V; }

        //методы для карточек
        //добавление записи
        //вооот так должно быть наверн

        private static List<Contacts> conta;
        public  void MakeContacts()
        {
            conta = new List<Contacts>();
            
            if (V == "1")
            {
                var nn = new NumbContact("", "");
                conta.Add(nn);
                Console.WriteLine("Введите имя");
                nn.cont = Console.ReadLine();
                Console.WriteLine("Введите номер");
                nn.number = Console.ReadLine();
            }
            if (V == "2")
            {
                var nn = new MailContact ("", "");
                conta.Add(nn);
                Console.WriteLine("Введите имя");
                nn.cont = Console.ReadLine();
                Console.WriteLine("Введите номер");
                nn.mail = Console.ReadLine();
                Console.WriteLine("Введите псевдоним");
                nn.Alias = Console.ReadLine();
            }
        }
        //вывод контакта
        public  void Wr()
        {
            foreach (Contacts ccc in conta)
                Console.WriteLine(ccc.Name+"_"+ccc.ToString());
        }
        //думала, что вот так удаление, но чет не
        public void Del()
        {
            foreach (Contacts ccc in conta)
            {

                conta.Remove(ccc);
                
            }
        }
 
       
    }
    //базовый класс для контактов
    class Contacts
    {
        public string cont;
        public Contacts(string cont)
        {
            this.cont = cont;
        }
        public string Name
        {
            get { return cont; }
        }
    }
    //дочки для телефонов и почты
    class NumbContact : Contacts
    {
        //добавили доп переменнную для телефона
        public string number;
        public NumbContact(string number, string cont)
            : base(cont)
        {
            this.number = number;
        }
        //переопределила метод toString 
        //код города наверно нужно подбирать для определенного города, хм
        public override string ToString()
        {
            return "383 " + number;
        }
    }
    class MailContact : Contacts
    {
        public string mail;
        public MailContact(string mail, string cont)
            : base(cont)
        {
            this.mail = mail;
        }
        public string alias;
        public string Alias
        {
            get { return alias; }
            set { alias = value; }
        }
        public override string ToString()
        {
            return mail + "_" + alias;
        }

    }
}


using System.Collections.Generic;
using System;
using System.Xml.Linq;
using System.IO;
using System.Linq;


namespace Data
{
    public abstract class Contact:IComparable<Contact>
    {
        //поле, которое наследуют
        public string contact { get; set; }
        public virtual string parametr { get; set; }

        public int count = 0;
        public bool dubl {get;set;}
        public int CompareTo(Contact pers)
        {
            //здесь внутри должно быть сравнение по 2м параметрам
            //сделала parametr тоже как общий
            Contact temp = (Contact)pers;
            if /*(*/(this.contact == temp.contact)/*&&(this.parametr==temp.parametr))*/
            { count = 1; }
            else
            { count = 0; }
            return count;
        }

        public virtual XElement toXml()
        {
            XElement x = new XElement("Name",contact);
           // x.Save("x.xml");
            return x;
        }
    }
}

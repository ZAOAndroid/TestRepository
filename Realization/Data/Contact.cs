
using System.Collections.Generic;
using System;
using System.Xml.Linq;
using System.IO;
using System.Linq;


namespace Data
{
    public abstract class Contact : IComparable<Contact>
    {
        //поле, которое наследуют
        public string contact { get; set; }
        public virtual string parametr { get; set; }

        //     public bool dubl { get; set; }
        public int CompareTo(Contact pers)
        {
            //здесь внутри должно быть сравнение по 2м параметрам
            //сделала parametr тоже как общий
            Contact temp = (Contact)pers;
            return Math.Abs(this.contact.CompareTo(temp.contact)) + Math.Abs( this.parametr.CompareTo(temp.parametr));

        }

        public virtual XDocument/*XElement*/ toXml()
        {
            XElement x = new XElement("Name", contact);
          //  return x;

            XDocument XDoc = new XDocument();
            XDoc.Add(x);
            return XDoc;
        }
    }
}

﻿
using System.Collections.Generic;
using System;
using System.Xml;
using System.Configuration;
using System.Xml.XmlConfiguration;
using System.Linq;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Data
{
    public class MailContact : Contact
    {
          // public string Alias { get; set; }
        public override string ToString()
        {
              //   return contact + "_" + Alias;
            return contact + "_" + parametr;
        }

        public override  /*XElement*/ XDocument toXml()
        {
            XElement x = new XElement("Name", new XAttribute("Mail", contact), /*Alias*/ new XAttribute("Alias", parametr));
            //  return base.toXml();
          //  return x;
            XDocument XDoc = new XDocument();
            XDoc.Add(x);
            return XDoc;
        }

      /*  public int CompareTo(MailContact other)
        {
            if (base.CompareTo(other) == 0)
            {
                return Alias.CompareTo(other);
            }

            return base.CompareTo(other);
        }*/

    }
}

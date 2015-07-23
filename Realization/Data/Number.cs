
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
    public class NumbContact : Contact
    {
        // public string Code { get; set; }

        public override string ToString()
        {
            return /*Code*/parametr + " " + contact;
        }

        public override System.Xml.Linq.XDocument toXml()
        {
            XElement x = new XElement("Name", new XAttribute("Number", contact),/*Code*/new XAttribute("Code", parametr));
            // return base.toXml();
           // return x;
            XDocument XDoc = new XDocument();
            XDoc.Add(x);
            return XDoc;
        }

    }
}

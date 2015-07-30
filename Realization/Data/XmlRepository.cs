using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    public class XmlRepository<TItem> where TItem :  IXmlSerializable
    {
        public void Save(TItem item)
        {
            if (item != null)
                item.SaveToXml();
        }

        // За XDocument принимаем введенную 2ю карточку
        public void Load(TItem item, TItem item2)
        {
          //  XDocument XDoc = XDocument.Load("x1");
          //  Console.WriteLine( XDoc.ToString());
            
            if (item != null)
               // item.LoadFromXml(XDoc);
                item.LoadFromXml(item2.SaveToXml());
            
        }
    }
}

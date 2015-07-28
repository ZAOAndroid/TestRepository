using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    class XmlRepository<TItem> where TItem : System.Xml.Serialization.IXmlSerializable, IXmlSerializable
    {
        public void Save(TItem item)
        {
            if (item != null)
                item.SaveToXml();
        }

        public void Load(TItem item)
        {
            //if (item != null)
         //   item.LoadFromXml(XDocument.Load());
        }
    }
}

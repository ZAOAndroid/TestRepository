using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    public class XmlRepository<TItem> where TItem :  IXmlSerializable, new() 
    {
        public void Save(TItem item)
        {
            if (item != null)
                item.SaveToXml();
        }

        public TItem Load(XDocument XDoc)
        {
                var newItem = new TItem();
                newItem.LoadFromXml(XDoc);
                return newItem;
        }
    }
}

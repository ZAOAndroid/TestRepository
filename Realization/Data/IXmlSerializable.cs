using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    public interface IXmlSerializable
    {
        XDocument SaveToXml();

        void LoadFromXml(XDocument XDoc);
    }
}
  
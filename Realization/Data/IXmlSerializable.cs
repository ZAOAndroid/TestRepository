using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    interface IXmlSerializable
    {
        XDocument SaveToXml();

        object LoadFromXml(XDocument XDoc);
    }
}

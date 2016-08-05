using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace DynamicXml
{
    class DynamicXElement: DynamicObject
    {
        private readonly XElement _element;

        private DynamicXElement(XElement element)
        {
            _element = element;
        }

        public static dynamic Create(XElement element)
        {
            return new DynamicXElement(element);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var element = _element.Element(binder.Name);
            if (element != null)
            {
                result = new DynamicXElement(element);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes.Length == 2)
            {
                var stringVal = indexes[0];
                var intVal = indexes[1];
                if (stringVal is string && intVal is int)
                {
                    IEnumerable<XElement> xElements = _element.Elements();
                    //What if xElements is empty?
                    result = new DynamicXElement(xElements.ElementAt((int) intVal));
                    return true;
                }
                else
                {
                    result = null;
                    return false;
                }
            }
            else
            {
                result = null;
                return false;
            }
        }

        public override string ToString()
        {
            return _element.Value;
        }
    }
}

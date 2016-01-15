using System.Collections.Generic;

namespace SeeSomeCode
{
    public static class ElementDictionary
    {
        public static List<DictionaryElement> Elements { get; private set; } = new List<DictionaryElement>();
        static ElementDictionary()
        {
			Elements.Add(new DictionaryElement() { ElementName = "FooName", ValidationName = "ValidationA" });
        }
        public class DictionaryElement
        {
            public string ElementName { get; set; }
            public string ValidationName { get; set; }
        }
    }
}
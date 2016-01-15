using System.Collections.Generic;
// GENERATED CODE - SEE SEEMODEL.1.TT FOR DISCUSSION
namespace SeeSomeCode
{
    public static class ElementDictionary
    {
        public static List<DictionaryElement> Elements { get; private set; } = new List<DictionaryElement>();
        static ElementDictionary()
        {
			Elements.Add(new DictionaryElement() { ElementName = "FooName", ValidationName = "ValidationA" });
			Elements.Add(new DictionaryElement() { ElementName = "DtoId", ValidationName = "ValidationD" });
        }
        public class DictionaryElement
        {
            public string ElementName { get; set; }
            public string ValidationName { get; set; }
        }
    }
}
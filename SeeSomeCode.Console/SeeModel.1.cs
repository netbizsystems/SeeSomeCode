using System.Collections.Generic;
// GENERATED CODE - SEE SEEMODEL.1.TT FOR DISCUSSION
namespace SeeSomeCode
{
    /// <summary>
    /// ElementDictionary - provides global list of elements => validation mapping
    /// </summary>
    public static class ElementDictionary
    {
        public static List<DictionaryElement> Elements { get; private set; } = new List<DictionaryElement>();
        static ElementDictionary()
        {
			Elements.Add(new DictionaryElement() { ElementName = "DtoId", ValidationName = "ValidationD" });
			Elements.Add(new DictionaryElement() { ElementName = "FooName", ValidationName = "ValidationA" });
        }
        public class DictionaryElement
        {
            public string ElementName { get; set; }
            public string ValidationName { get; set; }
        }
    }
}
using System.Collections.Generic;

namespace SeeCodeNow
{
    public static class FooDictionary
    {
        public static List<Foo> Elements { get; private set; } = new List<Foo>();
        static FooDictionary()
        {
			Elements.Add(new Foo() { ElementName = "FooName", ValidationName = "ValidationA" });
        }
        public class Foo
        {
            public string ElementName { get; set; }
            public string ValidationName { get; set; }
        }
    }
}

namespace SeeSomeCode.T4Depends
{
    public class SampleDto
    {
        public int DomainId { get; set; }

        [DictionaryElement("FooName")]
        public string DomainString { get; set; }
    }
}

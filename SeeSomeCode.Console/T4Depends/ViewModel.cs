
namespace SeeSomeCode
{
    /// <summary>
    /// ViewModel - with builtin validation
    /// </summary>
    /// <remarks>
    /// Any DictionaryElement attributes seen below will be processed BEFORE the API method is called. If the model fails
    /// validation, based on the validationmaster, the mothod will not be called at all and a response with error details will be returned.
    /// </remarks>
    public class ViewModel
    {
        public int ViewModelId { get; set; }

        [DictionaryElement("FooName")]
        public string ViewModelString { get; set; }
    }
}

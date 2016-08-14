
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace SeeSomeCode.T4Depends
{
    /// <summary>
    /// DictionaryElementAttribute - validate element against validation set
    /// </summary>
    public class DictionaryElementAttribute : ValidationAttribute
    {
        private string ValidationName { get; set; }
        private string ElementName { get; set; }

        /// <summary>
        /// ElementValidationAttribute - constructor
        /// </summary>
        /// <param name="elementName"></param>
        public DictionaryElementAttribute( string elementName )
        {
            ElementName = elementName;
            var el = ElementDictionary.Elements.Find( e => e.ElementName == elementName );
            if (el != null)
            {
                ValidationName = el.ValidationName;
            }
            else
            {
                ValidationName = string.Empty; //throw new ApplicationException( $"element [{elementName}] not found in elementDictionary" );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid( object value )
        {
            var property = typeof(ValidationMaster)
                .GetMembers()
                .Where(prop => IsDefined((MemberInfo) prop, typeof(ValidationAttribute)))
                .FirstOrDefault(prop => prop.Name == ValidationName);

            if (property != null)
                foreach (ValidationAttribute va in property.GetCustomAttributes(typeof(ValidationAttribute), true))
                {
                    if (!va.IsValid(value))
                    {
                        return false; // bail out on first error
                    }
                }

            return true; // all is well
        }
    }
}
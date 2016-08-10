
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SeeSomeCode
{
    /// <summary>
    /// ValidationMaster - global repository of ALL useful validation patterns
    /// </summary>
    /// <remarks>
    /// Model properties can be marked with the MasterValidationAttribute (see below) which will
    /// cause that property to be validated against the rules found in the cooresponding property 
    /// in this class.  This allows well defined validations to be reused everywhere.  Also,
    /// allows for change with minor disruption.  Also, very testable!
    /// </remarks>
    public static class ValidationMaster
    {
        /// <summary>
        /// ValidationA - note that each property can have several validation attributes
        /// </summary>
        [MinLength(1, ErrorMessageResourceName = @"validation.errors.ValidationA")]
        [MaxLength(100, ErrorMessageResourceName = @"validation.errors.ValidationA")]
        public static string ValidationA { get; set; }

        [StringLength(2)]
        [RegularExpression(@"(ma|nh|vt)", ErrorMessageResourceName = @"validation.errors.ValidationB")]
        public static string ValidationB { get; set; }

        [StringLength(100, ErrorMessageResourceName = @"validation.errors.ValidationC")]
        public static string ValidationC { get; set; }

        [Range(1,100, ErrorMessageResourceName = @"validation.errors.ValidationD")]
        public static int ValidationD { get; set; }
    }

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
                throw new ApplicationException( $"element [{elementName}] not found in elementDictionary" );
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
                .Where(prop => IsDefined(prop, typeof(ValidationAttribute)))
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

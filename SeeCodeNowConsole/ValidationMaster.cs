
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SeeCodeNow
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
        [Required]
        [StringLength(100, ErrorMessage = "ValidationA failed")]
        public static string ValidationA { get; set; }

        [StringLength(2)]
        [RegularExpression(@"(ma|nh|vt)", ErrorMessageResourceName = "validation.errors.validationb")]
        public static string ValidationB { get; set; }

        [StringLength(3)]
        public static string ValidationC { get; set; }
    }

    public class MasterValidationAttribute : ValidationAttribute
    {
        private string _validationname { get; set; }

        public MasterValidationAttribute( string validationName )
        {
            _validationname = validationName;
        }
        public override bool IsValid( object value )
        {
            return ValidateAgainstMaster(value);
        }

        private bool ValidateAgainstMaster(object value)
        {
            var property = typeof(ValidationMaster)
                .GetMembers()
                .Where( prop => IsDefined( prop, typeof( ValidationAttribute )) )
                .Where( prop => prop.Name == _validationname )
                .FirstOrDefault();

            foreach ( ValidationAttribute va in property.GetCustomAttributes( typeof(ValidationAttribute), true ) )
            {
                if (!va.IsValid(value))
                {
                    return false;
                }
            };

            return true; // all is well
        }
    }
}

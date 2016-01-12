
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SeeCodeNow
{
    public static class ValidationMaster
    {
        [Required]
        [StringLength(1, ErrorMessage = "ValidationA failed")]
        public static string ValidationA { get; set; }
        [StringLength(2)]
        public static string ValidationB { get; set; }
        [StringLength(3)]
        public static string ValidationC { get; set; }
    }

    public class MasterValidationAttribute : ValidationAttribute
    {
        public MasterValidationAttribute(string validationName)
        {

        }
        public override bool IsValid( object value )
        {
            return ValidateAgainstMaster(value);
        }

        private bool ValidateAgainstMaster(object value)
        {
            var property = typeof(ValidationMaster)
                .GetMembers()
                .Where(prop => IsDefined( prop, typeof( ValidationAttribute )))
                .Where(prop => prop.Name == "ValidationA")
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

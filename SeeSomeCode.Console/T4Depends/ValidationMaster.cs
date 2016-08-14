using System.ComponentModel.DataAnnotations;

namespace SeeSomeCode.T4Depends
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
        [MaxLength(25, ErrorMessageResourceName = @"validation.errors.ValidationA")]
        public static string ValidationA { get; set; }

        [StringLength(2)]
        [RegularExpression(@"(ma|nh|vt)", ErrorMessageResourceName = @"validation.errors.ValidationB")]
        public static string ValidationB { get; set; }

        [StringLength(100, ErrorMessageResourceName = @"validation.errors.ValidationC")]
        public static string ValidationC { get; set; }

        [Range(1,100, ErrorMessageResourceName = @"validation.errors.ValidationD")]
        public static int ValidationD { get; set; }
    }
}

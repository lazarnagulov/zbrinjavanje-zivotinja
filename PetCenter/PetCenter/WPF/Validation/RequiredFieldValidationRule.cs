using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PetCenter.WPF.Validation
{
    public class RequiredFieldValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            => string.IsNullOrEmpty((string)value) ? 
                new ValidationResult(false, "Required field") : 
                ValidationResult.ValidResult;
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PetCenter.WPF.Validation
{
    public class EmailValidationRule : ValidationRule
    {
        private static bool IsValidEmail(string email)
        {
            const string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo) 
            => IsValidEmail((string)value) ? 
                ValidationResult.ValidResult :
                new ValidationResult(false, "Email format is not valid.");
    }
}

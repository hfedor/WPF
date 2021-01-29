using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Controls;
using System.Text;

namespace WPF.Validation
{
    // walidacja tytułu utworu
    public class ValidateTitle : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureinfo)
        {
            Debug.Print(value.ToString());
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult(false, "Nie podano nazy utworu!");
            else if (value.ToString().Length < 3)
                return new ValidationResult(false, "Zbyt krótka nazwa utworu!");
            else
                return ValidationResult.ValidResult;
        }
    }

    // walidacja wykonawcy
    public class ValidateArtist : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureinfo)
        {
            Debug.Print(value.ToString());
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult(false, "Nie podano wykonawcy!");
            else if (value.ToString().Length < 3)
                return new ValidationResult(false, "Zbyt krótka nazwa wykonawcy!");
            else
                return ValidationResult.ValidResult;
        }
    }

    // walidacja gatunku
    public class ValidateGenre : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureinfo)
        {
            Debug.Print(value.ToString());
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult(false, "Nie podano gatunku muzycznego!");
            else if (value.ToString().Length < 3)
                return new ValidationResult(false, "Zbyt krótka nazwa gatunku muzycznego!");
            else
                return ValidationResult.ValidResult;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Estimates.Validation
{
    class StringValidation : ValidationRule
    {
        private int min=2;
        public int Min
        {
            get { return min; }
            set { min = value; }
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Length>Min)
            {
            return new ValidationResult(true, null);          
            }
            else
            {
                return new ValidationResult(false, "Количество символов меньше двух");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Estimates.Validation
{
    class IntValidation : ValidationRule
    {
        private int min=0;
        private int max;
        public int Max
        {
            get { return max; }
            set { max = value; }
        }
        public int Min
        {
            get { return min; }
            set { min = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int param;
            if(Int32.TryParse(value.ToString(),out param))
            {
                if ((param < Min) || (param > Max))
                {
                    return new ValidationResult(false,"Пожалуйста, введите в указанном диапазоне: " + Min + " - " + Max + ".");
                }
                else
                {
                    return new ValidationResult(true, null);  
                }
            }
            else
            {
                return new ValidationResult(false, "Неверный формат ввода");
            }
            
        }
    }
}

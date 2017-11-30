using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Estimates.Validation
{
    public class MetricsValidation : ValidationRule
    {
        private float _min = 0;
        private float _max = 100;
        public float Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public float Max
        {
            get { return _max; }
            set { _max = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            float param = 0;
            Regex reg = new Regex(@"^\d+[\.]?\d{0,3}$");

            string str = value.ToString();
            if (reg.IsMatch(str))
            {
                str = str.Replace(".", ",");
                param = float.Parse(str);
                if ((param <= Min) || (param > Max))
                {
                    return new ValidationResult(false,
                      "Пожалуйста, введите в указанном диапазоне: " + Min + " - " + Max + ".");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            else
            {
                return new ValidationResult(false, "Недопустимые символы ");

            }





        }
    }
}

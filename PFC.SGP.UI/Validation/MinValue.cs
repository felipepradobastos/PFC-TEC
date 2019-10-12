using System.ComponentModel.DataAnnotations;

namespace PFC.SGP.UI.Validation
{
    public class MinValue : ValidationAttribute
    {
        private readonly int _minValue;

        public MinValue(int minValue)
        {
            _minValue = minValue;
        }

        public override bool IsValid(object value)
        {
            try
            {
                return (int)value >= _minValue;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PFC.SGP.UI.Validation
{
    public class LongMinValue : ValidationAttribute
    {
        private readonly long _minValue;

        public LongMinValue(long minValue)
        {
            _minValue = minValue;
        }

        public override bool IsValid(object value)
        {
            try
            {
                return (long)value >= _minValue;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}

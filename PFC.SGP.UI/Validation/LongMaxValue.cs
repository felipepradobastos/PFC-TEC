using System.ComponentModel.DataAnnotations;

namespace PFC.SGP.UI.Validation
{
    public class LongMaxValue : ValidationAttribute
    {
        private readonly long _maxValue;

        public LongMaxValue(long maxValue)
        {
            _maxValue = maxValue;
        }

        public override bool IsValid(object value)
        {
            return (long)value <= _maxValue;
        }
    }
}

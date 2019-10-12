using System.ComponentModel.DataAnnotations;

namespace PFC.SGP.UI.Validation
{
    public class MaxValue : ValidationAttribute
    {
        private readonly int _maxValue;

        public MaxValue(int maxValue)
        {
            _maxValue = maxValue;
        }

        public override bool IsValid(object value)
        {
            return (int)value <= _maxValue;
        }
    }
}

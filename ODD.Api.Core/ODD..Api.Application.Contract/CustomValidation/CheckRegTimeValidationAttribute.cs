using ODD.Api.Common.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ODD.Api.Core.CustomValidation
{
    public class CheckRegTimeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var val = (string)value;
            if (PersianTool.PersionTimeValidation(val))
            {
                return true;
            }
            return false;

        }
        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }
    }
}
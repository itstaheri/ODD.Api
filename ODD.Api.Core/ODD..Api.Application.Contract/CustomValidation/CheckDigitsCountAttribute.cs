using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Application.Contract.CustomValidation
{
    public class CheckDigitsCountAttribute : ValidationAttribute
    {
        private int MaxDigit;
        public CheckDigitsCountAttribute(int maxDigit)
        {
            MaxDigit = maxDigit;

        }
        public override bool IsValid(object value)
        {
            var val = Convert.ToInt64(value);
            if (val.ToString().Length <= MaxDigit)
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

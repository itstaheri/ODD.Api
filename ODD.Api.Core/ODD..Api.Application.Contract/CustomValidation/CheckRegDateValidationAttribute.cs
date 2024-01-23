using ODD.Api.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ODD.Api.Application.Contract.CustomValidation
{

    public class CheckRegDateValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var val = (string)value;
            if (PersianTool.PersionDateValidation(val))
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
using Microsoft.AspNetCore.Mvc;

namespace ODD.Api.Infrastructure.Utility.Helpers.SecurityHelper
{
    public static class TSqlSecurityHelper
    {
        /// <summary>
        /// Check parameters for forbidden charachters
        /// </summary>
        /// <param name="entery"></param>
        /// <returns></returns>
        public static  TSqlSecurityResult TSqlChecker(string entery, string forbiddenCharacters)
        {

            string[] lines = forbiddenCharacters.ToString().Split(',').ToArray();
            foreach (var item in lines)
            {
                if (entery.ToUpper().Contains($" {item.ToUpper()} ")) return new TSqlSecurityResult { Character = item, IsForbidden = true };
            }
            return new TSqlSecurityResult { IsForbidden = false };
        }
    }
}

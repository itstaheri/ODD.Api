namespace ODD.Api.Infrastructure.Utility.Helpers.SecurityHelper
{
    public class TSqlSecurityException : Exception
    {
        public TSqlSecurityException(string character) : base($"Expression {character} is a forbidden expression") 
        {

        }
    }
}

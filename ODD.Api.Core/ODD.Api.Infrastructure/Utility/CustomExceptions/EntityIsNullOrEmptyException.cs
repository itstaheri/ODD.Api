namespace ODD.Api.Infrastructure.Utility.CustomExceptions
{
    public class EntityIsNullOrEmptyException : Exception
    {
        public EntityIsNullOrEmptyException(object key) : base($"{key} returned null!")
        {
            
        }
    }
}

namespace Tasks.Api.Core.Exceptions
{
    public class EmptyGuidException : Exception
    {
        public EmptyGuidException(string message)
            : base(message)
        {

        }
    }
}

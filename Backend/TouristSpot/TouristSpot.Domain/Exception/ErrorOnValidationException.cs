namespace TouristSpot.Domain.Exception
{
    public class ErrorOnValidationException : BaseException
    {
        public List<string> ErrorsMessages { get; set; }
        public ErrorOnValidationException(List<string> errorsMessages) => ErrorsMessages = errorsMessages;
    }
}

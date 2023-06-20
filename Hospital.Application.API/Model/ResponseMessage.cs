namespace Hospital.Application.API.Model
{
    public class ResponseMessage
    {
        public string Message { get; set; } = "";
        public string MessageError { get; set; } = "";
        public bool Success { get; set; } = false;
        public object Object { get; set; } = null;
    }
}

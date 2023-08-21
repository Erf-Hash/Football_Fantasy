namespace FootBall_Fantasy.Business.ResponseClass
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Response() { }
        public Response(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}

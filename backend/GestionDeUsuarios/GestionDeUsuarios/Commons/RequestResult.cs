namespace GestionDeUsuarios.Commons
{
    public class RequestResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }

        public static RequestResult Unauthorized = new RequestResult
        {
            Message = "Unauthorized"
        };
    }
}

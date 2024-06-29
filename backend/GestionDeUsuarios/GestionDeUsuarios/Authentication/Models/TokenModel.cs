
namespace Commons.Authentication.Token
{
    public class TokenModel
    {
        public int Id { set; get; }
        public string Username { get; set; }
        public string Token { get; set; }
        public TimeSpan Duration { get; set; }
        public int DurationNumber { get; set; }
        public string UserEmitionDate { get; set; }
        public string ServerEmitionDate { get; set; }
    }
}

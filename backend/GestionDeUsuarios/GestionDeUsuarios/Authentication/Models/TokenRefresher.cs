

namespace GestionDeUsuarios.Authentication.Models
{
    public class TokenRefresher
    {
        public string OldToken { get; set; }
        public string  NewToken { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime Emmited { get; set; }
    }
}

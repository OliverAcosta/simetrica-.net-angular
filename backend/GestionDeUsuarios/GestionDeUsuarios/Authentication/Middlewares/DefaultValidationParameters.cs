using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GestionDeUsuarios.Authentication.Middlewares
{
    public class DefaultValidationParameters
    {
        public bool ValidateIssuerSigningKey { get; set; }
        public string SymmetricSecurityKey { get; set; } = "kUl7uGLjgma4zYIJ9pfuu5lLKT9Y8MovjdPETAY0HTw3z1PW9bmot02RmKQprtwDD78978444465";
        public bool ValidateIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public bool SaveToken { get; set; } = true;
        public bool RequireHttpsMetadata { get; set; }
        public TimeSpan TokenDuration { get; set; } = new TimeSpan(0, 45, 0);
        public TimeSpan ClockSkew { get; set; } = new TimeSpan(0, 0, 0);

        public TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SymmetricSecurityKey)),
                ValidateIssuer = ValidateIssuer,
                ValidateAudience = ValidateAudience,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = ClockSkew,
            };
        }
    }
}


using Commons.Authentication.Token;
using GestionDeUsuarios.Authentication.Constants;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace Commons.Webapi.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<JwtMiddleware> logger;
        public static SymmetricSecurityKey SSK = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("kUl7uGLjgma4zYIJ9pfuu5lLKT9Y8MovjdPETAY0HTw3z1PW9bmot02RmKQprtwDD78978444465"));
        public JwtMiddleware(RequestDelegate next, ILogger<JwtMiddleware> _logger)
        {
            _next = next;
            logger = _logger;
            TokenUtility.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers[AuthConsts.AUTH_TOKEN].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, token);
            await _next(context);
        }

        private void attachUserToContext(HttpContext context, string token)
        {
           TokenUtility.ValidateToken(context, token);
        }
    }
}
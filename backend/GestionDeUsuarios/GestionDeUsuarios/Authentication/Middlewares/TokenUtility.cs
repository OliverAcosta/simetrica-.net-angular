using Commons.Webapi.Middlewares;
using DatabaseManager.Auth.Models;
using GestionDeUsuarios.Authentication.Constants;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using GestionDeUsuarios.Authentication.Middlewares;
using DatabaseManager.Entities;
using GestionDeUsuarios.Authentication;

namespace Commons.Authentication.Token
{
    public class TokenUtility
    {

        public static ILogger<JwtMiddleware> logger;
        public static DefaultValidationParameters validationParameter = new DefaultValidationParameters();
        public static TokenValidationParameters TokenValidationParameters = validationParameter.GetTokenValidationParameters();
        public static async Task<TokenModel> CreateToken(Users user, DateTime usertime)
        {
            var rolesClaims = LoginHelper.GetClaims();
            var listClaims = new List<Claim>
            {
                new Claim("Id",user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var creds = new SigningCredentials(TokenUtility.TokenValidationParameters.IssuerSigningKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenHandler = new JwtSecurityTokenHandler();
            listClaims.AddRange(rolesClaims);
            DateTime serverDate = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(listClaims),
                NotBefore = serverDate,
                Expires = serverDate.Add(TokenUtility.validationParameter.TokenDuration),
                SigningCredentials = creds,
                IssuedAt = serverDate,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenModel
            {
                Id = user.Id,
                Username = user.Username,
                Token = tokenHandler.WriteToken(token),
                Duration = TokenUtility.validationParameter.TokenDuration,
                DurationNumber = (int)TokenUtility.validationParameter.TokenDuration.TotalMinutes,
                UserEmitionDate = usertime.ToString("yyyy-MM-dd HH:mm:ss"),
                ServerEmitionDate = serverDate.ToString("yyyy-MM-dd HH:mm:ss")
            };
        }

        public static void ValidateToken(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, TokenUtility.TokenValidationParameters, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "Id").Value);
                var name = jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Name).Value;
                var email = jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Email).Value;
                var roles = string.Join(',', jwtToken.Claims.Where(x => x.Type == "role").Select(x => x.Value));

                // attach user to context on successful jwt validation
                context.Items[AuthConsts.USERS] = new AppUser { Id = userId, UserName = name, Email = email };
                context.Items[AuthConsts.ROLES] = roles;
            }
            catch (Exception ex) { }
        
        }

        public static async Task<TokenModel> RefreshToken(string token, DateTime usertime)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, TokenUtility.TokenValidationParameters, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "Id").Value);
                var name = jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Name).Value;
                var email = jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Email).Value;
                return await CreateToken(new Users { Id = userId, Username = name, Email = email }, usertime);

            }
            catch (Exception ex)
            {
               
                return null;
            }
        }

    }
}

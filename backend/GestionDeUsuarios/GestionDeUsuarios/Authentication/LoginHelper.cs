using DatabaseManager.ContextEntities;
using DatabaseManager.Entities;
using GestionDeUsuarios.Authentication.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionDeUsuarios.Authentication
{
    public class LoginHelper
    {
        protected readonly GestionDataContext db;
        private static string secretKey = "$#DFSecretKey";
        public LoginHelper(GestionDataContext db)
        {
            this.db = db;
        }
        public Users Login(UserModel model)
        {
           string password = Convert.ToBase64String(Encoding.UTF8.GetBytes(secretKey + model.Password));
           return db.Users.Where(m => m.Username == model.Username && m.Password == password).FirstOrDefault();
        }


        public bool changePassword(PasswordChange pass)
        {
            string current = Convert.ToBase64String(Encoding.UTF8.GetBytes(secretKey + pass.Password));
            var user = db.Users.Where(m => m.Username ==  pass.Username && m.Password == pass.Password).FirstOrDefault();
            if (user == null || string.IsNullOrWhiteSpace(pass.NewPassword)) return false;
            user.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(secretKey + pass.NewPassword));
            db.Users.Update(user);
            db.SaveChanges();
            return true;
        }

        public static List<string> GetRoles()
        {
            return new List<string>();
        }

        public static List<Claim> GetClaims()
        {
            return GetRoles().Select(m => new Claim(ClaimTypes.Role, m)).ToList();
        }
    }
}

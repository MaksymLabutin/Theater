using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Theater.WebApi.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "TheaterServer"; // издатель токена
        public const string AUDIENCE = "TheaterClient"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
        public const int LIFETIME = 20; // время жизни токена - 20 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}

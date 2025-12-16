using BCryptNet = BCrypt.Net.BCrypt;
using ClienteAPI_Database.Data.Interface;

namespace ClienteAPI_Database.Data.Services
{
    public class HashingServices:IHashingService
    {
        public string HashPassword(string Password)
        {
            return BCryptNet.HashPassword(Password);
        }
        public bool VerifyPassword(string Password,string PasswordHashing)
        {
            return BCryptNet.Verify(Password, PasswordHashing);
        }
    }
}
//BCrypt.Net.SaltParseException: 'Invalid salt version'
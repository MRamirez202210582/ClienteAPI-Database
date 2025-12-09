namespace ClienteAPI_Database.Data.Interface
{
    public interface IHashingService
    {
        string HashPassword(string Password);

        bool VerifyPassword(string Password, string PasswordHashing);

    }
}

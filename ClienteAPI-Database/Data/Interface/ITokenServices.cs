using ClienteAPI_Database.Model;

namespace ClienteAPI_Database.Data.Interface
{
    public interface ITokenServices
    {
        string GenerateToken (Usuario usuario);

        Task<int?> ValidateToken (string token);
    }
}

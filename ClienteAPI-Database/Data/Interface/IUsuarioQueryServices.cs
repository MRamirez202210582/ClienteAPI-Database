using ClienteAPI_Database.Model;

namespace ClienteAPI_Database.Data.Interface
{
    public interface IUsuarioQueryServices
    {
        List<Usuario> GetAll();
    }
}

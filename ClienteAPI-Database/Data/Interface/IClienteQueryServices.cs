using ClienteAPI_Database.Model;

namespace ClienteAPI_Database.Data.Interface
{
    public interface IClienteQueryServices
    {
        public List<Cliente> GetCliente();
        public void GetClienteById();
    }
}

using ClienteAPI_Database.Data.Interface;
using ClienteAPI_Database.Model;

namespace ClienteAPI_Database.Data.Services
{
    public class ClienteQueryServices:IClienteQueryServices
    {
        public readonly AppDbContext dbContext;

        public ClienteQueryServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Cliente> GetCliente()
        {
            return dbContext.Cliente.ToList();
        }
        public void GetClienteById()
        {

        }
    }
}

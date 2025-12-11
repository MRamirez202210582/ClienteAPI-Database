using ClienteAPI_Database.Data.Interface;
using ClienteAPI_Database.Model;

namespace ClienteAPI_Database.Data.Services
{
    public class UsuarioQueryServices:IUsuarioQueryServices
    {
        public readonly AppDbContext dbContext;

        public UsuarioQueryServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Usuario> GetAll()
        {
            return dbContext.Usuario.ToList();
        }
    }
}

using ClienteAPI_Database.Data.Interface;
using ClienteAPI_Database.Model;

namespace ClienteAPI_Database.Data.Services
{
    public class UsuarioCommandServices:IUsuarioCommandServices
    {
        public readonly AppDbContext dbContext;
        public readonly IHashingService hashingService;
        public UsuarioCommandServices(AppDbContext dbContext,IHashingService hashingService)
        {
            this.dbContext = dbContext;
            this.hashingService = hashingService;
        }

        public void InsertUsuario(string correo, string contrasena)
        {
            var usuario = new Usuario {correo=correo,contrasena=hashingService.HashPassword(contrasena) };
            dbContext.Add(usuario);
            dbContext.SaveChanges();
        }
    }
}

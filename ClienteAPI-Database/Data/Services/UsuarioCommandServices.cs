using ClienteAPI_Database.Data.Interface;
using ClienteAPI_Database.Model;

namespace ClienteAPI_Database.Data.Services
{
    public class UsuarioCommandServices:IUsuarioCommandServices
    {
        public readonly AppDbContext dbContext;
        public UsuarioCommandServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void InsertUsuario(string correo, string contrasena)
        {
            var usuario = new Usuario {correo=correo,contrasena=contrasena };
            dbContext.Add(usuario);
            dbContext.SaveChanges();
        }
    }
}

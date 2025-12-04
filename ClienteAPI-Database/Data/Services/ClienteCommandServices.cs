using ClienteAPI_Database.Data.Interface;
using ClienteAPI_Database.Model;

namespace ClienteAPI_Database.Data.Services
{
    public class ClienteCommandServices : IClienteCommandServices
    {
        public readonly AppDbContext dbContext;

        public ClienteCommandServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void InsertCliente(string nombreCliente, string apellidoCliente, int edad, string direccion, string pais, string ciudad, int telefono, string correo, int DNI)
        {
            var cliente = new Cliente {nombreCliente = nombreCliente, apellidoCliente = apellidoCliente, edad = edad, direccion = direccion, pais = pais, ciudad = ciudad, telefono = telefono, correo = correo, DNI = DNI };
            dbContext.Add(cliente);
            dbContext.SaveChanges();
        }
        public void EditCliente(int clienteId, string nombreCliente, string apellidoCliente, int edad, string direccion, string pais, string ciudad, int telefono, string correo, int DNI)
        {
            var cliente = dbContext.Cliente.Find(clienteId);
            if (cliente != null )
            {
                cliente.nombreCliente=nombreCliente;
                cliente.apellidoCliente=apellidoCliente;
                cliente.edad = edad;
                cliente.direccion = direccion;
                cliente.pais = pais;
                cliente.ciudad = ciudad;
                cliente.telefono = telefono;
                cliente.correo = correo;
                cliente.DNI = DNI;

                dbContext.SaveChanges();
            }
        }
        public void DeleteCliente(int clienteId)
        {
            var cliente = dbContext.Cliente.First(c => c.clienteId == clienteId);
            dbContext.Remove(clienteId);
            dbContext.SaveChanges();
        }
    }
}

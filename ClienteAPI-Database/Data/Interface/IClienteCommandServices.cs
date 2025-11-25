namespace ClienteAPI_Database.Data.Interface
{
    public interface IClienteCommandServices
    {
        public void InsertCliente(string nombreCliente, string apellidoCliente, int edad, string direccion, string pais, string ciudad, int telefono, string correo, int DNI);
        public void EditCliente(int clienteId, string nombreCliente, string apellidoCliente, int edad, string direccion, string pais, string ciudad, int telefono, string correo, int DNI);
        public void DeleteCliente(int clienteId);
    }
}

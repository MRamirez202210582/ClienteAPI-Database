namespace ClienteAPI_Database.Data.Resources
{
    public record class CreateCliente(string nombreCliente, string apellidoCliente, int edad, string direccion, string pais, string ciudad, int telefono, string correo, int DNI);
}

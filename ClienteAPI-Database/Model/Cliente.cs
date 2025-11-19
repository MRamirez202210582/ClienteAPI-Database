namespace ClienteAPI_Database.Model
{
    public class Cliente
    {
        public int clienteId {  get; set; }
        public string nombreCliente { get; set;}
        public string direccion {  get; set; }
        public string pais {  get; set; }
        public int numeroCelular { get; set; }
        public string correo { get; set; }
        public int DNI {  get; set; }
    }
}

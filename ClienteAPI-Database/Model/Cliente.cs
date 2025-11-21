using System.ComponentModel.DataAnnotations;

namespace ClienteAPI_Database.Model
{
    public class Cliente
    {
        [Key]
        public int clienteId {  get; set; }
        public string nombreCliente { get; set;}
        public string apellidoCliente { get; set;}
        public int edad {  get; set;}
        public string direccion {  get; set; }
        public string pais {  get; set; }
        public string ciudad {get; set;}
        public int telefono { get; set; }
        public string correo { get; set; }
        public int DNI {  get; set; }

    }
}

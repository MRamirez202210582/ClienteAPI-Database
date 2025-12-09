using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace ClienteAPI_Database.Model
{
    public class Usuario
    {
        [Key]
        public int usuarioId {  get; set; }
        public string correo {  get; set; }
        public string contrasena { get; set; }
    }
}

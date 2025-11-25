using ClienteAPI_Database.Data.Interface;
using ClienteAPI_Database.Data.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI_Database.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClienteController(IClienteCommandServices clienteCommandServices , IClienteQueryServices clienteQueryServices) : Controller
    {
        [HttpPost]
        public IActionResult InsertarCliente(CreateCliente createCliente)
        {
            clienteCommandServices.InsertCliente(createCliente.nombreCliente, createCliente.apellidoCliente,createCliente.edad,createCliente.direccion,createCliente.pais,createCliente.ciudad,createCliente.telefono,createCliente.correo,createCliente.DNI);
            return View();

        }

        [HttpGet]
        public IActionResult GetCliente()
        {

        }
    }
}

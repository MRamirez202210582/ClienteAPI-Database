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
            clienteQueryServices.GetCliente();
            return View();
        }

        [HttpPatch]
        public IActionResult EditarCliente(EditarCliente editarCliente)
        {
            clienteCommandServices.EditCliente(editarCliente.clienteId, editarCliente.nombreCliente, editarCliente.apellidoCliente, editarCliente.edad, editarCliente.direccion, editarCliente.pais, editarCliente.ciudad, editarCliente.telefono, editarCliente.correo, editarCliente.DNI);
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteCliente(int clienteId)
        {
            clienteCommandServices.DeleteCliente(clienteId);
            return View();
        }
    }
}

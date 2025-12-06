using ClienteAPI_Database.Data.Interface;
using ClienteAPI_Database.Data.Resources;
using ClienteAPI_Database.Data.Token.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI_Database.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsuarioController(IHashingService hashingService,IClienteCommandServices clienteCommandServices,IClienteQueryServices clienteQueryServices,ITokenServices tokenServices) : Controller
    {
        public IActionResult LogIn() {

        }

        public IActionResult Register(CreateCliente createCliente)
        {

        }
    }
}

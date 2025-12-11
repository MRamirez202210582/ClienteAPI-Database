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
    public class UsuarioController(IHashingService hashingService,IUsuarioCommandServices usuarioCommandServices,IUsuarioQueryServices usuarioQueryServices,ITokenServices tokenServices) : Controller
    {
        [HttpPost("LogIn")]
        public IActionResult LogIn(LoginResource loginResource) {
            var usuario=usuarioQueryServices.GetAll().FirstOrDefault(u => u.correo == loginResource.correo);
            if(usuario == null)
            {
                return Unauthorized(new {Message="UsuarioInvalido"});
            }

            if (!hashingService.VerifyPassword(loginResource.contrasena, usuario.contrasena))
            {
                return Unauthorized();
            }
            var token = tokenServices.GenerateToken(usuario);
            return Ok(new { token=token});

        }

        [HttpPost("SignIn")]
        public IActionResult Register(SignInResource signInResource)
        {
            var usuario = usuarioQueryServices.GetAll().FirstOrDefault(u => u.correo == signInResource.correo);
            if (usuario == null)
            {
                return Unauthorized(new { Message = "UsuarioInvalido" });
            }
            string contrasenaEncriptada=hashingService.HashPassword(signInResource.contrasena);
            usuarioCommandServices.InsertUsuario(signInResource.correo, signInResource.contrasena);
            return Ok();
        }
    }
}

using ClienteAPI_Database.Data.Interface;
using ClienteAPI_Database.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClienteAPI_Database.Data.Token.JWT
{
    public class TokenService(IOptions<TokenSettings> tokenSettings):ITokenServices
    {
        private readonly TokenSettings _tokenSettings = tokenSettings.Value;

        public string GenerateToken(Cliente cliente)
        {
            var key=Encoding.ASCII.GetBytes(_tokenSettings.Secretkey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Sid,cliente.clienteId.ToString()),
                    new Claim(ClaimTypes.Name,cliente.correo),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler=new JwtSecurityTokenHandler();
            var token=tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<int?> ValidateToken(string token)
        {
            if(string.IsNullOrEmpty(token)) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key =Encoding.ASCII.GetBytes(_tokenSettings.Secretkey);

            try
            {
                var tokenValidationResult = await tokenHandler.ValidateTokenAsync(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey=new SymmetricSecurityKey(key),
                    ValidateIssuer =false,
                    ValidateAudience =false,
                    ClockSkew = TimeSpan.Zero
                });
                if (!tokenValidationResult.IsValid)
                    return null;

                var jwtToken = (JsonWebToken)tokenValidationResult.SecurityToken;
                var userIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid);

                return userIdClaim != null ? int.Parse(userIdClaim.Value) : null;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }



    }
}

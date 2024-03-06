using challange_disney.Data;
using challange_disney.DTO.User;
using challange_disney.Models;
using challange_disney.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace challange_disney.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly Context _context;
        private readonly IConfiguration _config;
        public AuthService(Context context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public string Register(UserRegisterDTO User)
        {
            if (string.IsNullOrEmpty(User.Email))
            {
                return "Ingrese un usuario";
            }
            User user = _context.Users.FirstOrDefault(x => x.Email == User.Email);
            if (user != null)
            {
                return "Usuario existente";
            }
            _context.Users.Add(new User()
            {
                Email = User.Email,
                Name = User.Name,
                Password = User.Password

            }
                );
            _context.SaveChanges();
            string response = GetToken(_context.Users.OrderBy(x => x.Id).Last());
            return response;

        }
        public string Login(UserInfo User)
        {
            User user = _context.Users.FirstOrDefault(x => x.Email == User.Email && x.Password == User.Password);
            if (user == null)
            {
                return string.Empty; 
            }
            return GetToken(user);
        }
        private string GetToken(User user)
        {
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["JWT:secretKey"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

            var signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            //Los claims son datos en clave->valor que nos permite guardar data del usuario.
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
            claimsForToken.Add(new Claim("username", user.Name));

            var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
                _config["JWT:Issuer"],
                _config["JWT:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signature);

            string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return tokenToReturn;
        }


    }
}

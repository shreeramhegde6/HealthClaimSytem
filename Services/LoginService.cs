using HealthClaimApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaimApp.Services
{
    public class LoginService : ILoginService
    {


        HealthclaimAppContext db;
        private IConfiguration _config;
        public LoginService(IConfiguration config, HealthclaimAppContext _db)
        {
            _config = config;
            db = _db;
        }
        public async Task<string> Login(TblLogin user, bool Isregister)
        {
            try
            {
                var userdata = AuthenticateUser(user, Isregister);
                if (user != null)
                {
                    var tokenString = GenerateToken(userdata);
                    return tokenString;
                }
                else
                {
                    return "Invalid data";
                }
            }
            catch (Exception ex)
            {
                return "Something went wrong";
            }

        }

        public TblLogin AuthenticateUser(TblLogin login, bool IsRegister)
        {
            if (IsRegister)
            {
                db.TblLogins.Add(login);
                db.SaveChanges();
                Random rnd = new Random();
                if (login.UserRole.ToString() == "Member")
                {
                    TblMember member = new TblMember();
                    

                    member.FirstName = login.FirstName;
                    member.LastName = login.LastName;
                    member.Address = login.Address;
                    member.City = login.City;
                    member.Email = login.Email;
                    member.DateOfBirth = login.DateOfBirth;
                    member.State = login.State;
                    member.PhysicianId = rnd.Next(1, 10);
                    member.UserId = login.Id;
                    member.CreatedBy = login.UserName;
                    member.CreatedDate = DateTime.Now;
                    member.ModifiedBy = login.UserName;
                    member.ModifiedDate = DateTime.Now;

                    db.TblMembers.Add(member);
                    db.SaveChanges();
                }
                return login;
            }
            else
            {
                if (db.TblLogins.Any(x => x.Email == login.UserName && x.Password == login.Password))
                {
                    return db.TblLogins.Where(x => x.Email == login.UserName && x.Password == login.Password).FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }

        }

        public string GenerateToken(TblLogin login)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, login.UserName),
                    new Claim(ClaimTypes.Role, login.UserRole),
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString( login.Id))
                }),
                Expires = DateTime.Now.AddMinutes(120),
                SigningCredentials = credentials
            };
            var TokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = TokenHandler.CreateToken(token);
            return TokenHandler.WriteToken(tokenGenerated).ToString();
        }


        public async Task<string> Register(TblLogin user, bool Isregister)
        {
            try
            {
                var userdata = AuthenticateUser(user, Isregister);
                if (user != null)
                {
                    var tokenString = GenerateToken(userdata);
                    return tokenString;


                }
                else
                {
                    return "Invalid data";
                }
            }
            catch (Exception ex)
            {
                return "Something went wrong";
            }
        }
    }
}

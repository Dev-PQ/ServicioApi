using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioApi.BusinessObjects.Seguridad
{
    public class UserLogin
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";

        public UserLogin() { }
        public UserLogin(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}

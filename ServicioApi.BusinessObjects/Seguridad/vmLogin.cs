using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioApi.BusinessObjects.Seguridad
{
    public class vmLogin
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordContrasena { get; set; }
        public string MessageFailed { get; set; }
        public vmLogin() { }
        public vmLogin( String login,String password, string passwordContrasena, string messageFailed)
        {
            Login = login;
            Password = password;
            PasswordContrasena = passwordContrasena;
            MessageFailed = messageFailed;
        }
    }
}

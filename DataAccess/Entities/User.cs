using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string nombreUsuario { get; set; }
        public string claveUsuario { get; set; }
        public string tipoUsuario { get; set; }

        public User() { }

        public User(int idUser, string nombreUser, string claveUser, string tipoUser)
        {
            Id= idUser;
            nombreUsuario = nombreUser;
            claveUsuario = claveUser;
            tipoUsuario = tipoUser;
        }
    }
}

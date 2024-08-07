
using DataAccess;
using DataAccess.Entities;

namespace Domain
{
    public class UserModel
    {
        UserDAO userDAO = new UserDAO();
        public User LoginUser(string username, string password)
        {
            return userDAO.Login(username, password);
        }

        public bool RegistrarUsuario(string nombreusuario, string contrasena, string tipousuario)
        {
            return userDAO.RegistrarUsuario(nombreusuario, contrasena, tipousuario);
        }

        public bool CheckUsuario(string username)
        {
            return userDAO.checkUsuario(username);
        }

        public bool EliminarUsuario(string username)
        {
            return userDAO.EliminarUsuario(username);
        }

        public User ObtenerUserUsername(int IDUSER)
        {
            return userDAO.ObtenerUserUsername(IDUSER);
        }

        public void ActualizarUser(int iduser, string contrasena)
        {
            userDAO.actualizarUsuario(iduser, contrasena);
        }
    }

    
}

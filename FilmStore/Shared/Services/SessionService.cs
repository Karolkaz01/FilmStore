using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Shared.Services
{
    public class SessionService
    {
        private UserInfo? user;
        private IClientService _clientService;

        public SessionService()
        {
            _clientService = new ClientService();
        }

        public UserInfo GetUser()
        {
            return user;
        }

        public void LogOut()
        {
            user = null;
        }

        public bool LogIn(string login, string password)
        {
            if (login == "admin" && password == "admin")
            {
                user = new UserInfo() { Login = "Admin" };
                return true;
            }
            return false;
            //var allUsers = _clientService.GetAllClients();
            //var currentUser = allUsers.FirstOrDefault(u => (u.AdressEmail == login) && (u.Password == password));

            //if (currentUser != null)
            //{
            //    user = new UserInfo() { Login = currentUser.AdressEmail, Password = currentUser.Password, Id = currentUser.Id };
            //    return true;
            //}
            //return false;
        }
    }
}

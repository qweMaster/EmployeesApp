using EmployeesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Controller
{
    class UsersController
    {


        Core db = new Core();
        public Users usersobj;
        public bool Entrance(string login, string pass)
        {

            usersobj = db.context.Users.Where(x => x.login == login && x.password == pass).First();

            if (usersobj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
    


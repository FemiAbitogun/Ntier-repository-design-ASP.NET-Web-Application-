using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using ViewModels;



namespace DAL
{
   public  interface IUserRepository
    {
        bool create(UserViewModel model);
        bool edit(UserViewModel model);
        bool delete(int id);
        UserViewModel   getUserById(int id);
        IEnumerable<UserViewModel> getAllUsers();
    }

}

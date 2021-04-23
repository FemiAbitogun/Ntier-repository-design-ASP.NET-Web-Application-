using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using ViewModels;

namespace DAL
{
    public class UserRepository : IUserRepository
    {

        USEREntities db = new USEREntities();
       
        //create new user.....................................................................
        public bool create(UserViewModel model)
        {
            try
            {
                AuthorizedUser newUser =  new AuthorizedUser();
                newUser.name = model.name;
                newUser.password = model.password;
                newUser.email = model.email;
                db.AuthorizedUsers.Add(newUser);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // edit user.....................................................................

        public bool edit(UserViewModel model)
        {
            try
            {
                AuthorizedUser editedUser = new AuthorizedUser();
                editedUser.userId=model.userId;
                editedUser.name = model.name;
                editedUser.password = model.password;
                editedUser.email = model.email;
                db.Entry<AuthorizedUser>(editedUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }





        // delete user.....................................................................

        public bool delete(int id)
        {
            try
            {
                AuthorizedUser user = new AuthorizedUser();
                user = db.AuthorizedUsers.Find(id);
                if (user == null)
                    return false;
                else
                {
                    db.AuthorizedUsers.Remove(user);
                    db.SaveChanges();
                    return true;
                }
              
            }
            catch (Exception)
            {
                return false;
            }
        }



        public UserViewModel getUserById(int id)
        {

           
            AuthorizedUser model = db.AuthorizedUsers.Find(id);
            UserViewModel user = new UserViewModel(model.name,model.password,model.email, model.userId);

          
            //user.userId = model.userId;
                return user;
            
           
        }



        public IEnumerable<UserViewModel> getAllUsers()
        {
            try
            {

                var  listOf = db.AuthorizedUsers.ToList();
                List<UserViewModel> userList = new List<UserViewModel>();


                foreach (AuthorizedUser model in listOf)
                {
                    UserViewModel list =new UserViewModel();
                
                    list.name = model.name;
                    list.password = model.password;
                    list.email = model.email;
                    list.userId = model.userId;

                    userList.Add(list);


                }

                return userList;
               


            }
            catch 
            {
                return null;
            }
        }





      
    }
}

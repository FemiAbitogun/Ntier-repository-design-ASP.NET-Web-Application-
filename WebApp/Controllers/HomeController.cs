using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IUserRepository repo = new UserRepository();


        //get all IENUMERABLE collections of users...............................
        //[HandleError(View = "Error")]
        public ActionResult Index()
        {
            IEnumerable<UserViewModel> listOfUser = repo.getAllUsers();
            int[] fault = { 2, 3 };
            //fault[4] = 333;
            return View(listOfUser);
        }

        //Fecth  user DETAILS by id..........................................................
        public ActionResult Details(int id)
        {
            UserViewModel user = repo.getUserById(id);
            return View(user);
        }





        //Create new user.........................................................................

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            ModelState.Remove("userId");

            if (ModelState.IsValid)
            {
                if (repo.create(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        // Edit user   .....................................................

        public ActionResult Edit(int id)
        {
            UserViewModel user = repo.getUserById(id);
            return View("Create", user);
        }


        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (repo.edit(model))
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View();

            }
            catch
            {
                return View();
            }
        }

        //delete exisitin user...............................................................
        public ActionResult Delete(int id)
        {
            try
            {
                if (repo.delete(id))
                {
                    return RedirectToAction("Index");
                }

                else
                {
                    ModelState.AddModelError("", "Operation not successful ");
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
        }
    }

}
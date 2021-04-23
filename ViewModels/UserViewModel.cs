using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
  public class UserViewModel
    {


        public int userId { get; set; }

        [Required(ErrorMessage ="Name field is required")]
        [Display(Name ="Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required(ErrorMessage = "Email field is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        public UserViewModel(string name, string password,string email,int userId )
        {
            this.name = name;
            this.password = password;
            this.email = email;
            this.userId = userId;

        }


        public UserViewModel()
        {
           

        }

    }
}

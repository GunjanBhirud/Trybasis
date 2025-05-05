using AgriCulture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace AgriCulture.Controllers
{
    public class UserRegistration : Controller
    {
        // GET: UserRegistration

        public UserregistrationContext urc;

        public UserRegistration(UserregistrationContext urc)
        {
            this.urc = urc;
           
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
           
        public ActionResult Create(Userregistration ur)
        {
            if (ur.UserPassword != null && ur.UserPassword == ur.UserPassConfirm)
            {
                urc.Userregistrations.Add(ur);
                urc.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

       
       

        
        public ActionResult Login()
        {

            return View();
        }

      
        [HttpPost]
        
        public ActionResult Login(string Email,string Password)
        {
            var ch=urc.Userregistrations.Where(x=>x.UserEmail == Email && x.UserPassword==Password).FirstOrDefault();
            if (ch == null)
            {
                return View();
            }
            else
            {
              

                return RedirectToAction("Index", "Home");
            }
        }

       
       
    }
}

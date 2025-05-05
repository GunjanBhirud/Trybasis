using AgriCulture.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgriCulture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ContactUsContext cuc;
        public BlogcommentContext bcc;
        public AddBlogContext addBlog;

        public HomeController(ILogger<HomeController> logger, ContactUsContext cuc, BlogcommentContext bcc, AddBlogContext addBlog)
        {
            
            _logger = logger;
            this.cuc = cuc;
            this.bcc = bcc;
            this.addBlog = addBlog;
        }

        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Services() 
        {
            return View();
        }
        
        public IActionResult Testimonials()
        {
            return View();
        }
        public IActionResult Blog()
        {
            var nb = addBlog.AddBlogs.ToList();
            return View(nb);
        }
       
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactUs cu)
        {
            cuc.ContactUss.Add(cu);
            cuc.SaveChanges();
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

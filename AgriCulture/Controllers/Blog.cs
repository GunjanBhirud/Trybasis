using AgriCulture.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace AgriCulture.Controllers
{
    public class Blog : Controller
    {
        public BlogcommentContext bcc;
        public IWebHostEnvironment env;
        public AddBlogContext abc;

        public Blog(BlogcommentContext bcc, IWebHostEnvironment env, AddBlogContext abc)
        {
            this.bcc = bcc;
            this.env = env;
            this.abc = abc;
        }
        [HttpPost]
        public IActionResult AddComments(Blogcommentts bg)
        {
            bcc.Blogcommentts.Add(bg);
            bcc.SaveChanges();
            return RedirectToAction("blog_details","Home");
        }
        public IActionResult Addblog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Addblog(AddBlogdummy abd)
        {
            string path = Path.Combine(env.WebRootPath, "Blogimg");
            string filename = abd.fileattached.FileName;
            string filepath = Path.Combine(path, filename);


            abd.fileattached.CopyTo(new FileStream(filepath, FileMode.Create));

            AddBlog ab = new AddBlog();
            ab.BlogId=abd.BlogId;
            ab.username = abd.username;
            ab.email = abd.email;
            ab.Profession = abd.Profession;
            ab.type = abd.type;
            ab.Publisheddate = abd.Publisheddate;
            ab.personal_data = abd.personal_data;
            ab.subject = abd.subject;
            ab.description = abd.description;
            ab.file_attached = filename;
            abc.AddBlogs.Add(ab);
            abc.SaveChanges();
            return RedirectToAction("Blog", "Home");
        }
        public IActionResult blog_details(int BlogId)
        {

            Console.WriteLine("BlogId is :"+ BlogId);
                var blogdetail= abc.AddBlogs.Where(x=>x.BlogId == BlogId).FirstOrDefault();

                var mn = bcc.Blogcommentts.ToList();
                TempData["CCount"] = mn.Count();
                return View(blogdetail);
            
             

        }
    }
}

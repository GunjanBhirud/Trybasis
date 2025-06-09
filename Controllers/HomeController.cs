using Microsoft.AspNetCore.Mvc;
using Realestate.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Mail;
using System.Net;
using System.Reflection.Emit;
using Microsoft.Data.SqlClient.DataClassification;
namespace Realestate.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public Signupdatacontext sn;
        public SaleHomeContext sc1;
        public AdminContext ac1;
        public FeedbackContext fbc;
        public CombomodelContext cmc;
        public VerifySaledataContext vsdc;
        public VerifyStatusContext vsc;
        public IWebHostEnvironment env;
        public string mail = "gunjanbhirud2@gmail.com";
        public string pmail = "crpy pvqd fejp umug";

        public HomeController(ILogger<HomeController> logger, Signupdatacontext sn,SaleHomeContext sc1, IWebHostEnvironment env ,AdminContext ac1,FeedbackContext fbc, CombomodelContext cmc, VerifySaledataContext vsdc, VerifyStatusContext vsc)
        {
            
            _logger = logger;
            this.sn = sn;
            this.sc1 = sc1;
            this.env = env;
            this.ac1 = ac1;
            this.fbc = fbc;
            this.cmc = cmc;
            this.vsdc= vsdc;
            this.vsc = vsc;
        }

        public IActionResult Admin()
        {
            var nm=ac1.Admins.ToList();
            return View(nm);
        }
        [HttpPost]
        public IActionResult Admin(string Email, string Password)
        {
            var ch = ac1.Admins.Where(x => x.AdminEmail.Equals(Email) && x.AdminPassword.Equals(Password)).FirstOrDefault();

            if (ch!=null)
            {
                HttpContext.Session.SetString("Admin", Email);
                ViewBag.Adminses = HttpContext.Session?.GetString("Admin");
                
                return RedirectToAction("Index");
               
            }
            else
            {
                return View();
            }
        }

        public IActionResult LogoutAdmin()
        {
            HttpContext.Session.Remove("Admin");
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
           
            
            
                ViewBag.Ses = HttpContext.Session.GetString("temp")?.ToString();
           
            TempData["Adminses"] = HttpContext.Session?.GetString("Admin");

         

           // var r = sc1.SaleHomes.ToList();
            var viewmodel1 = new Salefeeddummycombo()
            {
                SaleHomes=cmc.SaleHomes.ToList(),
                Feedbacks=cmc.Feedbacks.ToList(),
                DummyFeedbacks=cmc.DummyFeedbacks
                
            };

            return View(viewmodel1);
           
            
        }

        public IActionResult About()
        {
            ViewBag.Ses = HttpContext.Session.GetString("temp")?.ToString();
            TempData["Adminses"] = HttpContext.Session?.GetString("Admin");



            if (ViewBag.Ses == null && TempData["Adminses"]==null)
            {
                    return RedirectToAction("Login");
                
            }

            return View();
        }

        public IActionResult House() 
        {
            ViewBag.Ses = HttpContext.Session.GetString("temp")?.ToString();
            TempData["Adminses"] = HttpContext.Session?.GetString("Admin");



            if (ViewBag.Ses == null && TempData["Adminses"] == null)
            {
                return RedirectToAction("Login");

            }
            var r = sc1.SaleHomes.ToList();
            return View(r);
        }

        public IActionResult Price()
        {
            ViewBag.Ses = HttpContext.Session.GetString("temp")?.ToString();
            TempData["Adminses"] = HttpContext.Session?.GetString("Admin");



            if (ViewBag.Ses == null && TempData["Adminses"] == null)
            {
                return RedirectToAction("Login");

            }
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Ses = HttpContext.Session.GetString("temp")?.ToString();
            TempData["Adminses"] = HttpContext.Session?.GetString("Admin");



            if (ViewBag.Ses == null && TempData["Adminses"] == null)
            {
                return RedirectToAction("Login");

            }

            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(Signupdata sf)
        {
            if (sf.password == sf.cpassword && sf.number.Length==10)
            {
                sn.Signupdatas.Add(sf);
                sn.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("temp");
          
            return RedirectToAction("Index");
        }

      
        public IActionResult Login()
        {
            TempData["ForOtpSec"] = null;
            
            return View();
        }
      
        [HttpPost]
        public IActionResult Login(string email, string password ,int? Cotp)
        {
            var r = sn.Signupdatas.Where(x => x.email.Equals(email) && x.password.Equals(password)).FirstOrDefault();

            TempData["Formail"] = email;



            TempData["otp"] = 1111;

            if(r == null)
            {
                ViewBag.pp = "gb";
                return View();
            }
            else
            {

                TempData["ForOtpSec"] = r.email;
                HttpContext.Session.SetString("temp", email);
                ViewBag.Ses = HttpContext.Session.GetString("temp")?.ToString();
                //string smail = r.email;
                return RedirectToAction("Index");
            }
            
         
        }
        public IActionResult Otp()
        {
            ViewBag.aju = TempData["Formail"];
           // ViewBag.ef = email;
            string smail = ViewBag.aju;
            using (MailMessage nm = new MailMessage(mail, smail))
            {
                TempData["otp"] = new Random().Next(1000, 9999);
                nm.Subject = "GP ESTATE";
                nm.Body = "DON'T share OTP with any one for security purpose.OTP for login session is " + TempData["otp"];
                nm.IsBodyHtml = false;
                HttpContext.Session.SetString("otpemail", "otpsend");
                ViewBag.otpses = HttpContext.Session.GetString("otpemail");


                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;

                    NetworkCredential cred = new NetworkCredential(mail, pmail);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = cred;
                    smtp.Port = 587;

                    try
                    {
                        smtp.Send(nm);
                      //  HttpContext.Session.SetString("otpemail", "otpsend");
                       // ViewBag.otpses = HttpContext.Session.GetString("otpemail");
                    }
                    catch (SmtpException ex)
                    {


                        Console.WriteLine("SMTP Exception: " + ex.Message);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Exception: " + ex.Message);
                    }
                }

            }
        
          

            return View();
        }
        [HttpPost]
        public IActionResult Otp(string email,int Cotp)
        {
            if (Convert.ToInt32(TempData["otp"]) == Cotp)
            {
                HttpContext.Session.SetString("temp", email);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.WEmail = "Wrong OTP";
                //return View();
                HttpContext.Session.SetString("temp", email);

                return RedirectToAction("Index");
            }
        }
        public IActionResult Salehome()
        {
            ViewBag.Ses = HttpContext.Session.GetString("temp")?.ToString();
            TempData["Adminses"] = HttpContext.Session?.GetString("Admin");



            if (ViewBag.Ses == null && TempData["Adminses"] == null)
            {
                return RedirectToAction("Login");

            }
            return View();
        }

        [HttpPost]

        public IActionResult Salehome(DummySaleData ds1,int OTP)
        {

            if (ds1.Property_Imagee != null)
            {

                String path = Path.Combine(env.WebRootPath, "SaleHomeImage");

                String filename = ds1.Property_Imagee.FileName;

                String filepath = Path.Combine(path,filename);

                ds1.Property_Imagee.CopyTo(new FileStream(filepath, FileMode.Create));

                VerifySaledata v1= new VerifySaledata();
                v1.Sale_Person_Name = ds1.Sale_Person_Name;
                v1.Sale_Person_Email = ds1.Sale_Person_Email;
                v1.Sale_Person_Number = ds1.Sale_Person_Number;
                v1.Property_Type = ds1.Property_Type;
                v1.Property_Value = ds1.Property_Value;
                v1.Property_Address = ds1.Property_Address;
                v1.Property_City = ds1.Property_City;
                v1.Property_Image = filename;
                
               // string mail = "gunjanbhirud2@gmail.com";
               // string pmail = "crpy pvqd fejp umug";
                string smail = v1.Sale_Person_Email;
               // int num = new Random().Next(1000, 9999);
                using (MailMessage nm = new MailMessage(mail, smail))
                {
                    nm.Subject = "GP ESTATE";
                    nm.Body = "Hello"+v1.Sale_Person_Name+" your Proverty goes under the Verification pannel ";
                    nm.IsBodyHtml = false;


                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;

                        NetworkCredential cred = new NetworkCredential(mail, pmail);
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = cred;
                        smtp.Port = 587;

                        try
                        {
                            smtp.Send(nm);
                        }

                        catch (Exception ex)
                        {

                            Console.WriteLine("Exception: " + ex.Message);
                        }
                    }
                }
                
                
                    vsdc.VerifySaledatas.Add(v1);
                    vsdc.SaveChanges();
                   
                
                
            }
            return View();
        }
        
       /* public IActionResult VerifySale()
        {
            var r = vsdc.VerifySaledatas.ToList();
        
            return View(r);
        }*/
       
        public IActionResult VerifySingle(int Id)
        {
            TempData["Adminses"] = HttpContext.Session?.GetString("Admin");

            if (Id != null && TempData["Adminses"]!= null)
            {
                var r = vsdc.VerifySaledatas.Find(Id);
                SaleHome s1 = new SaleHome();
                s1.Sale_Person_Name = r.Sale_Person_Name;
                s1.Sale_Person_Email = r.Sale_Person_Email;
                s1.Sale_Person_Number = r.Sale_Person_Number;
                s1.Property_Type = r.Property_Type;
                s1.Property_Value = r.Property_Value;
                s1.Property_Address = r.Property_Address;
                s1.Property_City = r.Property_City;
                s1.Property_Image = r.Property_Image;


                sc1.SaleHomes.Add(s1);
                sc1.SaveChanges();
                VerifyStatus vs = new VerifyStatus();

                vs.Sale_Person_Name = r.Sale_Person_Name;
                vs.Sale_Person_Email = r.Sale_Person_Email;
                vs.Sale_Person_Number = r.Sale_Person_Number;
                vs.Property_Type = r.Property_Type;
                vs.Property_Value = r.Property_Value;
                vs.Property_Address = r.Property_Address;
                vs.Property_City = r.Property_City;
                vs.Property_Image = r.Property_Image;
                vs.Status = "Approved";
                vsc.VerifyStatuss.Add(vs);
                vsc.SaveChanges();

                vsdc.VerifySaledatas.Remove(r);
                vsdc.SaveChanges();

               // string mail = "gunjanbhirud2@gmail.com";
                //string pmail = "crpy pvqd fejp umug";
                string smail = vs.Sale_Person_Email;

                using (MailMessage nm = new MailMessage(mail, smail))
                {
                    nm.Subject = "Approval";
                    nm.Body = "Your Property are Approved by Admin.";
                    nm.IsBodyHtml = false;


                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;

                        NetworkCredential cred = new NetworkCredential(mail, pmail);
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = cred;
                        smtp.Port = 587;

                        try
                        {
                            smtp.Send(nm);
                        }
                        catch (SmtpException ex)
                        {


                            Console.WriteLine("SMTP Exception: " + ex.Message);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Exception: " + ex.Message);
                        }
                    }
                }

                return RedirectToAction("VerifySale", "Home");
            }
            else
            {

                return RedirectToAction("Index");
            }
        }
     public IActionResult VerifySingleReject(int Id)
        {
            var r = vsdc.VerifySaledatas.Find(Id);
            VerifyStatus vs = new VerifyStatus();

            vs.Sale_Person_Name = r.Sale_Person_Name;
            vs.Sale_Person_Email = r.Sale_Person_Email;
            vs.Sale_Person_Number = r.Sale_Person_Number;
            vs.Property_Type = r.Property_Type;
            vs.Property_Value = r.Property_Value;
            vs.Property_Address = r.Property_Address;
            vs.Property_City = r.Property_City;
            vs.Property_Image = r.Property_Image;
            vs.Status = "Rejected";
            vsc.VerifyStatuss.Add(vs);
            vsc.SaveChanges();

            vsdc.VerifySaledatas.Remove(r);
            vsdc.SaveChanges();

            string smail = vs.Sale_Person_Email;

            using (MailMessage nm = new MailMessage(mail, smail))
            {
                nm.Subject = "Rejected";
                nm.Body = "Hello "+vs.Sale_Person_Name+" Your Property is rejected by admin";
                nm.IsBodyHtml = false;


                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;

                    NetworkCredential cred = new NetworkCredential(mail, pmail);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = cred;
                    smtp.Port = 587;

                    try
                    {
                        smtp.Send(nm);
                    }
                    catch (SmtpException ex)
                    {

                        Console.WriteLine("SMTP Exception: " + ex.Message);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Exception: " + ex.Message);
                    }
                }
            }

            return RedirectToAction("VerifySale", "Home");
        }

        public IActionResult Search(string? Category, string? Location, int? Price)
        {
            if (Category == null && Location == null && Price==null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                
                    ViewBag.Cat = Category?.ToLower();
                
                    ViewBag.Loc = Location?.ToLower();
                ViewBag.Pri = Price * 100000;

                var r = sc1.SaleHomes.ToList();
                return View(r);
            }
        }
       
       /* public IActionResult SortPrice(int Price)
        {
            ViewBag.Pri = Price;
            return View();
        }*/
        
        public IActionResult Feedback(DummyFeedback df2)
        {
            
            if (ModelState.IsValid)
            {
            
                String path = Path.Combine(env.WebRootPath, "Feedbackimg");

                String filename = df2.Imgfeedback.FileName;

                String filepath = Path.Combine(path, filename);

                df2.Imgfeedback.CopyTo(new FileStream(filepath, FileMode.Create));

                Feedback f1 = new Feedback();
                f1.Name = df2.Name;
                f1.Email = df2.Email;
                f1.Contact = df2.Contact;
                f1.Message = df2.Message;
                f1.Picfeedback = filename;


              cmc.Feedbacks.Add(f1);
                cmc.SaveChanges();
            
           
                return RedirectToAction("Index");
            }
                return RedirectToAction("Login");
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

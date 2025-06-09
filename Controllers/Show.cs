using Microsoft.AspNetCore.Mvc;
using Realestate.Models;
using System.IO;
using System.Security.Cryptography;

namespace Realestate.Controllers
{
    public class Show : Controller
    {
        private readonly ILogger<Show> _logger;


        public Signupdatacontext sn;
        public SaleHomeContext sc1;
        public BuyHomeContext bhc1;
        public AdminContext ac1;
        public FeedbackContext fbc;
        public CombomodelContext cmc;
        public DummySaleDataContext dsdc;
        public VerifySaledataContext vsdc;
        public ComboSaleDummyContext csdc;
        public IWebHostEnvironment env;


        public Show(ILogger<Show> logger, Signupdatacontext sn, SaleHomeContext sc1, BuyHomeContext bhc1,IWebHostEnvironment env, AdminContext ac1, FeedbackContext fbc,CombomodelContext cmc, DummySaleDataContext dsdc,VerifySaledataContext vsdc, ComboSaleDummyContext csdc)
        {

            _logger = logger;
            this.sn = sn;
            this.sc1 = sc1;
            this.bhc1 = bhc1;
            this.env = env;
            this.ac1 = ac1;
            this.fbc = fbc;
            this.cmc = cmc;
            this.dsdc = dsdc;
            this.vsdc = vsdc;
            this.csdc = csdc;
           

        }

        public IActionResult NewAdmin()
        {
            ViewBag.Adminses = HttpContext.Session.GetString("Admin");
            return View();
        }
        [HttpPost]
        public IActionResult NewAdmin(Admin ad)
        {
            if (ad.AdminPassword == ad.AdminPassConfirm)
            {
                ac1.Admins.Add(ad);
                
                ac1.SaveChanges();
                return RedirectToAction("Index","Home");
            }
                return View();
        }

        public IActionResult Editdata(int id)
        {

           var cv= csdc.SaleHomes.Find(id);
            ViewBag.img = cv.Property_Image;
            DummySaleData sd= new DummySaleData();
            sd.SaleId=cv.SaleId;
            sd.Sale_Person_Name = cv.Sale_Person_Name;
            sd.Sale_Person_Email =  cv.Sale_Person_Email;
            sd.Sale_Person_Number = cv.Sale_Person_Number;
            sd.Property_Type = cv.Property_Type;
            sd.Property_Value = cv.Property_Value;
            sd.Property_Address = cv.Property_Address;
            sd.Property_City = cv.Property_City;
            

            return View(sd);
        }
       
        [HttpPost]
        public IActionResult Update(DummySaleData ds)
        {
            var cv = csdc.SaleHomes.Find(ds.SaleId);

            var vb = sc1.SaleHomes.Find(ds.SaleId);


            vb.Sale_Person_Name = ds.Sale_Person_Name;
            vb.Sale_Person_Email = ds.Sale_Person_Email;
            vb.Sale_Person_Number = ds.Sale_Person_Number;
            if (ds.Property_Type != null)
            {
                vb.Property_Type = ds.Property_Type;
            }
            else
            {
                vb.Property_Type = cv.Property_Type;
            }
            vb.Property_Value = ds.Property_Value;
            vb.Property_Address = ds.Property_Address;
            if (ds.Property_City != null)
            {
                vb.Property_City = ds.Property_City;
            }
            else
            {
                vb.Property_City = cv.Property_City;
            }
            if (ds.Property_Imagee != null)
            {
                String path = Path.Combine(env.WebRootPath, "SaleHomeImage");

                String? filename = ds.Property_Imagee.FileName;

                String filepath = Path.Combine(path, filename);

                ds.Property_Imagee.CopyTo(new FileStream(filepath, FileMode.OpenOrCreate));

                vb.Property_Image = filename;
            }
            else
            {
                vb.Property_Image = cv.Property_Image;
            }
            sc1.SaveChanges();
          
            return RedirectToAction("Index", "Home");
        }
        

        public IActionResult Showselected(int Id)
        {
            var r = sc1.SaleHomes.Find(Id);
            
                ViewBag.Ses = HttpContext.Session.GetString("temp")?.ToString();
            TempData["Adminses"] = HttpContext.Session?.GetString("Admin");


            return View(r);
        }
        public IActionResult VerifySingle(int SaleId)
        {
            var r = vsdc.VerifySaledatas.Find(SaleId);

            return View(r);
        }
        public IActionResult Buyhouse(int Id)
        {
            ViewBag.Ses = HttpContext.Session.GetString("temp")?.ToString();
            TempData["Adminses"] = HttpContext.Session?.GetString("Admin");



            if (ViewBag.Ses == null && TempData["Adminses"] == null)
            {
                return RedirectToAction("Login","Home");

            }
            else
            {
                var n = sc1.SaleHomes.Find(Id);
                ViewBag.lgemail = HttpContext.Session.GetString("temp")?.ToString();
                return View(n);
            }
        }

        public IActionResult BuyAction(SaleHome sh,string Buyer_Name,string Buyer_Phone,string Buyer_Email,string Payment_Mode)
        {

            BuyHome b1= new BuyHome();
            b1.SaleId=sh.SaleId;
            b1.Sale_Person_Name = sh.Sale_Person_Name;
            b1.Sale_Person_Email = sh.Sale_Person_Email;
            b1.Sale_Person_Number = sh.Sale_Person_Number;
            b1.Property_Type = sh.Property_Type;
            b1.Property_Value = sh.Property_Value;
            b1.Property_Address = sh.Property_Address;
            b1.Property_City = sh.Property_City;
            b1.Property_Image = sh.Property_Image;
            b1.Buyer_Name=Buyer_Name;
            b1.Buyer_Phone=Buyer_Phone;
            b1.Payment_Mode=Payment_Mode;
            b1.Buyer_Email=Buyer_Email;
            bhc1.BuyHomes.Add(b1);
            bhc1.SaveChanges();
           

            return RedirectToAction("Index","Home");
        }
/*
        public IActionResult BuyHomeData() {
            ViewBag.Sold = bhc1.BuyHomes.Count();
            var b = bhc1.BuyHomes.ToList();
            return View(b);
        }

        public IActionResult Unsold()
        {
            ViewBag.TotUnsold=sc1.SaleHomes.Count();
            var n = sc1.SaleHomes.ToList();
            return View(n);
        }*/

       
    }
}

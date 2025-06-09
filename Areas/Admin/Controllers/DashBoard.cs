using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Realestate.Areas.Admin.Models;
using Realestate.Controllers;
using Realestate.Models;

namespace Realestate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashBoard : Controller
    {
        public SaleHomeContext sc1;
        public BuyHomeContext bhc1;
        public VerifySaledataContext vsdc;
        public VerifyStatusContext vssc;
        public CombomodelContext cmc;
        public Combineforjoin cfj;
        public DashBoard(SaleHomeContext sc1, BuyHomeContext bhc1, VerifySaledataContext vsdc, VerifyStatusContext vssc, CombomodelContext cmc, Combineforjoin cfj)
        {

            this.sc1 = sc1;
            this.bhc1 = bhc1;
            this.vsdc = vsdc;
            this.vssc = vssc;
            this.cmc = cmc;
            this.cfj = cfj;
           
        }
       

        public IActionResult BuyHomeData()
        {
            if (HttpContext.Session?.GetString("Admin") != null)
            {
                ViewBag.Sold = bhc1.BuyHomes.Count();
                var b = bhc1.BuyHomes.ToList();

                ViewBag.VerifyC = vsdc.VerifySaledatas.Count();

                return View(b);
            }
            return RedirectToAction("Admin", "Home");
        }
        public IActionResult UnSold()
        {
            if (HttpContext.Session?.GetString("Admin") != null)
            {

                ViewBag.TotUnsold = sc1.SaleHomes.Count();
                var n = sc1.SaleHomes.ToList();

                
                ViewBag.VerifyC = vsdc.VerifySaledatas.Count();

                return View(n);
            }
            return RedirectToAction("Admin","Home");
        }

        public IActionResult VerifySale()
        {
            if (HttpContext.Session?.GetString("Admin") != null)
            {
                var r = vsdc.VerifySaledatas.ToList();
                ViewBag.VerifyC = vsdc.VerifySaledatas.Count();
                
                return View(r);
            }
            return RedirectToAction("Admin", "Home");
        }

        public IActionResult RejectList()
        {
            if (HttpContext.Session?.GetString("Admin") != null)
            {
                var r = vssc.VerifyStatuss.Where(x=>x.Status== "Rejected").ToList();
                    ViewBag.RejectedC = r.Count();
                ViewBag.VerifyC = vsdc.VerifySaledatas.Count();
                return View(r);
            }
            return RedirectToAction("Admin", "Home");
        }

        public IActionResult Approved()
        {
            if (HttpContext.Session?.GetString("Admin") != null)
            {
                var r = vssc.VerifyStatuss.Where(x => x.Status == "Approved").ToList();
                ViewBag.ApprovedC = r.Count();
                ViewBag.VerifyC = vsdc.VerifySaledatas.Count();
                return View(r);
            }
            return RedirectToAction("Admin", "Home");
        }
        public IActionResult Join()
        {
            var viewmodel2 = new Combineforjoin()
            {
                SaleHomes = cfj.SaleHomes,
                VerifySaledatas = cfj.VerifySaledatas


            };
            var re = from sale in viewmodel2.SaleHomes
                     join verify in viewmodel2.VerifySaledatas on sale.SaleId equals verify.SaleId
                     where sale.SaleId != 0
                     select sale;
            /*Join*/
            /*{
                Saleid = sale.SaleId,
                vname = verify.Sale_Person_Name
            };*/
            var nv = re.ToList();

            return View(nv);
        }

    }
}

using BusinessRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.VMmodel;

namespace Meeting.Areas.Admin.Controllers
{
    public class PanchaayatController : Controller
    {
        Repository repository;
        // GET: Admin/Panchaayat
        public ActionResult Index()
        {
            return View();
        }

        public PanchaayatController()
        {
            repository = new Repository();
        }  

        public JsonResult AddPanchayat(VMPanchaayat vmpanchayat)
        {
            return Json(repository.AddPanchayat(vmpanchayat));
        }

        public JsonResult getPanchayatList()
        {
            return Json(repository.getPanchayatList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getPanchayatbyid(int paanid)
        {
            return Json(repository.getPanchayatbyid(paanid), JsonRequestBehavior.AllowGet);
        }

        public JsonResult deletePanchayat(int id)
        {
            return Json(repository.deletePanchayat(id), JsonRequestBehavior.AllowGet);
        }
    }
}
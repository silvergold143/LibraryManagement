using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class LibraryController : Controller
    {
        // GET: Library
        //public ActionResult Index()
        //{
        //    List<tblLibrary> Librarylist = new List<tblLibrary>();
        //    using (var ctx=new LibraryManagementEntities())
        //    {
        //         Librarylist = ctx.tblLibraries.ToList();
        //    }

        //    return View(Librarylist);
        //}
        [Authorize]
        public ActionResult Create()
        {
            using (var ctx = new LibraryManagementEntities())
            {
                ViewBag.lbrlist = ctx.tblLibraries.ToList();
            }

            return View();
        }
        [HttpPost]
        public ActionResult Create(tblLibrary obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  
               
                using (var ctx = new LibraryManagementEntities())
                {
                    ctx.tblLibraries.Add(obj);
                    ctx.SaveChanges();
                    TempData["msg"] = "Library Saved Sucessfully.";
                }
                }
            }
            catch (Exception)
            {

                TempData["msg"] = "Oops went something wrong";
            }
                ModelState.Clear();
                return View();
        }
        [Authorize]
         public ActionResult Llist()
        {
            
            using (var ctx = new LibraryManagementEntities())
            {
               var Librarylist = ctx.tblLibraries.ToList();
                return View(Librarylist);
            }

            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    
    public class DepartmentController : Controller
    {
        // GET: Department
        //public ActionResult Index()
        //{
        //    List<tblDepartment> deptlist = new List<tblDepartment>();
        //    using (var ctx = new LibraryManagementEntities())
        //    {
        //        deptlist = ctx.tblDepartments.ToList();

        //    }
        //    return View(deptlist);
        //}
        [Authorize]
        public ActionResult Create()
        {
            using (var ctx=new LibraryManagementEntities())
            {
                ViewBag.listofDepartment = ctx.tblDepartments.ToList();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblDepartment obj)
        {
            try
            {
                if (ModelState.IsValid==false)
                {
                    // ViewBag.msg = "Department Saved Sucessfully.";
                    TempData["msg"] = "Department Saved Sucessfully.";
                    return View();

                }
                using (var ctx = new LibraryManagementEntities())
                {
                    ctx.tblDepartments.Add(obj);
                    ctx.SaveChanges();
                    ViewBag.listofDepartment = ctx.tblDepartments.ToList();
                    //ViewBag.msg = "Department Saved Sucessfully.";
                    TempData["msg"] = "Department Saved Sucessfully.";
                }
                
            }
            catch (Exception er)
            {
                TempData["msg"] = "Oops went something wrong";
                // ViewBag.msg = "Oops went something wrong";
            }

            ModelState.Clear();
            //return View();
            return RedirectToAction(" ");
        }
        [Authorize]
        public ActionResult DptList()
        {
            using (var ctx = new LibraryManagementEntities())
            {
               var dptList= ctx.tblDepartments.ToList();
                return View(dptList);
            }

           // return View();
        }
    }
}
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace LibraryManagement.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
      
        [HttpGet]
        [Authorize]
        public ActionResult Create(int id=0)
        {
            using (var ctx=new LibraryManagementEntities())
            {
                ViewData["StudList"] = ctx.tblStudents.Include(a=>a.tblDepartment).Include(b=>b.tblLibrary).ToList();
                
            
                ViewBag.deptlist = clsCommon.GetDepartment();
                ViewBag.Librarylist = clsCommon.GetLibrary();
            }


            if (id==0) //for create
            {
                Student newstd = new Student();
                return View(newstd);
            }


            Student s1 = new Student();
            using (var ctx = new LibraryManagementEntities())
            {

                var obj = ctx.tblStudents.Where(w => w.Id == id).FirstOrDefault();
                if (obj != null)
                {
                    s1.Id = obj.Id;
                    s1.Name = obj.Name;
                    s1.Address = obj.Address;
                    s1.MobileNo = obj.MobileNo;
                    s1.Gender = obj.Gender;
                    s1.BirthDate = Convert.ToDateTime(obj.BirthDate);
                    s1.EmailId = obj.EmailId;
                    s1.Password = obj.Password;
                    s1.DepartmentId = obj.DepartmetId.ToString();
                    s1.LibraryId = obj.LibraryId.ToString();
                    s1.Photo = obj.Photo;
                    s1.Hobbies = obj.Hobbies;
                }
                //else
                //{
                //    return RedirectToAction("Index");
                //}


            }
            return View(s1);
        }
        [HttpPost]
       
        public ActionResult Create(Student obj,HttpPostedFileBase myphoto)
        {
            //if (ModelState.IsValid)
            //{
            ViewBag.deptlist = clsCommon.GetDepartment();
            ViewBag.Librarylist = clsCommon.GetLibrary();

            string FileName = "";
            if (myphoto!=null)
            {
                string FolderPath = Server.MapPath("~/Uploaded/");
                FileName = DateTime.Now.ToString("ddMMyyyyhhmmss")+myphoto.FileName;
                myphoto.SaveAs(FolderPath+ FileName);
            } 
            using (var ctx = new LibraryManagementEntities())
                {
                    if (obj.Id>0)
                    {
                        var OldStudent = ctx.tblStudents.Find(obj.Id);
                        if (OldStudent != null)
                        {
                            OldStudent.Name = obj.Name;
                            OldStudent.Address = obj.Address;
                            OldStudent.MobileNo = obj.MobileNo;
                            OldStudent.Gender = obj.Gender;
                            OldStudent.BirthDate = obj.BirthDate;
                            OldStudent.EmailId = obj.EmailId;
                            OldStudent.Password = obj.Password;
                            OldStudent.DepartmetId = Convert.ToInt32(obj.DepartmentId);
                            OldStudent.LibraryId =Convert.ToInt32(obj.LibraryId);
                            OldStudent.Hobbies = obj.Hobbies;
                            OldStudent.Photo = FileName;
                            ctx.tblStudents.Attach(OldStudent);
                            ctx.Entry(OldStudent).State = System.Data.Entity.EntityState.Modified;
                            ctx.SaveChanges();
                        }

                    ViewData["Message"] = "Record updated successfully.";
                    }
                    else
                    {

                        tblStudent stud = new tblStudent();
                        stud.Name = obj.Name;
                        stud.Address = obj.Address;
                        stud.MobileNo = obj.MobileNo;
                        stud.Gender = obj.Gender;
                        stud.BirthDate = obj.BirthDate;
                        stud.EmailId = obj.EmailId;
                        stud.Password = obj.Password;
                        stud.DepartmetId = Convert.ToInt32(obj.DepartmentId);
                        stud.LibraryId =Convert.ToInt32(obj.LibraryId);
                        stud.Hobbies = obj.Hobbies;
                        stud.Photo = FileName;
                        ctx.tblStudents.Add(stud);
                        ctx.SaveChanges();

                    ViewData["Message"] = "Record inserted successfully.";
                }
                  
                }
            //return RedirectToAction("Index");
            //  }
                using (var ctx = new LibraryManagementEntities())
                {
                    ViewData["StudList"] = ctx.tblStudents.Include(a=>a.tblDepartment).Include(b => b.tblLibrary).ToList();
                }
            ModelState.Clear();
              return View();
        }
        [Authorize]
        public ActionResult Index()
        {
            List<tblStudent> stdlist = new List<tblStudent>();
            using (var ctx = new LibraryManagementEntities())
            {
                stdlist = ctx.tblStudents.ToList();
                ViewData["StudList"] = ctx.tblStudents.Include(a => a.tblDepartment).Include(b => b.tblLibrary).ToList();

            }
            return View(stdlist);
        }

        //public ActionResult Edit(int id)
        //{
        //    Student s1 = new Student();
        //    using (var ctx = new LibraryManagementEntities())
        //    {

        //        var obj = ctx.tblStudents.Where(w=>w.Id==id).FirstOrDefault();
        //        if (obj!=null)
        //        {
        //            s1.Name = obj.Name;
        //            s1.Address = obj.Address;
        //            s1.MobileNo = obj.MobileNo;
        //            s1.Gender = obj.Gender;
        //            s1.BirthDate = Convert.ToDateTime(obj.BirthDate);
        //            s1.EmailId = obj.EmailId;
        //            s1.Password = obj.Password;
        //            s1.DepartmentId = obj.DepartmetId.ToString();
        //            s1.Hobbies = obj.Hobbies;
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index");
        //        }


        //    }
        //    return View(s1);
        //}
        //[HttpPost]
        //public ActionResult Edit(Student data)
        //{
        //    using (var ctx =new LibraryManagementEntities())
        //    {
        //        var OldStudent = ctx.tblStudents.Find(data.Id);
        //        if (OldStudent!=null)
        //        {
        //            OldStudent.Name = data.Name;
        //            OldStudent.Address = data.Address;
        //            OldStudent.MobileNo = data.MobileNo;
        //            OldStudent.Gender = data.Gender;
        //            OldStudent.BirthDate = data.BirthDate;
        //            OldStudent.EmailId = data.EmailId;
        //            OldStudent.Password = data.Password;
        //            OldStudent.DepartmetId = Convert.ToInt32(data.DepartmentId);
        //            OldStudent.Hobbies = data.Hobbies;

        //            ctx.tblStudents.Attach(OldStudent);
        //            ctx.Entry(OldStudent).State = System.Data.Entity.EntityState.Modified;
        //            ctx.SaveChanges();
        //        }

        //    }
        //    return RedirectToAction("Index");
        //}
        public ActionResult Delete(int ItemId)
        {
            using (var ctx=new LibraryManagementEntities())
            {
               var OldStudent= ctx.tblStudents.Find(ItemId);
                if (OldStudent!=null)
                {
                    ctx.tblStudents.Remove(OldStudent);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Create",new { id=0});
        }
        
    }
}
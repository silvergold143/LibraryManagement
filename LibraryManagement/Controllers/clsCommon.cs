using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public static class clsCommon
    {
        public static List<SelectListItem> GetDepartment()
        {

            List<SelectListItem> dept = new List<SelectListItem>();
            using (var ctx = new LibraryManagementEntities())
            {
               
                var Alldepartment = ctx.tblDepartments.ToList();
                foreach (var item in Alldepartment)
                {
                    dept.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
                }
                return dept;
            }

        }
        public static List<SelectListItem> GetLibrary()
        {
            List<SelectListItem> lbry = new List<SelectListItem>();
            using (var ctx = new LibraryManagementEntities())
            {
                var allLibrary = ctx.tblLibraries.ToList();
                foreach (var item in allLibrary)
                {
                    lbry.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
                }
                return lbry;

            }
            

        }

        public static string getUserFullName(int Id)
        {
            using (var ctx=new LibraryManagementEntities())
            {
                var obj = ctx.tblStudents.Find(Id);
                if (obj!=null)
                {
                   return obj.Name;
                }
            }
            return "";
        }
    }
}
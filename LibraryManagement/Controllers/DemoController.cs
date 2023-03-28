 using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    [Authorize]
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Student(int PageNo = 1)
        {
            int PageSize = 5;
            int skipCount = (PageNo - 1) * PageSize;
            List<tblStudent> studlist = new List<tblStudent>();
            using (var ctx = new LibraryManagementEntities())
            {
                int res = ctx.tblStudents.Count() / PageSize;
                if ((ctx.tblStudents.Count() % PageSize) != 0)
                {
                    res++;
                }

                ViewBag.TotalPages = res;
                studlist = ctx.tblStudents.OrderByDescending(o => o.Id).Skip(skipCount).Take(PageSize).ToList();
            }
            return View(studlist);
        }
        public ActionResult footer()
        {
            ViewBag.allFooters = getAllFooters();
            return View();
        }
        [HttpPost]
        public ActionResult footer(VMFooter _footer)
        {
            using (var ctx = new LibraryManagementEntities())
            {






                SqlParameter DisplayText = new SqlParameter()
                {
                    ParameterName = "@DisplayText",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50,
                    Value = _footer.DisplayText
                };


                SqlParameter LinUrl = new SqlParameter()
                {
                    ParameterName = "@LinkUrl",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 500,
                    Value = _footer.LinkUrl
                };







                SqlParameter SortOrder = new SqlParameter()
                {
                    ParameterName = "@SortOrder",
                    SqlDbType = SqlDbType.Int,
                    Value = _footer.SortOrder
                };



                SqlParameter pResponseCode = new SqlParameter()
                {
                    ParameterName = "@ResCode",
                    SqlDbType = SqlDbType.Int,
                    Value = 0,
                    Direction = ParameterDirection.InputOutput
                };



                SqlParameter pResponseMessage = new SqlParameter()
                {
                    ParameterName = "@ResMsg",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 8000,
                    Value = "",
                    Direction = ParameterDirection.InputOutput
                };





                ctx.Database.ExecuteSqlCommand("Exec InsertFooterLink @DisplayText, @LinkUrl, @SortOrder,@ResCode OUT,@ResMsg OUT",
                    DisplayText, LinUrl, SortOrder, pResponseCode, pResponseMessage);


                ViewBag.msg = pResponseMessage.Value.ToString();
               


            }
            ViewBag.allFooters = getAllFooters();
            return View();
        }

        private dynamic getAllFooters()
        {
            List<VMFooter> olist = new List<VMFooter>();
            using (var ctx = new LibraryManagementEntities())
            {



                olist = ctx.Database.SqlQuery<VMFooter>("Exec GetFooter").ToList();

            }
            return olist;
        }
    }
}
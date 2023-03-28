using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryManagement.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserLogin obj)
        {
            using (var ctx=new LibraryManagementEntities())
            {
                var Oldstud = ctx.tblStudents.Where(w => w.EmailId == obj.UserName && w.Password == obj.Password).FirstOrDefault();
                if (Oldstud!=null)
                {
                    Random rd = new Random();
                   int otp = rd.Next(1001, 9999);
                    //send otp on user email
                    TempData["UID"] = Oldstud.Id;
                    TempData["OTP"] = otp;
                    return RedirectToAction("VerifyOtp");
                }
                else
                {
                    ViewBag.msg = "Invalid credentials.";
                }
            }
            return View();
        }

        public ActionResult Verifyotp()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Verifyotp(Otpverification obj)
        {
            int oldotp = Convert.ToInt32(TempData.Peek("OTP"));
            if (obj.OTP==oldotp)
            {
                string UserID = TempData["UID"].ToString();
                FormsAuthentication.SetAuthCookie(UserID, false);
                return RedirectToAction("Create","Student");
            }
            ViewBag.msg = "Entered otp is wrong.";
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
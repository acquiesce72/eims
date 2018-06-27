using EmployeeInformationManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmployeeInformationManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private MyDbContext db = new MyDbContext();
        public ActionResult Login()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Login(User user)
        {
            var usr = db.Users.Where(a => a.deleted == false).FirstOrDefault(u => u.username == user.username && u.password == user.password);
            if (usr != null)
            {

                usr.last_login = DateTime.Now;
                await db.SaveChangesAsync();

                Session["UserID"] = usr.user_id.ToString();
                Session["Username"] = usr.username.ToString();
                Session["User_firstname"] = usr.firstname.ToString();
                Session["my_id"] = usr.my_id.ToString();

                if (usr.middlename != null) { Session["User_middlename"] = usr.middlename.ToString(); }
                else { Session["User_middlename"] = string.Empty; }
                
                Session["User_lastname"] = usr.lastname.ToString();
                DateTime dt = Convert.ToDateTime(usr.datejoined.ToString());
                var date = dt.ToString("MMM. dd, yyyy");
                Session["User_datejoined"] = date;
                Session["User_role"] = usr.role.ToString();

                if (Session["User_role"].ToString() == "President") { Session["skin"] = "hold-transition skin-blue sidebar-mini"; Session["dept"] = string.Empty; Session["emp_type"] = string.Empty; TempData["t_in"] = "in"; return RedirectToAction("Index", "Home"); }
                else if (Session["User_role"].ToString() == "VPA") { Session["skin"] = "hold-transition skin-yellow sidebar-mini"; Session["dept"] = string.Empty; Session["emp_type"] = "Personnel"; TempData["t_in"] = "in"; return RedirectToAction("Index", "Home"); }              
                else if (Session["User_role"].ToString() == "VPAA") { Session["skin"] = "hold-transition skin-yellow sidebar-mini"; Session["dept"] = string.Empty; Session["emp_type"] = "Faculty"; TempData["t_in"] = "in"; return RedirectToAction("Index", "Home"); }
                else if (Session["User_role"].ToString() == "Dean SAS") { Session["skin"] = "hold-transition skin-red sidebar-mini"; Session["dept"]= "SAS"; Session["emp_type"] = string.Empty; TempData["t_in"] = "in"; return RedirectToAction("Index", "Home"); }
                else if (Session["User_role"].ToString() == "Dean SBA") { Session["skin"] = "hold-transition skin-red sidebar-mini"; Session["dept"] = "SBA"; Session["emp_type"] = string.Empty; TempData["t_in"] = "in"; return RedirectToAction("Index", "Home"); }
                else if (Session["User_role"].ToString() == "Dean SE") { Session["skin"] = "hold-transition skin-red sidebar-mini"; Session["dept"] = "SE"; Session["emp_type"] = string.Empty; TempData["t_in"] = "in"; return RedirectToAction("Index", "Home"); }
                else if (Session["User_role"].ToString() == "Dean SEA") { Session["skin"] = "hold-transition skin-red sidebar-mini"; Session["dept"] = "SEA"; Session["emp_type"] = string.Empty; TempData["t_in"] = "in"; return RedirectToAction("Index", "Home"); }
                else if (Session["User_role"].ToString() == "Dean SIT") { Session["skin"] = "hold-transition skin-red sidebar-mini"; Session["dept"] = "SIT"; Session["emp_type"] = string.Empty; TempData["t_in"] = "in"; return RedirectToAction("Index", "Home"); }
                else if (Session["User_role"].ToString() == "Dean SN") { Session["skin"] = "hold-transition skin-red sidebar-mini"; Session["dept"] = "SN"; Session["emp_type"] = string.Empty; TempData["t_in"] = "in"; return RedirectToAction("Index", "Home"); }
                else if (Session["User_role"].ToString() == "Principal Elementary") { Session["skin"] = "hold-transition skin-purple sidebar-mini"; Session["dept"] = "SBE (Elementary)"; Session["emp_type"] = string.Empty; TempData["t_in"] = "in"; return RedirectToAction("Index", "Home"); }
                else if (Session["User_role"].ToString() == "Principal High School") { Session["skin"] = "hold-transition skin-purple sidebar-mini"; Session["dept"] = "SBE (High School)"; Session["emp_type"] = string.Empty; TempData["t_in"] = "in"; return RedirectToAction("Index", "Home"); }
                else if (Session["User_role"].ToString() == "Employee") { Session["skin"] = "hold-transition skin-green sidebar-mini"; Session["dept"] = string.Empty; Session["emp_type"] = string.Empty; TempData["t_in"] = "in"; return RedirectToAction("Details", "Employee", new { id = Session["my_id"]}); }                
                else { Session["skin"] = "hold-transition skin-black sidebar-mini"; Session["dept"] = string.Empty; Session["emp_type"] = string.Empty; TempData["t_in"] = "in"; return RedirectToAction("Index", "Home"); }
                                          
            }
               
            else
            {
                ModelState.AddModelError("", "Username or Password is incorrect");    
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }

    }
}
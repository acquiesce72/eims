using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeInformationManagementSystem.Models;

namespace EmployeeInformationManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private MyDbContext db = new MyDbContext();

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public async Task<ActionResult> Index()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveAccountListUser = "class = active";
                ViewBag.ActiveTreeUser = "active";

                return View(await db.Users.Where(a => a.deleted == false).ToListAsync());

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public async Task<ActionResult> Details(int? id)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveAccountListUser = "class = active";
                ViewBag.ActiveTreeUser = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
             
                User user = await db.Users.FindAsync(id);

                if (user == null || user.deleted != false)
                {
                    return HttpNotFound();
                }
                return View(user);

            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Create()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveAccountAddUser = "class = active";
                ViewBag.ActiveTreeUser = "active";

                return View();

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "user_id,created_by,my_id,username,password,firstname,middlename,lastname,gender,role,datejoined,is_active,userimage")] User user, HttpPostedFileBase image1)
        {

            if (ModelState.IsValid)
            {

                User new_user = new User();

                if (image1 != null)
                {
                    new_user.userimage = new byte[image1.ContentLength];
                    image1.InputStream.Read(new_user.userimage, 0, image1.ContentLength);
                }

                new_user.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_user.my_id = user.my_id;
                new_user.username = user.username;
                new_user.password = user.password;
                new_user.firstname = user.firstname;
                new_user.middlename = user.middlename;
                new_user.lastname = user.lastname;
                new_user.gender = user.gender;
                new_user.role = user.role;
                new_user.datejoined = DateTime.Now;
                new_user.is_active = user.is_active;

                db.Users.Add(new_user);
              
                await db.SaveChangesAsync();

            }

            TempData["t_user"] = "added";
            return RedirectToAction("Index");

        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveAccountListUser = "class = active";
                ViewBag.ActiveTreeUser = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = await db.Users.FindAsync(id);

                if (user == null || user.deleted != false)
                {
                    return HttpNotFound();
                }

                return View(user);

            }

            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "user_id,updated_on,updated_by,my_id,password,firstname,middlename,lastname,gender,role,is_active")] User user)
        {
        
            var currentUser = db.Users.FirstOrDefault(p => p.user_id == user.user_id);

            if (currentUser == null)
            {
                return HttpNotFound();
            }

            currentUser.updated_on = DateTime.Now;
            currentUser.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentUser.my_id = user.my_id;
            currentUser.password = user.password;
            currentUser.firstname = user.firstname;
            currentUser.middlename = user.middlename;
            currentUser.lastname = user.lastname;
            currentUser.gender = user.gender;
            currentUser.role = user.role;           
            currentUser.is_active = user.is_active;

            await db.SaveChangesAsync();
            TempData["t_user"] = "updated";
            return RedirectToAction("Index");

        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveAccountListUser = "class = active";
                ViewBag.ActiveTreeUser = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                User user = await db.Users.FindAsync(id);

                if (user == null || user.deleted != false)
                {
                    return HttpNotFound();
                }
                return View(user);

            }

            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {

            User user = await db.Users.FindAsync(id);

            user.deleted = true;
            user.updated_on = DateTime.Now;
            user.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_app"] = "deleted";
            return RedirectToAction("Index");

        }

        public async Task<ActionResult> Picture(int? id)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveAccountListUser = "class = active";
                ViewBag.ActiveTreeUser = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = await db.Users.FindAsync(id);

                if (user == null || user.deleted != false)
                {
                    return HttpNotFound();
                }

                return View(user);

            }

            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Picture(User user, HttpPostedFileBase image1)
        {

            var currentUser = db.Users.FirstOrDefault(p => p.user_id == user.user_id);

            if (currentUser == null)
            {
                return HttpNotFound();
            }

            if (image1 != null)
            {
                currentUser.userimage = new byte[image1.ContentLength];
                image1.InputStream.Read(currentUser.userimage, 0, image1.ContentLength);
            }

            currentUser.updated_on = DateTime.Now;
            currentUser.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_userPic"] = "updated";
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);

        }   
    }
}

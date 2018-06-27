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
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Web.UI;

namespace EmployeeInformationManagementSystem.Controllers
{
    public class SemesterController : Controller
    {
        private MyDbContext db = new MyDbContext();
      
        [OutputCache(NoStore =true, Duration =0, VaryByParam ="*")]
        public async Task<ActionResult> Index()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveSemesterListSemester = "class = active";
                ViewBag.ActiveTreeSemester = "active";

                return View(await db.Semesters.Where(a => a.deleted == false).ToListAsync());
                //return View(await db.Semesters.OrderBy(a => a.semester_id).ToListAsync());               
                
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

                ViewBag.ActiveSemesterAddSemester = "class = active";
                ViewBag.ActiveTreeSemester = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "semester_id,date_created,created_by,description,school_year,school_semester,is_active")] Semester semester)
        {
            if (ModelState.IsValid)
            {

                Semester new_semester = new Semester();

                new_semester.date_created = DateTime.Now;
                new_semester.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_semester.description = semester.description;
                new_semester.school_year = semester.school_year;
                new_semester.school_semester = semester.school_semester;
                new_semester.is_active = semester.is_active;

                db.Semesters.Add(new_semester);
                TempData["t_sem"] = "added";
                await db.SaveChangesAsync();

            }

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

                ViewBag.ActiveSemesterListSemester = "class = active";
                ViewBag.ActiveTreeSemester = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Semester semester = await db.Semesters.FindAsync(id);

                if (semester == null || semester.deleted != false)
                {
                    return HttpNotFound();
                }
                return View(semester);
            }

            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "semester_id,updated_on,updated_by,description,school_year,school_semester,is_active")] Semester semester)
        {
            var currentSemester = db.Semesters.FirstOrDefault(s => s.semester_id == semester.semester_id);

            if (currentSemester == null)
            {
                return HttpNotFound();
            }

            currentSemester.updated_on = DateTime.Now;
            currentSemester.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentSemester.description = semester.description;
            currentSemester.school_year = semester.school_year;
            currentSemester.school_semester = semester.school_semester;
            currentSemester.is_active = semester.is_active;

            await db.SaveChangesAsync();
            TempData["t_sem"] = "updated";
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

                ViewBag.ActiveSemesterListSemester = "class = active";
                ViewBag.ActiveTreeSemester = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Semester semester = await db.Semesters.FindAsync(id);

                if (semester == null || semester.deleted != false)
                {
                    return HttpNotFound();
                }
                return View(semester);
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
            Semester semester = await db.Semesters.FindAsync(id);

            semester.deleted = true;
            semester.updated_on = DateTime.Now;
            semester.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_sem"] = "deleted";
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

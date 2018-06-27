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

namespace EmployeeInformationManagementSystem.Controllers
{
    public class TrainingSeminarController : Controller
    {
        private MyDbContext db = new MyDbContext();

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public async Task<ActionResult> Index()
        {
            if (Session["UserID"] != null)
            {
                var role = Session["User_role"].ToString();

                ViewBag.ActiveTrainingAndSeminarListTrainingAndSeminar = "class = active";
                ViewBag.ActiveTreeTrainingAndSeminar = "active";

                if (Session["User_role"].ToString() == role && Session["User_role"].ToString() != "Administrator" && Session["User_role"].ToString() != "President" && Session["User_role"].ToString() != "VPA" && Session["User_role"].ToString() != "VPAA")
                {
                    return HttpNotFound();
                }

                else
                {
                    return View(await db.TrainingSeminars.Where(a => a.deleted == false).ToListAsync());
                }                
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        /*
        public async Task<ActionResult> Details(int? id)
        {
            if (Session["UserID"] != null)
            {

                ViewBag.ActiveTrainingAndSeminarListTrainingAndSeminar = "class = active";
                ViewBag.ActiveTreeTrainingAndSeminar = "active";

                var role = Session["User_role"].ToString();

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                TrainingSeminar trainingseminar = await db.TrainingSeminars.FindAsync(id);

                if (trainingseminar == null)
                {
                    return HttpNotFound();
                }

                return View(trainingseminar);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }*/

        public ActionResult Create()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveTrainingAndSeminarAddTrainingAndSeminar = "class = active";
                ViewBag.ActiveTreeTrainingAndSeminar = "active";
                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ts_id,date_created,created_by,title,nature,sponsor,location,date_start,date_end,ts_level,number_of_hours")] TrainingSeminar trainingseminar)
        {
            if (ModelState.IsValid)
            {
                TrainingSeminar new_trainingseminar = new TrainingSeminar();

                new_trainingseminar.date_created = DateTime.Now;
                new_trainingseminar.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_trainingseminar.title = trainingseminar.title;
                new_trainingseminar.nature = trainingseminar.nature;
                new_trainingseminar.sponsor = trainingseminar.sponsor;
                new_trainingseminar.location = trainingseminar.location;
                new_trainingseminar.date_start = trainingseminar.date_start;
                new_trainingseminar.date_end = trainingseminar.date_end;
                new_trainingseminar.ts_level = trainingseminar.ts_level;
                new_trainingseminar.number_of_hours = trainingseminar.number_of_hours;

                db.TrainingSeminars.Add(new_trainingseminar);
                TempData["t_ts"] = "added";
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

                ViewBag.ActiveTrainingAndSeminarListTrainingAndSeminar = "class = active";
                ViewBag.ActiveTreeTrainingAndSeminar = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                TrainingSeminar trainingseminar = await db.TrainingSeminars.FindAsync(id);

                if (trainingseminar == null || trainingseminar.deleted != false)
                {
                    return HttpNotFound();
                }
                return View(trainingseminar);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ts_id,updated_on,updated_by,title,nature,sponsor,location,date_start,date_end,ts_level,number_of_hours")] TrainingSeminar trainingseminar)
        {
            var current_trainingseminar = db.TrainingSeminars.FirstOrDefault(ts => ts.ts_id == trainingseminar.ts_id);

            if (current_trainingseminar == null)
            {
                return HttpNotFound();
            }

            current_trainingseminar.updated_on = DateTime.Now;
            current_trainingseminar.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            current_trainingseminar.title = trainingseminar.title;
            current_trainingseminar.nature = trainingseminar.nature;
            current_trainingseminar.sponsor = trainingseminar.sponsor;
            current_trainingseminar.location = trainingseminar.location;
            current_trainingseminar.date_start = trainingseminar.date_start;
            current_trainingseminar.date_end = trainingseminar.date_end;
            current_trainingseminar.ts_level = trainingseminar.ts_level;
            current_trainingseminar.number_of_hours = trainingseminar.number_of_hours;

            await db.SaveChangesAsync();
            TempData["t_ts"] = "updated";
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

                ViewBag.ActiveTrainingAndSeminarListTrainingAndSeminar = "class = active";
                ViewBag.ActiveTreeTrainingAndSeminar = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                TrainingSeminar trainingseminar = await db.TrainingSeminars.FindAsync(id);

                if (trainingseminar == null || trainingseminar.deleted != false)
                {
                    return HttpNotFound();
                }
                return View(trainingseminar);
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
            TrainingSeminar trainingseminar = await db.TrainingSeminars.FindAsync(id);

            trainingseminar.deleted = true;
            trainingseminar.updated_on = DateTime.Now;
            trainingseminar.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            
            await db.SaveChangesAsync();
            TempData["t_ts"] = "deleted";
            return RedirectToAction("Index");
           
        }

        public ActionResult TrainingSeminarList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                DateTime datenow = DateTime.Now;

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "TrainingSeminarList.rpt"));
                rd.SetDataSource(db.TrainingSeminars.Where(d => d.deleted == false).Select(p => new
                {
                    
                    ts_id = p.ts_id,
                    title = p.title == null ? "" : p.title,
                    nature = p.nature == null ? "" : p.nature,
                    sponsor = p.sponsor == null ? "" : p.sponsor,
                    location = p.location == null ? "" : p.location,
                    ts_level = p.ts_level == null ? "" : p.ts_level,
                    date_start = p.date_start,
                    date_end = p.date_end,
                    number_of_hours = p.number_of_hours == null ? "" : p.number_of_hours,

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "training&seminar_list.pdf");
                }
                catch
                {
                    throw;
                }
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
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

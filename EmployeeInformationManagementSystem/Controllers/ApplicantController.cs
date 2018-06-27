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
    public class ApplicantController : Controller
    {
        private MyDbContext db = new MyDbContext();

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public async Task<ActionResult> Index()
        {

            if (Session["UserID"] != null)
            {
                var role = Session["User_role"].ToString();

                ViewBag.ActiveApplicantListApplicant = "class = active";
                ViewBag.ActiveTreeApplicant = "active";

                if (Session["User_role"].ToString() == role && Session["User_role"].ToString() != "Administrator" && Session["User_role"].ToString() != "President" && Session["User_role"].ToString() != "VPA" && Session["User_role"].ToString() != "VPAA")
                {
                    return HttpNotFound();
                }

                else
                {
                    return View(await db.Applicants.Where(a => a.deleted == false).ToListAsync());
                }
                        
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public async Task<ActionResult> Details(int? id)
        {
            if (Session["UserID"] != null)
            {
                ViewBag.ActiveApplicantListApplicant = "class = active";
                ViewBag.ActiveTreeApplicant = "active";

                var role = Session["User_role"].ToString();

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Applicant applicant = await db.Applicants.FindAsync(id);

                ViewBag.ApplicantEducationalBackground = db.ApplicantEducationalBackgrounds.Where(i => i.applicant_id == id && i.deleted == false);
                ViewBag.ApplicantExperience = db.ApplicantExperiences.Where(i => i.applicant_id == id && i.deleted == false);
                ViewBag.ApplicantTraining = db.ApplicantTrainings.Where(i => i.applicant_id == id && i.deleted == false);

                if (Session["User_role"].ToString() == "Employee")
                {
                    return HttpNotFound();
                }

                if (Session["User_role"].ToString() == role && Session["User_role"].ToString() != "Administrator" && Session["User_role"].ToString() != "President" && Session["User_role"].ToString() != "VPA" && Session["User_role"].ToString() != "VPAA")
                {
                    if (applicant == null || applicant.deleted != false)
                    {
                        return HttpNotFound();
                    }
                }

                else
                {
                    if (applicant == null || applicant.deleted != false)
                    {
                        return HttpNotFound();
                    }
                }
                
                return View(applicant);
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

                ViewBag.ActiveApplicantAddApplicant = "class = active";
                ViewBag.ActiveTreeApplicant = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "applicant_id,date_created,created_by,firstname,middlename,lastname,birth_date,birth_place,gender,civil_status,contact_number,address,blood_type,religion,objectives,applicant_image")] Applicant applicant, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                Applicant new_applicant = new Applicant();

                if (image1 != null)
                {
                    new_applicant.applicant_image = new byte[image1.ContentLength];
                    image1.InputStream.Read(new_applicant.applicant_image, 0, image1.ContentLength);
                }

                new_applicant.date_created = DateTime.Now;
                new_applicant.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_applicant.firstname = applicant.firstname;
                new_applicant.middlename = applicant.middlename;
                new_applicant.lastname = applicant.lastname;
                new_applicant.birth_date = applicant.birth_date;
                new_applicant.birth_place = applicant.birth_place;
                new_applicant.gender = applicant.gender;
                new_applicant.civil_status = applicant.civil_status;
                new_applicant.contact_number = applicant.contact_number;
                new_applicant.address = applicant.address;
                new_applicant.blood_type = applicant.blood_type;
                new_applicant.religion = applicant.religion;
                new_applicant.objectives = applicant.objectives;

                db.Applicants.Add(new_applicant);

                await db.SaveChangesAsync();
               
            }
            TempData["t_app"] = "added";
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

                ViewBag.ActiveApplicantListApplicant = "class = active";
                ViewBag.ActiveTreeApplicant = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Applicant applicant = await db.Applicants.FindAsync(id);

                if (applicant == null || applicant.deleted != false)
                {
                    return HttpNotFound();
                }
                return View(applicant);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "applicant_id,updated_on,updated_by,firstname,middlename,lastname,birth_date,birth_place,gender,civil_status,contact_number,address,blood_type,religion,objectives")] Applicant applicant)
        {
            var currentApplicant = db.Applicants.FirstOrDefault(a => a.applicant_id == applicant.applicant_id);

            if (currentApplicant == null)
            {
                return HttpNotFound();
            }

            currentApplicant.updated_on = DateTime.Now;
            currentApplicant.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentApplicant.firstname = applicant.firstname;
            currentApplicant.middlename = applicant.middlename;
            currentApplicant.lastname = applicant.lastname;
            currentApplicant.birth_date = applicant.birth_date;
            currentApplicant.birth_place = applicant.birth_place;
            currentApplicant.gender = applicant.gender;
            currentApplicant.civil_status = applicant.civil_status;
            currentApplicant.contact_number = applicant.contact_number;
            currentApplicant.address = applicant.address;
            currentApplicant.blood_type = applicant.blood_type;
            currentApplicant.religion = applicant.religion;
            currentApplicant.objectives = applicant.objectives;

            await db.SaveChangesAsync();
            TempData["t_app"] = "added";
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

                ViewBag.ActiveApplicantListApplicant = "class = active";
                ViewBag.ActiveTreeApplicant = "active";

                ViewBag.ApplicantEducationalBackground = db.ApplicantEducationalBackgrounds.Where(i => i.applicant_id == id && i.deleted == false);
                ViewBag.ApplicantExperience = db.ApplicantExperiences.Where(i => i.applicant_id == id && i.deleted == false);
                ViewBag.ApplicantTraining = db.ApplicantTrainings.Where(i => i.applicant_id == id && i.deleted == false);

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Applicant applicant = await db.Applicants.FindAsync(id);

                if (applicant == null || applicant.deleted != false)
                {
                    return HttpNotFound();
                }
                return View(applicant);
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
            Applicant applicant = await db.Applicants.FindAsync(id);

            applicant.deleted = true;
            applicant.updated_on = DateTime.Now;
            applicant.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_app"] = "added";
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

                ViewBag.ActiveApplicantListApplicant = "class = active";
                ViewBag.ActiveTreeApplicant = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Applicant applicant = await db.Applicants.FindAsync(id);

                if (applicant == null || applicant.deleted != false)
                {
                    return HttpNotFound();
                }

                return View(applicant);

            }

            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Picture(Applicant applicant, HttpPostedFileBase image1)
        {

            var currentApplicant = db.Applicants.FirstOrDefault(a => a.applicant_id == applicant.applicant_id);

            if (currentApplicant == null)
            {
                return HttpNotFound();
            }

            if (image1 != null)
            {
                currentApplicant.applicant_image = new byte[image1.ContentLength];
                image1.InputStream.Read(currentApplicant.applicant_image, 0, image1.ContentLength);
            }
            currentApplicant.updated_on = DateTime.Now;
            currentApplicant.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_appPic"] = "updated";
            return RedirectToAction("Index");

        }

        public ActionResult EducationalBackground()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveApplicantListApplicant = "class = active";
                ViewBag.ActiveTreeApplicant = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EducationalBackground([Bind(Include = "eb_id,applicant_id,date_created,created_by,school,school_level,year_graduated,honors")] ApplicantEducationalBackground applicanteducationalbackground, int id)
        {
            if (ModelState.IsValid)
            {
                ApplicantEducationalBackground new_applicanteducationalbackground = new ApplicantEducationalBackground();

                new_applicanteducationalbackground.applicant_id = id;
                new_applicanteducationalbackground.date_created = DateTime.Now;
                new_applicanteducationalbackground.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_applicanteducationalbackground.school = applicanteducationalbackground.school;
                new_applicanteducationalbackground.school_level = applicanteducationalbackground.school_level;
                new_applicanteducationalbackground.year_graduated = applicanteducationalbackground.year_graduated;
                new_applicanteducationalbackground.honors = applicanteducationalbackground.honors;

                db.ApplicantEducationalBackgrounds.Add(new_applicanteducationalbackground);
                

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditEducationalBackground(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveApplicantListApplicant = "class = active";
                ViewBag.ActiveTreeApplicant = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ApplicantEducationalBackground applicanteducationalbackground = await db.ApplicantEducationalBackgrounds.FindAsync(id);        
                Applicant applicant = await db.Applicants.FindAsync(back);

                if (applicanteducationalbackground == null || applicant == null || applicanteducationalbackground.deleted != false || applicant.deleted != false || ((applicanteducationalbackground.applicant_id == applicant.applicant_id) == (applicant.deleted == true)))
                {
                    return HttpNotFound();                         
                }

                return View(applicanteducationalbackground);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditEducationalBackground([Bind(Include = "eb_id,updated_on,updated_by,school,school_level,year_graduated,honors")] ApplicantEducationalBackground applicanteducationalbackground, int back)
        {
            var currentApplicantEducationalBackground = db.ApplicantEducationalBackgrounds.FirstOrDefault(a => a.eb_id == applicanteducationalbackground.eb_id);

            if (currentApplicantEducationalBackground == null)
            {
                return HttpNotFound();
            }

            currentApplicantEducationalBackground.updated_on = DateTime.Now;
            currentApplicantEducationalBackground.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentApplicantEducationalBackground.school = applicanteducationalbackground.school;
            currentApplicantEducationalBackground.school_level = applicanteducationalbackground.school_level;
            currentApplicantEducationalBackground.year_graduated = applicanteducationalbackground.year_graduated;
            currentApplicantEducationalBackground.honors = applicanteducationalbackground.honors;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteEducationalBackground(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveApplicantListApplicant = "class = active";
                ViewBag.ActiveTreeApplicant = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ApplicantEducationalBackground applicanteducationalbackground = await db.ApplicantEducationalBackgrounds.FindAsync(id);
                Applicant applicant = await db.Applicants.FindAsync(back);

                if (applicanteducationalbackground == null || applicant == null || applicanteducationalbackground.deleted != false || applicant.deleted != false || ((applicanteducationalbackground.applicant_id == applicant.applicant_id) == (applicant.deleted == true)))
                {
                    return HttpNotFound();
                }
                return View(applicanteducationalbackground);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteEducationalBackground(int id, int back)
        {
            ApplicantEducationalBackground applicanteducationalbackground = await db.ApplicantEducationalBackgrounds.FindAsync(id);

            applicanteducationalbackground.deleted = true;
            applicanteducationalbackground.updated_on = DateTime.Now;
            applicanteducationalbackground.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult Experience()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveApplicantListApplicant = "class = active";
                ViewBag.ActiveTreeApplicant = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Experience([Bind(Include = "e_id,applicant_id,date_created,created_by,job_title,nature,date_start,date_end,reference,number_of_hours")] ApplicantExperience applicantexperience, int id)
        {
            if (ModelState.IsValid)
            {
                ApplicantExperience new_applicantexperience = new ApplicantExperience();

                new_applicantexperience.applicant_id = id;
                new_applicantexperience.date_created = DateTime.Now;
                new_applicantexperience.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_applicantexperience.job_title = applicantexperience.job_title;
                new_applicantexperience.nature = applicantexperience.nature;
                new_applicantexperience.date_start = applicantexperience.date_start;
                new_applicantexperience.date_end = applicantexperience.date_end;
                new_applicantexperience.reference = applicantexperience.reference;
                new_applicantexperience.number_of_hours = applicantexperience.number_of_hours;

                db.ApplicantExperiences.Add(new_applicantexperience);
                TempData["t_Info"] = "added";
                await db.SaveChangesAsync();

            }

            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditExperience(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveApplicantListApplicant = "class = active";
                ViewBag.ActiveTreeApplicant = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ApplicantExperience applicantexperience = await db.ApplicantExperiences.FindAsync(id);
                Applicant applicant = await db.Applicants.FindAsync(back);

                if (applicantexperience == null || applicant == null || applicantexperience.deleted != false || applicant.deleted != false || ((applicantexperience.applicant_id == applicant.applicant_id) == (applicant.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(applicantexperience);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditExperience([Bind(Include = "e_id,updated_on,updated_by,job_title,nature,date_start,date_end,reference,number_of_hours")] ApplicantExperience applicantexperience, int back)
        {
            var currentApplicantExperience = db.ApplicantExperiences.FirstOrDefault(a => a.e_id == applicantexperience.e_id);

            if (currentApplicantExperience == null)
            {
                return HttpNotFound();
            }

            currentApplicantExperience.updated_on = DateTime.Now;
            currentApplicantExperience.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentApplicantExperience.job_title = applicantexperience.job_title;
            currentApplicantExperience.nature = applicantexperience.nature;
            currentApplicantExperience.date_start = applicantexperience.date_start;
            currentApplicantExperience.date_end = applicantexperience.date_end;
            currentApplicantExperience.reference = applicantexperience.reference;
            currentApplicantExperience.number_of_hours = applicantexperience.number_of_hours;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteExperience(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveApplicantListApplicant = "class = active";
                ViewBag.ActiveTreeApplicant = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ApplicantExperience applicantexperience = await db.ApplicantExperiences.FindAsync(id);
                Applicant applicant = await db.Applicants.FindAsync(back);

                if (applicantexperience == null || applicant == null || applicantexperience.deleted != false || applicant.deleted != false || ((applicantexperience.applicant_id == applicant.applicant_id) == (applicant.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(applicantexperience);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteExperience(int id, int back)
        {
            ApplicantExperience applicantexperience = await db.ApplicantExperiences.FindAsync(id);

            applicantexperience.deleted = true;
            applicantexperience.updated_on = DateTime.Now;
            applicantexperience.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult Training()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveApplicantListApplicant = "class = active";
                ViewBag.ActiveTreeApplicant = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Training([Bind(Include = "t_id,applicant_id,date_created,created_by,title,sponsor,date_start,date_end,number_of_hours")] ApplicantTraining applicanttraining, int id)
        {
            if (ModelState.IsValid)
            {
                ApplicantTraining new_applicanttraining = new ApplicantTraining();

                new_applicanttraining.applicant_id = id;
                new_applicanttraining.date_created = DateTime.Now;
                new_applicanttraining.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_applicanttraining.title = applicanttraining.title;
                new_applicanttraining.sponsor = applicanttraining.sponsor;
                new_applicanttraining.date_start = applicanttraining.date_start;
                new_applicanttraining.date_end = applicanttraining.date_end;
                new_applicanttraining.number_of_hours = applicanttraining.number_of_hours;

                db.ApplicantTrainings.Add(new_applicanttraining);
                TempData["t_Info"] = "added";
                await db.SaveChangesAsync();

            }

            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditTraining(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveApplicantListApplicant = "class = active";
                ViewBag.ActiveTreeApplicant = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ApplicantTraining applicanttraining = await db.ApplicantTrainings.FindAsync(id);
                Applicant applicant = await db.Applicants.FindAsync(back);

                if (applicanttraining == null || applicant == null || applicanttraining.deleted != false || applicant.deleted != false || ((applicanttraining.applicant_id == applicant.applicant_id) == (applicant.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(applicanttraining);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTraining([Bind(Include = "t_id,updated_on,updated_by,title,sponsor,date_start,date_end,number_of_hours")] ApplicantTraining applicanttraining, int back)
        {
            var currentApplicantTraining = db.ApplicantTrainings.FirstOrDefault(a => a.t_id == applicanttraining.t_id);

            if (currentApplicantTraining == null)
            {
                return HttpNotFound();
            }

            currentApplicantTraining.updated_on = DateTime.Now;
            currentApplicantTraining.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentApplicantTraining.title = applicanttraining.title;
            currentApplicantTraining.sponsor = applicanttraining.sponsor;
            currentApplicantTraining.date_start = applicanttraining.date_start;
            currentApplicantTraining.date_end = applicanttraining.date_end;
            currentApplicantTraining.number_of_hours = applicanttraining.number_of_hours;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteTraining(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveApplicantListApplicant = "class = active";
                ViewBag.ActiveTreeApplicant = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ApplicantTraining applicanttraining = await db.ApplicantTrainings.FindAsync(id);
                Applicant applicant = await db.Applicants.FindAsync(back);

                if (applicanttraining == null || applicant == null || applicanttraining.deleted != false || applicant.deleted != false || ((applicanttraining.applicant_id == applicant.applicant_id) == (applicant.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(applicanttraining);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteTraining(int id, int back)
        {
            ApplicantTraining applicanttraining = await db.ApplicantTrainings.FindAsync(id);

            applicanttraining.deleted = true;
            applicanttraining.updated_on = DateTime.Now;
            applicanttraining.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult ApplicantList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "ApplicantList.rpt"));
                rd.SetDataSource(db.Applicants.Where(d => d.deleted == false).Select(p => new
                {
                    applicant_id = p.applicant_id,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    birth_date = p.birth_date,
                    birth_place = p.birth_place == null ? "" : p.birth_place,
                    gender = p.gender == null ? "" : p.gender,
                    address = p.address == null ? "" : p.address,
                    contact_number = p.contact_number == null ? "" : p.contact_number,
                    civil_status = p.civil_status == null ? "" : p.civil_status,

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "applicant_list.pdf");
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

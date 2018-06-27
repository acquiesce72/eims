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
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;


namespace EmployeeInformationManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private MyDbContext db = new MyDbContext();

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public async Task<ActionResult> Index()
        {         
            if (Session["UserID"] != null)
            {
                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                var dept = Session["dept"].ToString();
                var emp_type = Session["emp_type"].ToString();
                var role = Session["User_role"].ToString();

                if (Session["User_role"].ToString() == "Employee")
                {
                    return HttpNotFound();
                }

                if (Session["User_role"].ToString() == role && Session["User_role"].ToString() != "Administrator" && Session["User_role"].ToString() != "President" && Session["User_role"].ToString() != "VPA" && Session["User_role"].ToString() != "VPAA")
                {
                    return View(await db.Employees.Where(a => a.deleted == false && a.is_active == true && a.department == dept).ToListAsync());
                }

                if (Session["User_role"].ToString() == "VPA" || Session["User_role"].ToString() == "VPAA")
                {
                    return View(await db.Employees.Where(a => a.deleted == false && a.is_active == true && a.employment_type == emp_type).ToListAsync());
                }

                else
                {
                    return View(await db.Employees.Where(a => a.deleted == false && a.is_active == true).ToListAsync());
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
                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";
                ViewBag.EmployeeEducationalBackground = db.EmployeeEducationalBackgrounds.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeScholarship = db.EmployeeScholarships.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeTeachingExperience = db.EmployeeTeachingExperiences.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeInnovation = db.EmployeeInnovations.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeAdministrativeExperience = db.EmployeeAdministrativeExperiences.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeServiceCoach = db.EmployeeServiceCoaches.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeServiceAward = db.EmployeeServiceAwards.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeAcademicHonor = db.EmployeeAcademicHonors.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeePublishedResearchBook = db.EmployeePublishedResearchBooks.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeMembershipProfessionalOrganization = db.EmployeeMembershipProfessionalOrganizations.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeServiceAccreditation = db.EmployeeServiceAccreditations.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeContinuingProfessionalEducation = db.EmployeeContinuingProfessionalEducations.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeChildren = db.EmployeeChildrens.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeServicePRCExaminer = db.EmployeeServicePRCExaminers.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeLicensureExamination = db.EmployeeLicensureExaminations.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeServiceConsultant = db.EmployeeServiceConsultants.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeServiceAdviser = db.EmployeeServiceAdvisers.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeBeneficiaries = db.EmployeeRecipients.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeTraining = db.EmployeeTrainings.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeePerformance = db.EmployeePerformances.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeDateOrganization = db.EmployeeDateOrganizations.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeServiceRecord = db.EmployeeServiceRecords.Where(i => i.employee_id == id && i.deleted == false);

                var dept = Session["dept"].ToString();
                var role = Session["User_role"].ToString();
                var emp_type = Session["emp_type"].ToString();

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Employee employee = await db.Employees.FindAsync(id);

                if (Session["User_role"].ToString() == role && Session["User_role"].ToString() != "Administrator" && Session["User_role"].ToString() != "President" && Session["User_role"].ToString() != "VPA" && Session["User_role"].ToString() != "VPAA" && Session["User_role"].ToString() != "Employee")
                {
                    if (employee == null || employee.deleted != false || employee.is_active == false || employee.department != dept)                                     
                    {
                        return HttpNotFound();
                    }                   
                }

                if (Session["User_role"].ToString() == "VPA" || Session["User_role"].ToString() == "VPAA")
                {
                    if (employee == null || employee.deleted != false || employee.is_active == false || employee.employment_type != emp_type)
                    {
                        return HttpNotFound();
                    }
                }

                if (Session["User_role"].ToString() == "Employee")
                {
                    ViewBag.ActiveEmployeeRecord = "class = active";

                    int this_id = Convert.ToInt32(Session["my_id"]) + 1;

                    if (employee == null || employee.deleted != false || employee.is_active == false || id != (this_id - 1))
                    {
                        return HttpNotFound();
                    }
                }

                else
                {
                    if (employee == null || employee.deleted != false || employee.is_active == false)
                    {
                        return HttpNotFound();
                    }
                }

                return View(employee);
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

                ViewBag.ActiveEmployeeAddEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";
                //ViewBag.Semester = new SelectList(db.Semesters, "school_semester", "school_semester");
                ViewBag.Semester = db.Semesters.Where(a => a.deleted == false).Select(p => new SelectListItem
                {
                    Text = p.school_year + " " + p.school_semester,
                    Value = p.school_year + " " + p.school_semester
                });
           
                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "employee_id,date_created,created_by,employee_number,firstname,middlename,lastname,birth_date,birth_place,gender,civil_status,contact_number,address,height,weight,citizenship,blood_type,contact_person,marriage_date,marriage_place,spouse_name,spouse_occupation,father_name,father_occupation,mother_name,mother_occupation,confirmation_date,confirmation_place,is_active,employee_image,sss,tin,pagibig,philhealth,employment_date,department,educational_attainment,date_permanent,appointment_status,employment_type,position,working_status,semester")] Employee employee, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                Employee new_employee = new Employee();

                if (image1 != null)
                {
                    new_employee.employee_image = new byte[image1.ContentLength];
                    image1.InputStream.Read(new_employee.employee_image, 0, image1.ContentLength);
                }

                new_employee.date_created = DateTime.Now;
                new_employee.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employee.employee_number = employee.employee_number;
                new_employee.firstname = employee.firstname;
                new_employee.middlename = employee.middlename;
                new_employee.lastname = employee.lastname;
                new_employee.birth_date = employee.birth_date;
                new_employee.birth_place = employee.birth_place;
                new_employee.gender = employee.gender;
                new_employee.civil_status = employee.civil_status;
                new_employee.contact_number = employee.contact_number;
                new_employee.address = employee.address;
                new_employee.height = employee.height;
                new_employee.weight = employee.weight;
                new_employee.citizenship = employee.citizenship;
                new_employee.blood_type = employee.blood_type;
                new_employee.contact_person = employee.contact_person;
                new_employee.marriage_date = employee.marriage_date;
                new_employee.marriage_place = employee.marriage_place;
                new_employee.spouse_name = employee.spouse_name;
                new_employee.spouse_occupation = employee.spouse_occupation;
                new_employee.father_name = employee.father_name;
                new_employee.father_occupation = employee.father_occupation;
                new_employee.mother_name = employee.mother_name;
                new_employee.mother_occupation = employee.mother_occupation;
                new_employee.confirmation_date = employee.confirmation_date;
                new_employee.confirmation_place = employee.confirmation_place;                     
                new_employee.is_active = true;

                new_employee.sss = employee.sss;
                new_employee.tin = employee.tin;
                new_employee.pagibig = employee.pagibig;
                new_employee.philhealth = employee.philhealth;
                new_employee.employment_date = employee.employment_date;
                new_employee.department = employee.department;
                new_employee.educational_attainment = employee.educational_attainment;
                new_employee.date_permanent = employee.date_permanent;
                new_employee.appointment_status = employee.appointment_status;
                new_employee.employment_type = employee.employment_type;
                new_employee.position = employee.position;
                new_employee.working_status = employee.working_status;
                new_employee.semester = employee.semester;

                db.Employees.Add(new_employee);
                await db.SaveChangesAsync();
                
            }

            TempData["t_emp"] = "added";
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

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                ViewBag.Semester2 = db.Semesters.Select(p => new SelectListItem
                {
                    Text = p.school_year + " " + p.school_semester,
                    Value = p.school_year + " " + p.school_semester
                });

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Employee employee = await db.Employees.FindAsync(id);

                if (employee == null || employee.deleted != false || employee.is_active == false)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }

           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "employee_id,updated_on,updated_by,employee_number,firstname,middlename,lastname,birth_date,birth_place,gender,civil_status,contact_number,address,height,weight,citizenship,blood_type,contact_person,marriage_date,marriage_place,spouse_name,spouse_occupation,father_name,father_occupation,mother_name,mother_occupation,confirmation_date,confirmation_place,is_active,sss,tin,pagibig,philhealth,employment_date,department,educational_attainment,date_permanent,appointment_status,employment_type,position,working_status,semester")] Employee employee)
        {
            var currentEmployee = db.Employees.FirstOrDefault(e => e.employee_id == employee.employee_id);

            if (currentEmployee == null)
            {
                return HttpNotFound();
            }

            currentEmployee.updated_on = DateTime.Now;
            currentEmployee.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployee.firstname = employee.firstname;
            currentEmployee.middlename = employee.middlename;
            currentEmployee.lastname = employee.lastname;
            currentEmployee.birth_date = employee.birth_date;
            currentEmployee.birth_place = employee.birth_place;  
            currentEmployee.gender = employee.gender;
            currentEmployee.civil_status = employee.civil_status;       
            currentEmployee.contact_number = employee.contact_number;
            currentEmployee.address = employee.address;       
            currentEmployee.height = employee.height;
            currentEmployee.weight = employee.weight;
            currentEmployee.citizenship = employee.citizenship;
            currentEmployee.blood_type = employee.blood_type;
            currentEmployee.contact_person = employee.contact_person;
            currentEmployee.marriage_date = employee.marriage_date;
            currentEmployee.marriage_place = employee.marriage_place;
            currentEmployee.spouse_name = employee.spouse_name;
            currentEmployee.spouse_occupation = employee.spouse_occupation;
            currentEmployee.father_name = employee.father_name;
            currentEmployee.father_occupation = employee.father_occupation;
            currentEmployee.mother_name = employee.mother_name;
            currentEmployee.mother_occupation = employee.mother_occupation;
            currentEmployee.confirmation_date = employee.confirmation_date;
            currentEmployee.confirmation_place = employee.confirmation_place;
            currentEmployee.is_active = true;

            currentEmployee.sss = employee.sss;
            currentEmployee.tin = employee.tin;
            currentEmployee.pagibig = employee.pagibig;
            currentEmployee.philhealth = employee.philhealth;
            currentEmployee.employment_date = employee.employment_date;
            currentEmployee.department = employee.department;
            currentEmployee.educational_attainment = employee.educational_attainment;
            currentEmployee.date_permanent = employee.date_permanent;
            currentEmployee.appointment_status = employee.appointment_status;
            currentEmployee.employment_type = employee.employment_type;
            currentEmployee.position = employee.position;
            currentEmployee.working_status = employee.working_status;
            currentEmployee.semester = employee.semester;


            await db.SaveChangesAsync();

            TempData["t_emp"] = "updated";
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

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                ViewBag.EmployeeEducationalBackground = db.EmployeeEducationalBackgrounds.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeScholarship = db.EmployeeScholarships.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeTeachingExperience = db.EmployeeTeachingExperiences.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeInnovation = db.EmployeeInnovations.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeAdministrativeExperience = db.EmployeeAdministrativeExperiences.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeServiceCoach = db.EmployeeServiceCoaches.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeServiceAward = db.EmployeeServiceAwards.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeAcademicHonor = db.EmployeeAcademicHonors.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeePublishedResearchBook = db.EmployeePublishedResearchBooks.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeMembershipProfessionalOrganization = db.EmployeeMembershipProfessionalOrganizations.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeServiceAccreditation = db.EmployeeServiceAccreditations.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeContinuingProfessionalEducation = db.EmployeeContinuingProfessionalEducations.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeChildren = db.EmployeeChildrens.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeServicePRCExaminer = db.EmployeeServicePRCExaminers.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeLicensureExamination = db.EmployeeLicensureExaminations.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeServiceConsultant = db.EmployeeServiceConsultants.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeServiceAdviser = db.EmployeeServiceAdvisers.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeBeneficiaries = db.EmployeeRecipients.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeTraining = db.EmployeeTrainings.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeePerformance = db.EmployeePerformances.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeDateOrganization = db.EmployeeDateOrganizations.Where(i => i.employee_id == id && i.deleted == false);
                ViewBag.EmployeeServiceRecord = db.EmployeeServiceRecords.Where(i => i.employee_id == id && i.deleted == false);

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Employee employee = await db.Employees.FindAsync(id);

                if (employee == null || employee.deleted != false || employee.is_active == false)
                {
                    return HttpNotFound();
                }
                return View(employee);
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
            Employee employee = await db.Employees.FindAsync(id);

            employee.is_active = false;
            employee.updated_on = DateTime.Now;
            employee.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();

            TempData["t_emp"] = "deleted";
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

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Employee employee = await db.Employees.FindAsync(id);

                if (employee == null || employee.deleted != false)
                {
                    return HttpNotFound();
                }

                return View(employee);

            }

            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Picture(Employee employee, HttpPostedFileBase image1)
        {

            var currentEmployee = db.Employees.FirstOrDefault(e => e.employee_id == employee.employee_id);

            if (currentEmployee == null)
            {
                return HttpNotFound();
            }

            if (image1 != null)
            {
                currentEmployee.employee_image = new byte[image1.ContentLength];
                image1.InputStream.Read(currentEmployee.employee_image, 0, image1.ContentLength);
            }

            currentEmployee.updated_on = DateTime.Now;
            currentEmployee.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_empPic"] = "updated";
            return RedirectToAction("Index");

        }

        public async Task<ActionResult> Upload(int? id)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Employee employee = await db.Employees.FindAsync(id);

                if (employee == null || employee.deleted != false)
                {
                    return HttpNotFound();
                }

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase postedFile, int id)
        {
            if (postedFile != null)
            {
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(postedFile.InputStream))
                {
                    bytes = br.ReadBytes(postedFile.ContentLength);
                }
                string constr = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "INSERT INTO EmployeeUploadedFile (employee_id, date_uploaded, uploaded_by, filename, contenttype, data) VALUES (@id, @thisdate, @upby, @filename, @contenttype, @data)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@thisdate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@upby", Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString() );
                        cmd.Parameters.AddWithValue("@filename", Path.GetFileName(postedFile.FileName));
                        cmd.Parameters.AddWithValue("@contenttype", postedFile.ContentType);
                        cmd.Parameters.AddWithValue("@data", bytes);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }

            TempData["t_empUpl"] = "uploaded";
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Download(int? id)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var files = db.EmployeeUploadedFiles.Where(i => i.employee_id == id);

                Employee employee = await db.Employees.FindAsync(id);

                if (files == null || employee == null || employee.deleted != false)
                {
                    return HttpNotFound();
                }

                return View(files);             
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public FileResult DownloadFile(int? fileId)
        {
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT filename, contenttype, data FROM EmployeeUploadedFile WHERE file_id=@Id";
                    cmd.Parameters.AddWithValue("@Id", fileId);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["data"];
                        contentType = sdr["contenttype"].ToString();
                        fileName = sdr["filename"].ToString();
                    }
                    con.Close();
                }
            }

            return File(bytes, contentType, fileName);
        }

        public ActionResult EducationalBackground()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EducationalBackground([Bind(Include = "eb_id,employee_id,date_created,created_by,school,school_level,year_graduated,honors")] EmployeeEducationalBackground employeeeducationalbackground, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeEducationalBackground new_employeeeducationalbackground = new EmployeeEducationalBackground();

                new_employeeeducationalbackground.employee_id = id;
                new_employeeeducationalbackground.date_created = DateTime.Now;
                new_employeeeducationalbackground.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeeeducationalbackground.school = employeeeducationalbackground.school;
                new_employeeeducationalbackground.school_level = employeeeducationalbackground.school_level;
                new_employeeeducationalbackground.year_graduated = employeeeducationalbackground.year_graduated;
                new_employeeeducationalbackground.honors = employeeeducationalbackground.honors;

                db.EmployeeEducationalBackgrounds.Add(new_employeeeducationalbackground);

                
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

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeEducationalBackground employeeeducationalbackground = await db.EmployeeEducationalBackgrounds.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeeducationalbackground == null || employee == null || employeeeducationalbackground.deleted != false || employee.deleted != false || ((employeeeducationalbackground.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeeducationalbackground);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditEducationalBackground([Bind(Include = "eb_id,updated_on,updated_by,school,school_level,year_graduated,honors")] EmployeeEducationalBackground employeeeducationalbackground, int back)
        {
            var currentEmployeeEducationalBackground = db.EmployeeEducationalBackgrounds.FirstOrDefault(a => a.eb_id == employeeeducationalbackground.eb_id);

            if (currentEmployeeEducationalBackground == null)
            {
                return HttpNotFound();
            }

            currentEmployeeEducationalBackground.updated_on = DateTime.Now;
            currentEmployeeEducationalBackground.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeEducationalBackground.school = employeeeducationalbackground.school;
            currentEmployeeEducationalBackground.school_level = employeeeducationalbackground.school_level;
            currentEmployeeEducationalBackground.year_graduated = employeeeducationalbackground.year_graduated;
            currentEmployeeEducationalBackground.honors = employeeeducationalbackground.honors;

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

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeEducationalBackground employeeeducationalbackground = await db.EmployeeEducationalBackgrounds.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeeducationalbackground == null || employee == null || employeeeducationalbackground.deleted != false || employee.deleted != false || ((employeeeducationalbackground.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeeducationalbackground);
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
            EmployeeEducationalBackground employeeeducationalbackground = await db.EmployeeEducationalBackgrounds.FindAsync(id);

            employeeeducationalbackground.deleted = true;
            employeeeducationalbackground.updated_on = DateTime.Now;
            employeeeducationalbackground.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult Scholarship()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Scholarship([Bind(Include = "s_id,employee_id,date_created,created_by,title,nature,sponsor,inclusive_date")] EmployeeScholarship employeescholarship, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeScholarship new_employeescholarship = new EmployeeScholarship();

                new_employeescholarship.employee_id = id;
                new_employeescholarship.date_created = DateTime.Now;
                new_employeescholarship.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeescholarship.title = employeescholarship.title;
                new_employeescholarship.nature = employeescholarship.nature;
                new_employeescholarship.sponsor = employeescholarship.sponsor;
                new_employeescholarship.inclusive_date = employeescholarship.inclusive_date;

                db.EmployeeScholarships.Add(new_employeescholarship);

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditScholarship(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeScholarship employeescholarship = await db.EmployeeScholarships.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeescholarship == null || employee == null || employeescholarship.deleted != false || employee.deleted != false || ((employeescholarship.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeescholarship);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditScholarship([Bind(Include = "s_id,updated_on,updated_by,title,nature,sponsor,inclusive_date")] EmployeeScholarship employeescholarship, int back)
        {
            var currentEmployeeScholarship = db.EmployeeScholarships.FirstOrDefault(a => a.s_id == employeescholarship.s_id);

            if (currentEmployeeScholarship == null)
            {
                return HttpNotFound();
            }

            currentEmployeeScholarship.updated_on = DateTime.Now;
            currentEmployeeScholarship.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeScholarship.title = employeescholarship.title;
            currentEmployeeScholarship.nature = employeescholarship.nature;
            currentEmployeeScholarship.sponsor = employeescholarship.sponsor;
            currentEmployeeScholarship.inclusive_date = employeescholarship.inclusive_date;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteScholarship(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeScholarship employeescholarship = await db.EmployeeScholarships.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeescholarship == null || employee == null || employeescholarship.deleted != false || employee.deleted != false || ((employeescholarship.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeescholarship);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteScholarship(int id, int back)
        {
            EmployeeScholarship employeescholarship = await db.EmployeeScholarships.FindAsync(id);

            employeescholarship.deleted = true;
            employeescholarship.updated_on = DateTime.Now;
            employeescholarship.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult TeachingExperience()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TeachingExperience([Bind(Include = "te_id,employee_id,date_created,created_by,designation,institution_location,employment_date,appointment_status,working_status")] EmployeeTeachingExperience employeeteachingexperience, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeTeachingExperience new_employeeteachingexperience = new EmployeeTeachingExperience();

                new_employeeteachingexperience.employee_id = id;
                new_employeeteachingexperience.date_created = DateTime.Now;
                new_employeeteachingexperience.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeeteachingexperience.designation = employeeteachingexperience.designation;
                new_employeeteachingexperience.institution_location = employeeteachingexperience.institution_location;
                new_employeeteachingexperience.employment_date = employeeteachingexperience.employment_date;
                new_employeeteachingexperience.appointment_status = employeeteachingexperience.appointment_status;
                new_employeeteachingexperience.working_status = employeeteachingexperience.working_status;

                db.EmployeeTeachingExperiences.Add(new_employeeteachingexperience);
                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditTeachingExperience(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeTeachingExperience employeeteachingexperience = await db.EmployeeTeachingExperiences.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeteachingexperience == null || employee == null || employeeteachingexperience.deleted != false || employee.deleted != false || ((employeeteachingexperience.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeteachingexperience);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTeachingExperience([Bind(Include = "te_id,updated_on,updated_by,designation,institution_location,employment_date,appointment_status,working_status")] EmployeeTeachingExperience employeeteachingexperience, int back)
        {
            var currentEmployeeTeachingExperience = db.EmployeeTeachingExperiences.FirstOrDefault(a => a.te_id == employeeteachingexperience.te_id);

            if (currentEmployeeTeachingExperience == null)
            {
                return HttpNotFound();
            }

            currentEmployeeTeachingExperience.updated_on = DateTime.Now;
            currentEmployeeTeachingExperience.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeTeachingExperience.designation = employeeteachingexperience.designation;
            currentEmployeeTeachingExperience.institution_location = employeeteachingexperience.institution_location;
            currentEmployeeTeachingExperience.employment_date = employeeteachingexperience.employment_date;
            currentEmployeeTeachingExperience.appointment_status = employeeteachingexperience.appointment_status;
            currentEmployeeTeachingExperience.working_status = employeeteachingexperience.working_status;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteTeachingExperience(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeTeachingExperience employeeteachingexperience = await db.EmployeeTeachingExperiences.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeteachingexperience == null || employee == null || employeeteachingexperience.deleted != false || employee.deleted != false || ((employeeteachingexperience.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeteachingexperience);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteTeachingExperience(int id, int back)
        {
            EmployeeTeachingExperience employeeteachingexperience = await db.EmployeeTeachingExperiences.FindAsync(id);

            employeeteachingexperience.deleted = true;
            employeeteachingexperience.updated_on = DateTime.Now;
            employeeteachingexperience.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult Innovation()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Innovation([Bind(Include = "i_id,employee_id,date_created,created_by,innovation_name,patent_no,year_patented")] EmployeeInnovation employeeinnovation, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeInnovation new_employeeinnovation = new EmployeeInnovation();

                new_employeeinnovation.employee_id = id;
                new_employeeinnovation.date_created = DateTime.Now;
                new_employeeinnovation.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeeinnovation.innovation_name = employeeinnovation.innovation_name;
                new_employeeinnovation.patent_no = employeeinnovation.patent_no;
                new_employeeinnovation.year_patented = employeeinnovation.year_patented;
                
                db.EmployeeInnovations.Add(new_employeeinnovation);
                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditInnovation(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeInnovation employeeinnovation = await db.EmployeeInnovations.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeinnovation == null || employee == null || employeeinnovation.deleted != false || employee.deleted != false || ((employeeinnovation.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeinnovation);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditInnovation([Bind(Include = "i_id,updated_on,updated_by,innovation_name,patent_no,year_patented")] EmployeeInnovation employeeinnovation, int back)
        {
            var currentEmployeeInnovation = db.EmployeeInnovations.FirstOrDefault(a => a.i_id == employeeinnovation.i_id);

            if (currentEmployeeInnovation == null)
            {
                return HttpNotFound();
            }

            currentEmployeeInnovation.updated_on = DateTime.Now;
            currentEmployeeInnovation.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeInnovation.innovation_name = employeeinnovation.innovation_name;
            currentEmployeeInnovation.patent_no = employeeinnovation.patent_no;
            currentEmployeeInnovation.year_patented = employeeinnovation.year_patented;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteInnovation(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeInnovation employeeinnovation = await db.EmployeeInnovations.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeinnovation == null || employee == null || employeeinnovation.deleted != false || employee.deleted != false || ((employeeinnovation.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeinnovation);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteInnovation(int id, int back)
        {
            EmployeeInnovation employeeinnovation = await db.EmployeeInnovations.FindAsync(id);

            employeeinnovation.deleted = true;
            employeeinnovation.updated_on = DateTime.Now;
            employeeinnovation.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult AdministrativeExperience()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AdministrativeExperience([Bind(Include = "ae_id,employee_id,date_created,created_by,position,institution_location,employment_date,appointment_status,working_status")] EmployeeAdministrativeExperience employeeadministrativeexperience, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeAdministrativeExperience new_employeeadministrativeexperience = new EmployeeAdministrativeExperience();

                new_employeeadministrativeexperience.employee_id = id;
                new_employeeadministrativeexperience.date_created = DateTime.Now;
                new_employeeadministrativeexperience.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeeadministrativeexperience.position = employeeadministrativeexperience.position;
                new_employeeadministrativeexperience.institution_location = employeeadministrativeexperience.institution_location;
                new_employeeadministrativeexperience.employment_date = employeeadministrativeexperience.employment_date;
                new_employeeadministrativeexperience.appointment_status = employeeadministrativeexperience.appointment_status;
                new_employeeadministrativeexperience.working_status = employeeadministrativeexperience.working_status;

                db.EmployeeAdministrativeExperiences.Add(new_employeeadministrativeexperience);
                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditAdministrativeExperience(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeAdministrativeExperience employeeadministrativeexperience = await db.EmployeeAdministrativeExperiences.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeadministrativeexperience == null || employee == null || employeeadministrativeexperience.deleted != false || employee.deleted != false || ((employeeadministrativeexperience.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeadministrativeexperience);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAdministrativeExperience([Bind(Include = "ae_id,updated_on,updated_by,position,institution_location,employment_date,appointment_status,working_status")] EmployeeAdministrativeExperience employeeadministrativeexperience, int back)
        {
            var currentEmployeeAdministrativeExperience = db.EmployeeAdministrativeExperiences.FirstOrDefault(a => a.ae_id == employeeadministrativeexperience.ae_id);

            if (currentEmployeeAdministrativeExperience == null)
            {
                return HttpNotFound();
            }

            currentEmployeeAdministrativeExperience.updated_on = DateTime.Now;
            currentEmployeeAdministrativeExperience.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeAdministrativeExperience.position = employeeadministrativeexperience.position;
            currentEmployeeAdministrativeExperience.institution_location = employeeadministrativeexperience.institution_location;
            currentEmployeeAdministrativeExperience.employment_date = employeeadministrativeexperience.employment_date;
            currentEmployeeAdministrativeExperience.appointment_status = employeeadministrativeexperience.appointment_status;
            currentEmployeeAdministrativeExperience.working_status = employeeadministrativeexperience.working_status;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteAdministrativeExperience(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeAdministrativeExperience employeeadministrativeexperience = await db.EmployeeAdministrativeExperiences.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeadministrativeexperience == null || employee == null || employeeadministrativeexperience.deleted != false || employee.deleted != false || ((employeeadministrativeexperience.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeadministrativeexperience);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAdministrativeExperience(int id, int back)
        {
            EmployeeAdministrativeExperience employeeadministrativeexperience = await db.EmployeeAdministrativeExperiences.FindAsync(id);

            employeeadministrativeexperience.deleted = true;
            employeeadministrativeexperience.updated_on = DateTime.Now;
            employeeadministrativeexperience.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult ServiceCoach()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ServiceCoach([Bind(Include = "sc_id,employee_id,date_created,created_by,nature_activity,nature_service_rendered,level_participation_competition,inclusive_date")] EmployeeServiceCoach employeeservicecoach, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeServiceCoach new_employeeservicecoach = new EmployeeServiceCoach();

                new_employeeservicecoach.employee_id = id;
                new_employeeservicecoach.date_created = DateTime.Now;
                new_employeeservicecoach.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeeservicecoach.nature_activity = employeeservicecoach.nature_activity;
                new_employeeservicecoach.nature_service_rendered = employeeservicecoach.nature_service_rendered;
                new_employeeservicecoach.level_participation_competition = employeeservicecoach.level_participation_competition;
                new_employeeservicecoach.inclusive_date = employeeservicecoach.inclusive_date;

                db.EmployeeServiceCoaches.Add(new_employeeservicecoach);
                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditServiceCoach(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeServiceCoach employeeservicecoach = await db.EmployeeServiceCoaches.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeservicecoach == null || employee == null || employeeservicecoach.deleted != false || employee.deleted != false || ((employeeservicecoach.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeservicecoach);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditServiceCoach([Bind(Include = "sc_id,updated_on,updated_by,nature_activity,nature_service_rendered,level_participation_competition,inclusive_date")] EmployeeServiceCoach employeeservicecoach, int back)
        {
            var currentEmployeeServiceCoach = db.EmployeeServiceCoaches.FirstOrDefault(a => a.sc_id == employeeservicecoach.sc_id);

            if (currentEmployeeServiceCoach == null)
            {
                return HttpNotFound();
            }

            currentEmployeeServiceCoach.updated_on = DateTime.Now;
            currentEmployeeServiceCoach.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeServiceCoach.nature_activity = employeeservicecoach.nature_activity;
            currentEmployeeServiceCoach.nature_service_rendered = employeeservicecoach.nature_service_rendered;
            currentEmployeeServiceCoach.level_participation_competition = employeeservicecoach.level_participation_competition;
            currentEmployeeServiceCoach.inclusive_date = employeeservicecoach.inclusive_date;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteServiceCoach(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeServiceCoach employeeservicecoach = await db.EmployeeServiceCoaches.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeservicecoach == null || employee == null || employeeservicecoach.deleted != false || employee.deleted != false || ((employeeservicecoach.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeservicecoach);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteServiceCoach(int id, int back)
        {
            EmployeeServiceCoach employeeservicecoach = await db.EmployeeServiceCoaches.FindAsync(id);

            employeeservicecoach.deleted = true;
            employeeservicecoach.updated_on = DateTime.Now;
            employeeservicecoach.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult ServiceAward()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ServiceAward([Bind(Include = "sa_id,employee_id,date_created,created_by,title,field,organization,year_obtained")] EmployeeServiceAward employeeserviceaward, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeServiceAward new_employeeserviceaward = new EmployeeServiceAward();

                new_employeeserviceaward.employee_id = id;
                new_employeeserviceaward.date_created = DateTime.Now;
                new_employeeserviceaward.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeeserviceaward.title = employeeserviceaward.title;
                new_employeeserviceaward.field = employeeserviceaward.field;
                new_employeeserviceaward.organization = employeeserviceaward.organization;
                new_employeeserviceaward.year_obtained = employeeserviceaward.year_obtained;

                db.EmployeeServiceAwards.Add(new_employeeserviceaward);
                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditServiceAward(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeServiceAward employeeserviceaward = await db.EmployeeServiceAwards.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeserviceaward == null || employee == null || employeeserviceaward.deleted != false || employee.deleted != false || ((employeeserviceaward.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeserviceaward);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditServiceAward([Bind(Include = "sa_id,updated_on,updated_by,title,field,organization,year_obtained")] EmployeeServiceAward employeeserviceaward, int back)
        {
            var currentEmployeeServiceAward = db.EmployeeServiceAwards.FirstOrDefault(a => a.sa_id == employeeserviceaward.sa_id);

            if (currentEmployeeServiceAward == null)
            {
                return HttpNotFound();
            }

            currentEmployeeServiceAward.updated_on = DateTime.Now;
            currentEmployeeServiceAward.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeServiceAward.title = employeeserviceaward.title;
            currentEmployeeServiceAward.field = employeeserviceaward.field;
            currentEmployeeServiceAward.organization = employeeserviceaward.organization;
            currentEmployeeServiceAward.year_obtained = employeeserviceaward.year_obtained;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteServiceAward(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeServiceAward employeeserviceaward = await db.EmployeeServiceAwards.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeserviceaward == null || employee == null || employeeserviceaward.deleted != false || employee.deleted != false || ((employeeserviceaward.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeserviceaward);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteServiceAward(int id, int back)
        {
            EmployeeServiceAward employeeserviceaward = await db.EmployeeServiceAwards.FindAsync(id);

            employeeserviceaward.deleted = true;
            employeeserviceaward.updated_on = DateTime.Now;
            employeeserviceaward.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult AcademicHonor()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AcademicHonor([Bind(Include = "ah_id,employee_id,date_created,created_by,honors,institution_location,degree,year_obtained")] EmployeeAcademicHonor employeeacademichonor, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeAcademicHonor new_employeeacademichonor = new EmployeeAcademicHonor();

                new_employeeacademichonor.employee_id = id;
                new_employeeacademichonor.date_created = DateTime.Now;
                new_employeeacademichonor.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeeacademichonor.honors = employeeacademichonor.honors;
                new_employeeacademichonor.institution_location = employeeacademichonor.institution_location;
                new_employeeacademichonor.degree = employeeacademichonor.degree;
                new_employeeacademichonor.year_obtained = employeeacademichonor.year_obtained;

                db.EmployeeAcademicHonors.Add(new_employeeacademichonor);

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditAcademicHonor(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeAcademicHonor employeeacademichonor = await db.EmployeeAcademicHonors.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeacademichonor == null || employee == null || employeeacademichonor.deleted != false || employee.deleted != false || ((employeeacademichonor.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeacademichonor);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAcademicHonor([Bind(Include = "ah_id,updated_on,updated_by,honors,institution_location,degree,year_obtained")] EmployeeAcademicHonor employeeacademichonor, int back)
        {
            var currentEmployeeAcademicHonor = db.EmployeeAcademicHonors.FirstOrDefault(a => a.ah_id == employeeacademichonor.ah_id);

            if (currentEmployeeAcademicHonor == null)
            {
                return HttpNotFound();
            }

            currentEmployeeAcademicHonor.updated_on = DateTime.Now;
            currentEmployeeAcademicHonor.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeAcademicHonor.honors = employeeacademichonor.honors;
            currentEmployeeAcademicHonor.institution_location = employeeacademichonor.institution_location;
            currentEmployeeAcademicHonor.degree = employeeacademichonor.degree;
            currentEmployeeAcademicHonor.year_obtained = employeeacademichonor.year_obtained;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteAcademicHonor(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeAcademicHonor employeeacademichonor = await db.EmployeeAcademicHonors.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeacademichonor == null || employee == null || employeeacademichonor.deleted != false || employee.deleted != false || ((employeeacademichonor.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeacademichonor);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAcademicHonor(int id, int back)
        {
            EmployeeAcademicHonor employeeacademichonor = await db.EmployeeAcademicHonors.FindAsync(id);

            employeeacademichonor.deleted = true;
            employeeacademichonor.updated_on = DateTime.Now;
            employeeacademichonor.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult PublishedResearchBook()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PublishedResearchBook([Bind(Include = "pbr_id,employee_id,date_created,created_by,title,nature,role,pbr_level,publisher,date_publication")] EmployeePublishedResearchBook employeepublishedresearchbook, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeePublishedResearchBook new_employeepublishedresearchbook = new EmployeePublishedResearchBook();

                new_employeepublishedresearchbook.employee_id = id;
                new_employeepublishedresearchbook.date_created = DateTime.Now;
                new_employeepublishedresearchbook.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeepublishedresearchbook.title = employeepublishedresearchbook.title;
                new_employeepublishedresearchbook.nature = employeepublishedresearchbook.nature;
                new_employeepublishedresearchbook.role = employeepublishedresearchbook.role;
                new_employeepublishedresearchbook.pbr_level = employeepublishedresearchbook.pbr_level;
                new_employeepublishedresearchbook.publisher = employeepublishedresearchbook.publisher;
                new_employeepublishedresearchbook.date_publication = employeepublishedresearchbook.date_publication;

                db.EmployeePublishedResearchBooks.Add(new_employeepublishedresearchbook);

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditPublishedResearchBook(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeePublishedResearchBook employeepublishedresearchbook = await db.EmployeePublishedResearchBooks.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeepublishedresearchbook == null || employee == null || employeepublishedresearchbook.deleted != false || employee.deleted != false || ((employeepublishedresearchbook.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeepublishedresearchbook);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPublishedResearchBook([Bind(Include = "pbr_id,updated_on,updated_by,title,nature,role,pbr_level,publisher,date_publication")] EmployeePublishedResearchBook employeepublishedresearchbook, int back)
        {
            var currentEmployeePublishedResearchBook = db.EmployeePublishedResearchBooks.FirstOrDefault(a => a.pbr_id == employeepublishedresearchbook.pbr_id);

            if (currentEmployeePublishedResearchBook == null)
            {
                return HttpNotFound();
            }

            currentEmployeePublishedResearchBook.updated_on = DateTime.Now;
            currentEmployeePublishedResearchBook.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeePublishedResearchBook.title = employeepublishedresearchbook.title;
            currentEmployeePublishedResearchBook.nature = employeepublishedresearchbook.nature;
            currentEmployeePublishedResearchBook.role = employeepublishedresearchbook.role;
            currentEmployeePublishedResearchBook.pbr_level = employeepublishedresearchbook.pbr_level;
            currentEmployeePublishedResearchBook.publisher = employeepublishedresearchbook.publisher;
            currentEmployeePublishedResearchBook.date_publication = employeepublishedresearchbook.date_publication;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeletePublishedResearchBook(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeePublishedResearchBook employeepublishedresearchbook = await db.EmployeePublishedResearchBooks.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeepublishedresearchbook == null || employee == null || employeepublishedresearchbook.deleted != false || employee.deleted != false || ((employeepublishedresearchbook.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeepublishedresearchbook);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePublishedResearchBook(int id, int back)
        {
            EmployeePublishedResearchBook employeepublishedresearchbook = await db.EmployeePublishedResearchBooks.FindAsync(id);

            employeepublishedresearchbook.deleted = true;
            employeepublishedresearchbook.updated_on = DateTime.Now;
            employeepublishedresearchbook.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult MembershipProfessionalOrganization()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MembershipProfessionalOrganization([Bind(Include = "mpo_id,employee_id,date_created,created_by,name_organization,nature_category,date_of_membership")] EmployeeMembershipProfessionalOrganization employeempo, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeMembershipProfessionalOrganization new_employeempo = new EmployeeMembershipProfessionalOrganization();

                new_employeempo.employee_id = id;
                new_employeempo.date_created = DateTime.Now;
                new_employeempo.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeempo.name_organization = employeempo.name_organization;
                new_employeempo.nature_category = employeempo.nature_category;
                new_employeempo.date_of_membership = employeempo.date_of_membership;

                db.EmployeeMembershipProfessionalOrganizations.Add(new_employeempo);

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditMembershipProfessionalOrganization(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeMembershipProfessionalOrganization employeemembershipprofessionalorganization = await db.EmployeeMembershipProfessionalOrganizations.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeemembershipprofessionalorganization == null || employee == null || employeemembershipprofessionalorganization.deleted != false || employee.deleted != false || ((employeemembershipprofessionalorganization.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeemembershipprofessionalorganization);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditMembershipProfessionalOrganization([Bind(Include = "mpo_id,updated_on,updated_by,name_organization,nature_category,date_of_membership")] EmployeeMembershipProfessionalOrganization employeempo, int back)
        {
            var currentEmployeeMembershipProfessionalOrganization = db.EmployeeMembershipProfessionalOrganizations.FirstOrDefault(a => a.mpo_id == employeempo.mpo_id);

            if (currentEmployeeMembershipProfessionalOrganization == null)
            {
                return HttpNotFound();
            }

            currentEmployeeMembershipProfessionalOrganization.updated_on = DateTime.Now;
            currentEmployeeMembershipProfessionalOrganization.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeMembershipProfessionalOrganization.name_organization = employeempo.name_organization;
            currentEmployeeMembershipProfessionalOrganization.nature_category = employeempo.nature_category;
            currentEmployeeMembershipProfessionalOrganization.date_of_membership = employeempo.date_of_membership;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteMembershipProfessionalOrganization(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeMembershipProfessionalOrganization employeemembershipprofessionalorganization = await db.EmployeeMembershipProfessionalOrganizations.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeemembershipprofessionalorganization == null || employee == null || employeemembershipprofessionalorganization.deleted != false || employee.deleted != false || ((employeemembershipprofessionalorganization.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeemembershipprofessionalorganization);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteMembershipProfessionalOrganization(int id, int back)
        {
            EmployeeMembershipProfessionalOrganization employeemembershipprofessionalorganization = await db.EmployeeMembershipProfessionalOrganizations.FindAsync(id);

            employeemembershipprofessionalorganization.deleted = true;
            employeemembershipprofessionalorganization.updated_on = DateTime.Now;
            employeemembershipprofessionalorganization.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult ServiceAccreditation()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ServiceAccreditation([Bind(Include = "saccr_id,employee_id,date_created,created_by,accrediting_group,nature_participation,inclusive_date")] EmployeeServiceAccreditation employeeserviceaccreditation, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeServiceAccreditation new_employeeserviceaccreditation = new EmployeeServiceAccreditation();

                new_employeeserviceaccreditation.employee_id = id;
                new_employeeserviceaccreditation.date_created = DateTime.Now;
                new_employeeserviceaccreditation.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeeserviceaccreditation.accrediting_group = employeeserviceaccreditation.accrediting_group;
                new_employeeserviceaccreditation.nature_participation = employeeserviceaccreditation.nature_participation;
                new_employeeserviceaccreditation.inclusive_date = employeeserviceaccreditation.inclusive_date;

                db.EmployeeServiceAccreditations.Add(new_employeeserviceaccreditation);

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditServiceAccreditation(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeServiceAccreditation employeeserviceaccreditation = await db.EmployeeServiceAccreditations.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeserviceaccreditation == null || employee == null || employeeserviceaccreditation.deleted != false || employee.deleted != false || ((employeeserviceaccreditation.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeserviceaccreditation);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditServiceAccreditation([Bind(Include = "saccr_id,updated_on,updated_by,accrediting_group,nature_participation,inclusive_date")] EmployeeServiceAccreditation employeeserviceaccreditation, int back)
        {
            var currentEmployeeServiceAccreditation = db.EmployeeServiceAccreditations.FirstOrDefault(a => a.saccr_id == employeeserviceaccreditation.saccr_id);

            if (currentEmployeeServiceAccreditation == null)
            {
                return HttpNotFound();
            }

            currentEmployeeServiceAccreditation.updated_on = DateTime.Now;
            currentEmployeeServiceAccreditation.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeServiceAccreditation.accrediting_group = employeeserviceaccreditation.accrediting_group;
            currentEmployeeServiceAccreditation.nature_participation = employeeserviceaccreditation.nature_participation;
            currentEmployeeServiceAccreditation.inclusive_date = employeeserviceaccreditation.inclusive_date;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteServiceAccreditation(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeServiceAccreditation employeeserviceaccreditation = await db.EmployeeServiceAccreditations.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeserviceaccreditation == null || employee == null || employeeserviceaccreditation.deleted != false || employee.deleted != false || ((employeeserviceaccreditation.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeserviceaccreditation);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteServiceAccreditation(int id, int back)
        {
            EmployeeServiceAccreditation employeeserviceaccreditation = await db.EmployeeServiceAccreditations.FindAsync(id);

            employeeserviceaccreditation.deleted = true;
            employeeserviceaccreditation.updated_on = DateTime.Now;
            employeeserviceaccreditation.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult ContinuingProfessionalEducation()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ContinuingProfessionalEducation([Bind(Include = "cpe_id,employee_id,date_created,created_by,area_topic,venue,inclusive_date,number_of_hours")] EmployeeContinuingProfessionalEducation employeecontinuingprofessionaleducation, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeContinuingProfessionalEducation new_employeecontinuingprofessionaleducation = new EmployeeContinuingProfessionalEducation();

                new_employeecontinuingprofessionaleducation.employee_id = id;
                new_employeecontinuingprofessionaleducation.date_created = DateTime.Now;
                new_employeecontinuingprofessionaleducation.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeecontinuingprofessionaleducation.area_topic = employeecontinuingprofessionaleducation.area_topic;
                new_employeecontinuingprofessionaleducation.venue = employeecontinuingprofessionaleducation.venue;
                new_employeecontinuingprofessionaleducation.inclusive_date = employeecontinuingprofessionaleducation.inclusive_date;
                new_employeecontinuingprofessionaleducation.number_of_hours = employeecontinuingprofessionaleducation.number_of_hours;

                db.EmployeeContinuingProfessionalEducations.Add(new_employeecontinuingprofessionaleducation);

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditContinuingProfessionalEducation(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeContinuingProfessionalEducation employeecontinuingprofessionaleducation = await db.EmployeeContinuingProfessionalEducations.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeecontinuingprofessionaleducation == null || employee == null || employeecontinuingprofessionaleducation.deleted != false || employee.deleted != false || ((employeecontinuingprofessionaleducation.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeecontinuingprofessionaleducation);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditContinuingProfessionalEducation([Bind(Include = "cpe_id,updated_on,updated_by,area_topic,venue,inclusive_date,number_of_hours")] EmployeeContinuingProfessionalEducation employeecontinuingprofessionaleducation, int back)
        {
            var currentEmployeeContinuingProfessionalEducation = db.EmployeeContinuingProfessionalEducations.FirstOrDefault(a => a.cpe_id == employeecontinuingprofessionaleducation.cpe_id);

            if (currentEmployeeContinuingProfessionalEducation == null)
            {
                return HttpNotFound();
            }

            currentEmployeeContinuingProfessionalEducation.updated_on = DateTime.Now;
            currentEmployeeContinuingProfessionalEducation.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeContinuingProfessionalEducation.area_topic = employeecontinuingprofessionaleducation.area_topic;
            currentEmployeeContinuingProfessionalEducation.venue = employeecontinuingprofessionaleducation.venue;
            currentEmployeeContinuingProfessionalEducation.inclusive_date = employeecontinuingprofessionaleducation.inclusive_date;
            currentEmployeeContinuingProfessionalEducation.number_of_hours = employeecontinuingprofessionaleducation.number_of_hours;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteContinuingProfessionalEducation(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeContinuingProfessionalEducation employeecontinuingprofessionaleducation = await db.EmployeeContinuingProfessionalEducations.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeecontinuingprofessionaleducation == null || employee == null || employeecontinuingprofessionaleducation.deleted != false || employee.deleted != false || ((employeecontinuingprofessionaleducation.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeecontinuingprofessionaleducation);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteContinuingProfessionalEducation(int id, int back)
        {
            EmployeeContinuingProfessionalEducation employeecontinuingprofessionaleducation = await db.EmployeeContinuingProfessionalEducations.FindAsync(id);

            employeecontinuingprofessionaleducation.deleted = true;
            employeecontinuingprofessionaleducation.updated_on = DateTime.Now;
            employeecontinuingprofessionaleducation.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult Children()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Children([Bind(Include = "c_id,employee_id,date_created,created_by,firstname,middlename,lastname,birth_date")] EmployeeChildren employeechildren, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeChildren new_employeechildren = new EmployeeChildren();

                new_employeechildren.employee_id = id;
                new_employeechildren.date_created = DateTime.Now;
                new_employeechildren.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeechildren.firstname = employeechildren.firstname;
                new_employeechildren.middlename = employeechildren.middlename;
                new_employeechildren.lastname = employeechildren.lastname;
                new_employeechildren.birth_date = employeechildren.birth_date;
            
                db.EmployeeChildrens.Add(new_employeechildren);

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditChildren(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeChildren employeechildren = await db.EmployeeChildrens.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeechildren == null || employee == null || employeechildren.deleted != false || employee.deleted != false || ((employeechildren.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeechildren);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditChildren([Bind(Include = "c_id,updated_on,updated_by,firstname,middlename,lastname,birth_date")] EmployeeChildren employeechildren, int back)
        {
            var currentEmployeeChildren = db.EmployeeChildrens.FirstOrDefault(a => a.c_id == employeechildren.c_id);

            if (currentEmployeeChildren == null)
            {
                return HttpNotFound();
            }

            currentEmployeeChildren.updated_on = DateTime.Now;
            currentEmployeeChildren.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeChildren.firstname = employeechildren.firstname;
            currentEmployeeChildren.middlename = employeechildren.middlename;
            currentEmployeeChildren.lastname = employeechildren.lastname;
            currentEmployeeChildren.birth_date = employeechildren.birth_date;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteChildren(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeChildren employeechildren = await db.EmployeeChildrens.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeechildren == null || employee == null || employeechildren.deleted != false || employee.deleted != false || ((employeechildren.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeechildren);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteChildren(int id, int back)
        {
            EmployeeChildren employeechildren = await db.EmployeeChildrens.FindAsync(id);

            employeechildren.deleted = true;
            employeechildren.updated_on = DateTime.Now;
            employeechildren.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult ServicePRCExaminer()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ServicePRCExaminer([Bind(Include = "prc_id,employee_id,date_created,created_by,name_examination,venue,inclusive_date")] EmployeeServicePRCExaminer employeeprc, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeServicePRCExaminer new_employeeprc = new EmployeeServicePRCExaminer();

                new_employeeprc.employee_id = id;
                new_employeeprc.date_created = DateTime.Now;
                new_employeeprc.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeeprc.name_examination = employeeprc.name_examination;
                new_employeeprc.venue = employeeprc.venue;
                new_employeeprc.inclusive_date = employeeprc.inclusive_date;
           
                db.EmployeeServicePRCExaminers.Add(new_employeeprc);

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditServicePRCExaminer(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeServicePRCExaminer employeeserviceprcexaminer = await db.EmployeeServicePRCExaminers.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeserviceprcexaminer == null || employee == null || employeeserviceprcexaminer.deleted != false || employee.deleted != false || ((employeeserviceprcexaminer.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeserviceprcexaminer);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditServicePRCExaminer([Bind(Include = "prc_id,updated_on,updated_by,name_examination,venue,inclusive_date")] EmployeeServicePRCExaminer employeeserviceprcexaminer, int back)
        {
            var currentEmployeeServicePRCExaminer = db.EmployeeServicePRCExaminers.FirstOrDefault(a => a.prc_id == employeeserviceprcexaminer.prc_id);

            if (currentEmployeeServicePRCExaminer == null)
            {
                return HttpNotFound();
            }

            currentEmployeeServicePRCExaminer.updated_on = DateTime.Now;
            currentEmployeeServicePRCExaminer.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeServicePRCExaminer.name_examination = employeeserviceprcexaminer.name_examination;
            currentEmployeeServicePRCExaminer.venue = employeeserviceprcexaminer.venue;
            currentEmployeeServicePRCExaminer.inclusive_date = employeeserviceprcexaminer.inclusive_date;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteServicePRCExaminer(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeServicePRCExaminer employeeserviceprcexaminer = await db.EmployeeServicePRCExaminers.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeserviceprcexaminer == null || employee == null || employeeserviceprcexaminer.deleted != false || employee.deleted != false || ((employeeserviceprcexaminer.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeserviceprcexaminer);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteServicePRCExaminer(int id, int back)
        {
            EmployeeServicePRCExaminer employeeserviceprcexaminer = await db.EmployeeServicePRCExaminers.FindAsync(id);

            employeeserviceprcexaminer.deleted = true;
            employeeserviceprcexaminer.updated_on = DateTime.Now;
            employeeserviceprcexaminer.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult LicensureExamination()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LicensureExamination([Bind(Include = "le_id,employee_id,date_created,created_by,examination,rating,year")] EmployeeLicensureExamination employeelicensureexam, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeLicensureExamination new_employeelicensureexam = new EmployeeLicensureExamination();

                new_employeelicensureexam.employee_id = id;
                new_employeelicensureexam.date_created = DateTime.Now;
                new_employeelicensureexam.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeelicensureexam.examination = employeelicensureexam.examination;
                new_employeelicensureexam.rating = employeelicensureexam.rating;
                new_employeelicensureexam.year = employeelicensureexam.year;

                db.EmployeeLicensureExaminations.Add(new_employeelicensureexam);

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditLicensureExamination(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeLicensureExamination employeelicensureexamination = await db.EmployeeLicensureExaminations.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeelicensureexamination == null || employee == null || employeelicensureexamination.deleted != false || employee.deleted != false || ((employeelicensureexamination.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeelicensureexamination);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditLicensureExamination([Bind(Include = "le_id,updated_on,updated_by,examination,rating,year")] EmployeeLicensureExamination employeelicensureexamination, int back)
        {
            var currentEmployeeLicensureExamination = db.EmployeeLicensureExaminations.FirstOrDefault(a => a.le_id == employeelicensureexamination.le_id);

            if (currentEmployeeLicensureExamination == null)
            {
                return HttpNotFound();
            }

            currentEmployeeLicensureExamination.updated_on = DateTime.Now;
            currentEmployeeLicensureExamination.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeLicensureExamination.examination = employeelicensureexamination.examination;
            currentEmployeeLicensureExamination.rating = employeelicensureexamination.rating;
            currentEmployeeLicensureExamination.year = employeelicensureexamination.year;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteLicensureExamination(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeLicensureExamination employeelicensureexamination = await db.EmployeeLicensureExaminations.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeelicensureexamination == null || employee == null || employeelicensureexamination.deleted != false || employee.deleted != false || ((employeelicensureexamination.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeelicensureexamination);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteLicensureExamination(int id, int back)
        {
            EmployeeLicensureExamination employeelicensureexamination = await db.EmployeeLicensureExaminations.FindAsync(id);

            employeelicensureexamination.deleted = true;
            employeelicensureexamination.updated_on = DateTime.Now;
            employeelicensureexamination.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult ServiceConsultant()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ServiceConsultant([Bind(Include = "sca_id,employee_id,date_created,created_by,nature,sponsor_location,sca_level,inclusive_date")] EmployeeServiceConsultant employeeserviceconsultant, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeServiceConsultant new_employeeserviceconsultant = new EmployeeServiceConsultant();

                new_employeeserviceconsultant.employee_id = id;
                new_employeeserviceconsultant.date_created = DateTime.Now;
                new_employeeserviceconsultant.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeeserviceconsultant.nature = employeeserviceconsultant.nature;
                new_employeeserviceconsultant.sponsor_location = employeeserviceconsultant.sponsor_location;
                new_employeeserviceconsultant.sca_level = employeeserviceconsultant.sca_level;
                new_employeeserviceconsultant.inclusive_date = employeeserviceconsultant.inclusive_date;


                db.EmployeeServiceConsultants.Add(new_employeeserviceconsultant);

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditServiceConsultant(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeServiceConsultant employeeserviceconsultant = await db.EmployeeServiceConsultants.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeserviceconsultant == null || employee == null || employeeserviceconsultant.deleted != false || employee.deleted != false || ((employeeserviceconsultant.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeserviceconsultant);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditServiceConsultant([Bind(Include = "sca_id,updated_on,updated_by,nature,sponsor_location,sca_level,inclusive_date")] EmployeeServiceConsultant employeeserviceconsultant, int back)
        {
            var currentEmployeeServiceConsultant = db.EmployeeServiceConsultants.FirstOrDefault(a => a.sca_id == employeeserviceconsultant.sca_id);

            if (currentEmployeeServiceConsultant == null)
            {
                return HttpNotFound();
            }

            currentEmployeeServiceConsultant.updated_on = DateTime.Now;
            currentEmployeeServiceConsultant.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeServiceConsultant.nature = employeeserviceconsultant.nature;
            currentEmployeeServiceConsultant.sponsor_location = employeeserviceconsultant.sponsor_location;
            currentEmployeeServiceConsultant.sca_level = employeeserviceconsultant.sca_level;
            currentEmployeeServiceConsultant.inclusive_date = employeeserviceconsultant.inclusive_date;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteServiceConsultant(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeServiceConsultant employeeserviceconsultant = await db.EmployeeServiceConsultants.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeserviceconsultant == null || employee == null || employeeserviceconsultant.deleted != false || employee.deleted != false || ((employeeserviceconsultant.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeserviceconsultant);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteServiceConsultant(int id, int back)
        {
            EmployeeServiceConsultant employeeserviceconsultant = await db.EmployeeServiceConsultants.FindAsync(id);

            employeeserviceconsultant.deleted = true;
            employeeserviceconsultant.updated_on = DateTime.Now;
            employeeserviceconsultant.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult ServiceAdviser()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ServiceAdviser([Bind(Include = "sadvi_id,employee_id,date_created,created_by,title,nature,name_student,category,institution,inclusive_date")] EmployeeServiceAdviser employeeserviceadviser, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeServiceAdviser new_employeeserviceadviser = new EmployeeServiceAdviser();

                new_employeeserviceadviser.employee_id = id;
                new_employeeserviceadviser.date_created = DateTime.Now;
                new_employeeserviceadviser.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeeserviceadviser.title = employeeserviceadviser.title;
                new_employeeserviceadviser.nature = employeeserviceadviser.nature;
                new_employeeserviceadviser.name_student = employeeserviceadviser.name_student;
                new_employeeserviceadviser.category = employeeserviceadviser.category;
                new_employeeserviceadviser.institution = employeeserviceadviser.institution;
                new_employeeserviceadviser.inclusive_date = employeeserviceadviser.inclusive_date;

                db.EmployeeServiceAdvisers.Add(new_employeeserviceadviser);

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditServiceAdviser(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeServiceAdviser employeeserviceadviser = await db.EmployeeServiceAdvisers.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeserviceadviser == null || employee == null || employeeserviceadviser.deleted != false || employee.deleted != false || ((employeeserviceadviser.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeserviceadviser);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditServiceAdviser([Bind(Include = "sadvi_id,updated_on,updated_by,title,nature,name_student,category,institution,inclusive_date")] EmployeeServiceAdviser employeeserviceadviser, int back)
        {
            var currentEmployeeServiceAdviser = db.EmployeeServiceAdvisers.FirstOrDefault(a => a.sadvi_id == employeeserviceadviser.sadvi_id);

            if (currentEmployeeServiceAdviser == null)
            {
                return HttpNotFound();
            }

            currentEmployeeServiceAdviser.updated_on = DateTime.Now;
            currentEmployeeServiceAdviser.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeServiceAdviser.title = employeeserviceadviser.title;
            currentEmployeeServiceAdviser.nature = employeeserviceadviser.nature;
            currentEmployeeServiceAdviser.name_student = employeeserviceadviser.name_student;
            currentEmployeeServiceAdviser.category = employeeserviceadviser.category;
            currentEmployeeServiceAdviser.institution = employeeserviceadviser.institution;
            currentEmployeeServiceAdviser.inclusive_date = employeeserviceadviser.inclusive_date;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteServiceAdviser(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeServiceAdviser employeeserviceadviser = await db.EmployeeServiceAdvisers.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeserviceadviser == null || employee == null || employeeserviceadviser.deleted != false || employee.deleted != false || ((employeeserviceadviser.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeserviceadviser);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteServiceAdviser(int id, int back)
        {
            EmployeeServiceAdviser employeeserviceadviser = await db.EmployeeServiceAdvisers.FindAsync(id);

            employeeserviceadviser.deleted = true;
            employeeserviceadviser.updated_on = DateTime.Now;
            employeeserviceadviser.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult Beneficiaries()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Beneficiaries([Bind(Include = "r_id,employee_id,date_created,created_by,firstname,middlename,lastname,birth_date")] EmployeeRecipient employeerecipient, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeRecipient new_employeerecipient = new EmployeeRecipient();

                new_employeerecipient.employee_id = id;
                new_employeerecipient.date_created = DateTime.Now;
                new_employeerecipient.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeerecipient.firstname = employeerecipient.firstname;
                new_employeerecipient.middlename = employeerecipient.middlename;
                new_employeerecipient.lastname = employeerecipient.lastname;
                new_employeerecipient.birth_date = employeerecipient.birth_date;

                db.EmployeeRecipients.Add(new_employeerecipient);

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditBeneficiaries(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeRecipient employeerecipient = await db.EmployeeRecipients.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeerecipient == null || employee == null || employeerecipient.deleted != false || employee.deleted != false || ((employeerecipient.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeerecipient);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditBeneficiaries([Bind(Include = "r_id,updated_on,updated_by,firstname,middlename,lastname,birth_date")] EmployeeRecipient employeerecipient, int back)
        {
            var currentEmployeeBeneficiaries = db.EmployeeRecipients.FirstOrDefault(a => a.r_id == employeerecipient.r_id);

            if (currentEmployeeBeneficiaries == null)
            {
                return HttpNotFound();
            }

            currentEmployeeBeneficiaries.updated_on = DateTime.Now;
            currentEmployeeBeneficiaries.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeBeneficiaries.firstname = employeerecipient.firstname;
            currentEmployeeBeneficiaries.middlename = employeerecipient.middlename;
            currentEmployeeBeneficiaries.lastname = employeerecipient.lastname;
            currentEmployeeBeneficiaries.birth_date = employeerecipient.birth_date;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteBeneficiaries(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeRecipient employeerecipient = await db.EmployeeRecipients.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeerecipient == null || employee == null || employeerecipient.deleted != false || employee.deleted != false || ((employeerecipient.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeerecipient);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteBeneficiaries(int id, int back)
        {
            EmployeeRecipient employeerecipient = await db.EmployeeRecipients.FindAsync(id);

            employeerecipient.deleted = true;
            employeerecipient.updated_on = DateTime.Now;
            employeerecipient.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

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

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Training([Bind(Include = "et_id,employee_id,date_created,created_by,training,title")] EmployeeTraining employeetraining, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeTraining new_employeetraining = new EmployeeTraining();

                new_employeetraining.employee_id = id;
                new_employeetraining.date_created = DateTime.Now;
                new_employeetraining.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeetraining.training = employeetraining.training;
                new_employeetraining.title = employeetraining.title;

                db.EmployeeTrainings.Add(new_employeetraining);

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
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

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeTraining employeetraining = await db.EmployeeTrainings.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeetraining == null || employee == null || employeetraining.deleted != false || employee.deleted != false || ((employeetraining.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeetraining);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTraining([Bind(Include = "et_id,updated_on,updated_by,training,title")] EmployeeTraining employeetraining, int back)
        {
            var currentEmployeeTraining = db.EmployeeTrainings.FirstOrDefault(a => a.et_id == employeetraining.et_id);

            if (currentEmployeeTraining == null)
            {
                return HttpNotFound();
            }

            currentEmployeeTraining.updated_on = DateTime.Now;
            currentEmployeeTraining.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeTraining.training = employeetraining.training;
            currentEmployeeTraining.title = employeetraining.title;

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

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeTraining employeetraining = await db.EmployeeTrainings.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeetraining == null || employee == null || employeetraining.deleted != false || employee.deleted != false || ((employeetraining.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeetraining);
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
            EmployeeTraining employeetraining = await db.EmployeeTrainings.FindAsync(id);

            employeetraining.deleted = true;
            employeetraining.updated_on = DateTime.Now;
            employeetraining.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult Performance()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                ViewBag.Semester3 = db.Semesters.Where(a => a.deleted == false).Select(p => new SelectListItem
                {
                    Text = p.school_year + " " + p.school_semester,
                    Value = p.school_year + " " + p.school_semester
                });

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Performance([Bind(Include = "p_id,employee_id,date_created,created_by,evaluation_date,evaluation_period,semester,evaluator,evaluation_score,rating")] EmployeePerformance employeeperformance, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeePerformance new_employeeperformance = new EmployeePerformance();

                new_employeeperformance.employee_id = id;
                new_employeeperformance.date_created = DateTime.Now;
                new_employeeperformance.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeeperformance.evaluation_date = employeeperformance.evaluation_date;
                new_employeeperformance.evaluation_period = employeeperformance.evaluation_period;
                new_employeeperformance.semester = employeeperformance.semester;
                new_employeeperformance.evaluator = employeeperformance.evaluator;
                new_employeeperformance.evaluation_score = employeeperformance.evaluation_score;
                new_employeeperformance.rating = employeeperformance.rating;

                db.EmployeePerformances.Add(new_employeeperformance);

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditPerformance(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                ViewBag.Semester4 = db.Semesters.Where(a => a.deleted == false).Select(p => new SelectListItem
                {
                    Text = p.school_year + " " + p.school_semester,
                    Value = p.school_year + " " + p.school_semester
                });

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeePerformance employeeperformance = await db.EmployeePerformances.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeperformance == null || employee == null || employeeperformance.deleted != false || employee.deleted != false || ((employeeperformance.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeperformance);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPerformance([Bind(Include = "p_id,updated_on,updated_by,evaluation_date,evaluation_period,semester,evaluator,evaluation_score,rating")] EmployeePerformance employeeperformance, int back)
        {
            var currentEmployeePerformance = db.EmployeePerformances.FirstOrDefault(a => a.p_id == employeeperformance.p_id);

            if (currentEmployeePerformance == null)
            {
                return HttpNotFound();
            }

            currentEmployeePerformance.updated_on = DateTime.Now;
            currentEmployeePerformance.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeePerformance.evaluation_date = employeeperformance.evaluation_date;
            currentEmployeePerformance.evaluation_period = employeeperformance.evaluation_period;
            currentEmployeePerformance.semester = employeeperformance.semester;
            currentEmployeePerformance.evaluator = employeeperformance.evaluator;
            currentEmployeePerformance.evaluation_score = employeeperformance.evaluation_score;
            currentEmployeePerformance.rating = employeeperformance.rating;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeletePerformance(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeePerformance employeeperformance = await db.EmployeePerformances.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeperformance == null || employee == null || employeeperformance.deleted != false || employee.deleted != false || ((employeeperformance.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeperformance);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePerformance(int id, int back)
        {
            EmployeePerformance employeeperformance = await db.EmployeePerformances.FindAsync(id);

            employeeperformance.deleted = true;
            employeeperformance.updated_on = DateTime.Now;
            employeeperformance.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult DateOrganization()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DateOrganization([Bind(Include = "do_id,employee_id,date_created,created_by,activity,number_of_days")] EmployeeDateOrganization employeedateorganization, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeDateOrganization new_employeedateorganization = new EmployeeDateOrganization();

                new_employeedateorganization.employee_id = id;
                new_employeedateorganization.date_created = DateTime.Now;
                new_employeedateorganization.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeedateorganization.activity = employeedateorganization.activity;
                new_employeedateorganization.number_of_days = employeedateorganization.number_of_days;

                db.EmployeeDateOrganizations.Add(new_employeedateorganization);

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditDateOrganization(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeDateOrganization employeedateorganization = await db.EmployeeDateOrganizations.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeedateorganization == null || employee == null || employeedateorganization.deleted != false || employee.deleted != false || ((employeedateorganization.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeedateorganization);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditDateOrganization([Bind(Include = "do_id,updated_on,updated_by,activity,number_of_days")] EmployeeDateOrganization employeedateorganization, int back)
        {
            var currentEmployeeDateOrganization = db.EmployeeDateOrganizations.FirstOrDefault(a => a.do_id == employeedateorganization.do_id);

            if (currentEmployeeDateOrganization == null)
            {
                return HttpNotFound();
            }

            currentEmployeeDateOrganization.updated_on = DateTime.Now;
            currentEmployeeDateOrganization.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeDateOrganization.activity = employeedateorganization.activity;
            currentEmployeeDateOrganization.number_of_days = employeedateorganization.number_of_days;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteDateOrganization(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeDateOrganization employeedateorganization = await db.EmployeeDateOrganizations.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeedateorganization == null || employee == null || employeedateorganization.deleted != false || employee.deleted != false || ((employeedateorganization.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeedateorganization);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteDateOrganization(int id, int back)
        {
            EmployeeDateOrganization employeedateorganization = await db.EmployeeDateOrganizations.FindAsync(id);

            employeedateorganization.deleted = true;
            employeedateorganization.updated_on = DateTime.Now;
            employeedateorganization.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult ServiceRecord()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ServiceRecord([Bind(Include = "sr_id,employee_id,date_created,created_by,years_in_organization,years_in_probationary,years_of_permanent")] EmployeeServiceRecord employeeservicerecord, int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeServiceRecord new_employeeservicerecord = new EmployeeServiceRecord();

                new_employeeservicerecord.employee_id = id;
                new_employeeservicerecord.date_created = DateTime.Now;
                new_employeeservicerecord.created_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
                new_employeeservicerecord.years_in_organization = employeeservicerecord.years_in_organization;
                new_employeeservicerecord.years_in_probationary = employeeservicerecord.years_in_probationary;
                new_employeeservicerecord.years_of_permanent = employeeservicerecord.years_of_permanent;

                db.EmployeeServiceRecords.Add(new_employeeservicerecord);

                await db.SaveChangesAsync();

            }
            TempData["t_Info"] = "added";
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<ActionResult> EditServiceRecord(int? id, int back)
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeServiceRecord employeeservicerecord = await db.EmployeeServiceRecords.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeservicerecord == null || employee == null || employeeservicerecord.deleted != false || employee.deleted != false || ((employeeservicerecord.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeservicerecord);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditServiceRecord([Bind(Include = "sr_id,updated_on,updated_by,years_in_organization,years_in_probationary,years_of_permanent")] EmployeeServiceRecord employeeservicerecord, int back)
        {
            var currentEmployeeServiceRecord = db.EmployeeServiceRecords.FirstOrDefault(a => a.sr_id == employeeservicerecord.sr_id);

            if (currentEmployeeServiceRecord == null)
            {
                return HttpNotFound();
            }

            currentEmployeeServiceRecord.updated_on = DateTime.Now;
            currentEmployeeServiceRecord.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();
            currentEmployeeServiceRecord.years_in_organization = employeeservicerecord.years_in_organization;
            currentEmployeeServiceRecord.years_in_probationary = employeeservicerecord.years_in_probationary;
            currentEmployeeServiceRecord.years_of_permanent = employeeservicerecord.years_of_permanent;

            await db.SaveChangesAsync();
            TempData["t_Info"] = "updated";
            return RedirectToAction("Details", new { id = back });

        }

        public async Task<ActionResult> DeleteServiceRecord(int? id, int back)
        {

            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ViewBag.ActiveEmployeeListEmployee = "class = active";
                ViewBag.ActiveTreeEmployee = "active";

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeServiceRecord employeeservicerecord = await db.EmployeeServiceRecords.FindAsync(id);
                Employee employee = await db.Employees.FindAsync(back);

                if (employeeservicerecord == null || employee == null || employeeservicerecord.deleted != false || employee.deleted != false || ((employeeservicerecord.employee_id == employee.employee_id) == (employee.deleted == true)))
                {
                    return HttpNotFound();
                }

                return View(employeeservicerecord);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteServiceRecord(int id, int back)
        {
            EmployeeServiceRecord employeeservicerecord = await db.EmployeeServiceRecords.FindAsync(id);

            employeeservicerecord.deleted = true;
            employeeservicerecord.updated_on = DateTime.Now;
            employeeservicerecord.updated_by = Session["User_firstname"].ToString() + " " + Session["User_middlename"].ToString() + " " + Session["User_lastname"].ToString();

            await db.SaveChangesAsync();
            TempData["t_Info"] = "deleted";
            return RedirectToAction("Details", new { id = back });
        }

        public ActionResult EmployeeList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "EmployeeList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false).Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " +p.lastname,
                    is_active = p.is_active == true ? "Active" : "Passive",
                    department = p.department == null ? "" : p.department,
                    educational_attainment = p.educational_attainment == null ? "" : p.educational_attainment,
                    working_status = p.working_status == null ? "" : p.working_status

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "employee_list.pdf");
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

        public ActionResult EmployeeListThisYear()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                DateTime to = new DateTime(DateTime.Now.Year, 1, 1);
                DateTime from = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12), 23, 59, 59, 999);

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "EmployeeList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && (d.employment_date >= to && d.employment_date <= from)).Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    is_active = p.is_active == true ? "Active" : "Passive",
                    department = p.department == null ? "" : p.department,
                    educational_attainment = p.educational_attainment == null ? "" : p.educational_attainment,
                    working_status = p.working_status == null ? "" : p.working_status

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "employee_list(thisyear).pdf");
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

        public ActionResult SubstituteList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "SubstituteList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.appointment_status == "Substitute").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    department = p.department == null ? "" : p.department,
                    is_active = p.is_active == true ? "Active" : "Passive"

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "substitute_list.pdf");
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

        public ActionResult PartTimeASList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "PartTimeASList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.appointment_status == "Part-time").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    department = p.department == null ? "" : p.department,
                    is_active = p.is_active == true ? "Active" : "Passive"

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "parttimeAS_list.pdf");
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

        public ActionResult ProbationaryList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "ProbationaryList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.appointment_status == "Probationary").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    department = p.department == null ? "" : p.department,
                    is_active = p.is_active == true ? "Active" : "Passive"

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "probationary_list.pdf");
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

        public ActionResult PermanentList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "PermanentList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.appointment_status == "Permanent").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    department = p.department == null ? "" : p.department,
                    is_active = p.is_active == true ? "Active" : "Passive"

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "permanent_list.pdf");
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

        public ActionResult AdministratorList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "AdministratorList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.employment_type == "Administrator").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    department = p.department == null ? "" : p.department,
                    is_active = p.is_active == true ? "Active" : "Passive"

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "administrator_list.pdf");
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

        public ActionResult FacultyList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "FacultyList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.employment_type == "Faculty").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    department = p.department == null ? "" : p.department,
                    is_active = p.is_active == true ? "Active" : "Passive"

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "faculty_list.pdf");
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

        public ActionResult PersonnelList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "PersonnelList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.employment_type == "Personnel").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    department = p.department == null ? "" : p.department,
                    is_active = p.is_active == true ? "Active" : "Passive"

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "personnel_list.pdf");
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

        public ActionResult StaffList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "StaffList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.employment_type == "Staff").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    department = p.department == null ? "" : p.department,
                    is_active = p.is_active == true ? "Active" : "Passive"

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "staff_list.pdf");
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

        public ActionResult PartTimeWSList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "PartTimeWSList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.working_status == "Part-time").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    department = p.department == null ? "" : p.department,
                    is_active = p.is_active == true ? "Active" : "Passive"

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "parttimeWS_list.pdf");
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

        public ActionResult FullTimeList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "FullTimeList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.working_status == "Full-time").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    department = p.department == null ? "" : p.department,
                    is_active = p.is_active == true ? "Active" : "Passive"

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "fulltime_list.pdf");
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

        public ActionResult ActiveList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "ActiveList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.is_active == true).Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    department = p.department == null ? "" : p.department,

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "active_list.pdf");
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

        public ActionResult PassiveList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "PassiveList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.is_active == false).Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    department = p.department == null ? "" : p.department,

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "passive_list.pdf");
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

        public ActionResult SASList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "SASList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.department == "SAS").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    is_active = p.is_active == true ? "Active" : "Passive",
                    working_status = p.working_status == null ? "" : p.working_status

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "sas_list.pdf");
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

        public ActionResult SBAList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "SBAList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.department == "SBA").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    is_active = p.is_active == true ? "Active" : "Passive",
                    working_status = p.working_status == null ? "" : p.working_status

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "sba_list.pdf");
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

        public ActionResult SEList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "SEList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.department == "SE").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    is_active = p.is_active == true ? "Active" : "Passive",
                    working_status = p.working_status == null ? "" : p.working_status

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "se_list.pdf");
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

        public ActionResult SEAList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "SEAList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.department == "SEA").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    is_active = p.is_active == true ? "Active" : "Passive",
                    working_status = p.working_status == null ? "" : p.working_status

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "sea_list.pdf");
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

        public ActionResult SITList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "SITList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.department == "SIT").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    is_active = p.is_active == true ? "Active" : "Passive",
                    working_status = p.working_status == null ? "" : p.working_status

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "sit_list.pdf");
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

        public ActionResult SNList()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "SNList.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.department == "SN").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    is_active = p.is_active == true ? "Active" : "Passive",
                    working_status = p.working_status == null ? "" : p.working_status

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "sn_list.pdf");
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

        public ActionResult SBE1List()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "SBE1List.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.department == "SBE (Elementary)").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    is_active = p.is_active == true ? "Active" : "Passive",
                    working_status = p.working_status == null ? "" : p.working_status

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "elementary_list.pdf");
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

        public ActionResult SBE2List()
        {
            if (Session["UserID"] != null)
            {
                if (Session["User_role"].ToString() != "Administrator")
                {
                    return HttpNotFound();
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "SBE2List.rpt"));
                rd.SetDataSource(db.Employees.Where(d => d.deleted == false && d.department == "SBE (High School)").Select(p => new
                {
                    employee_id = p.employee_id,
                    employee_number = p.employee_number == null ? "" : p.employee_number,
                    firstname = p.firstname == null ? "" : p.firstname + " " + p.middlename + " " + p.lastname,
                    is_active = p.is_active == true ? "Active" : "Passive",
                    working_status = p.working_status == null ? "" : p.working_status

                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "highschool_list.pdf");
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

using EmployeeInformationManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeInformationManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext();

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.ActiveHomeIndex = "class = active";
              
                if (Session["User_role"].ToString() == "Administrator" || Session["User_role"].ToString() == "President")
                {
                    DateTime emplastJan_to = new DateTime(DateTime.Now.AddYears(-1).Year, 1, 1);
                    DateTime emplastJan_from = new DateTime(DateTime.Now.AddYears(-1).Year, 1, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 1), 23, 59, 59, 999);

                    var emplastJan = db.Employees.Count(d => d.deleted == false && (d.employment_date >= emplastJan_to && d.employment_date <= emplastJan_from));
                    ViewBag.emplastJan = emplastJan;

                    DateTime emplastFeb_to = new DateTime(DateTime.Now.AddYears(-1).Year, 2, 1);
                    DateTime emplastFeb_from = new DateTime(DateTime.Now.AddYears(-1).Year, 2, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 2), 23, 59, 59, 999);

                    var emplastFeb = db.Employees.Count(d => d.deleted == false && (d.employment_date >= emplastFeb_to && d.employment_date <= emplastFeb_from));
                    ViewBag.emplastFeb = emplastFeb;

                    DateTime emplastMar_to = new DateTime(DateTime.Now.AddYears(-1).Year, 3, 1);
                    DateTime emplastMar_from = new DateTime(DateTime.Now.AddYears(-1).Year, 3, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 3), 23, 59, 59, 999);

                    var emplastMar = db.Employees.Count(d => d.deleted == false && (d.employment_date >= emplastMar_to && d.employment_date <= emplastMar_from));
                    ViewBag.emplastMar = emplastMar;

                    DateTime emplastApr_to = new DateTime(DateTime.Now.AddYears(-1).Year, 4, 1);
                    DateTime emplastApr_from = new DateTime(DateTime.Now.AddYears(-1).Year, 4, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 4), 23, 59, 59, 999);

                    var emplastApr = db.Employees.Count(d => d.deleted == false && (d.employment_date >= emplastApr_to && d.employment_date <= emplastApr_from));
                    ViewBag.emplastApr = emplastApr;

                    DateTime emplastMay_to = new DateTime(DateTime.Now.AddYears(-1).Year, 5, 1);
                    DateTime emplastMay_from = new DateTime(DateTime.Now.AddYears(-1).Year, 5, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 5), 23, 59, 59, 999);

                    var emplastMay = db.Employees.Count(d => d.deleted == false && (d.employment_date >= emplastMay_to && d.employment_date <= emplastMay_from));
                    ViewBag.emplastMay = emplastMay;

                    DateTime emplastJun_to = new DateTime(DateTime.Now.AddYears(-1).Year, 6, 1);
                    DateTime emplastJun_from = new DateTime(DateTime.Now.AddYears(-1).Year, 6, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 6), 23, 59, 59, 999);

                    var emplastJun = db.Employees.Count(d => d.deleted == false && (d.employment_date >= emplastJun_to && d.employment_date <= emplastJun_from));
                    ViewBag.emplastJun = emplastJun;

                    DateTime emplastJul_to = new DateTime(DateTime.Now.AddYears(-1).Year, 7, 1);
                    DateTime emplastJul_from = new DateTime(DateTime.Now.AddYears(-1).Year, 7, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 7), 23, 59, 59, 999);

                    var emplastJul = db.Employees.Count(d => d.deleted == false && (d.employment_date >= emplastJul_to && d.employment_date <= emplastJul_from));
                    ViewBag.emplastJul = emplastJul;

                    DateTime emplastAug_to = new DateTime(DateTime.Now.AddYears(-1).Year, 8, 1);
                    DateTime emplastAug_from = new DateTime(DateTime.Now.AddYears(-1).Year, 8, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 8), 23, 59, 59, 999);

                    var emplastAug = db.Employees.Count(d => d.deleted == false && (d.employment_date >= emplastAug_to && d.employment_date <= emplastAug_from));
                    ViewBag.emplastAug = emplastAug;

                    DateTime emplastSep_to = new DateTime(DateTime.Now.AddYears(-1).Year, 9, 1);
                    DateTime emplastSep_from = new DateTime(DateTime.Now.AddYears(-1).Year, 9, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 9), 23, 59, 59, 999);

                    var emplastSep = db.Employees.Count(d => d.deleted == false && (d.employment_date >= emplastSep_to && d.employment_date <= emplastSep_from));
                    ViewBag.emplastSep = emplastSep;

                    DateTime emplastOct_to = new DateTime(DateTime.Now.AddYears(-1).Year, 10, 1);
                    DateTime emplastOct_from = new DateTime(DateTime.Now.AddYears(-1).Year, 10, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 10), 23, 59, 59, 999);

                    var emplastOct = db.Employees.Count(d => d.deleted == false && (d.employment_date >= emplastOct_to && d.employment_date <= emplastOct_from));
                    ViewBag.emplastOct = emplastOct;

                    DateTime emplastNov_to = new DateTime(DateTime.Now.AddYears(-1).Year, 11, 1);
                    DateTime emplastNov_from = new DateTime(DateTime.Now.AddYears(-1).Year, 11, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 11), 23, 59, 59, 999);

                    var emplastNov = db.Employees.Count(d => d.deleted == false && (d.employment_date >= emplastNov_to && d.employment_date <= emplastNov_from));
                    ViewBag.emplastNov = emplastNov;

                    DateTime emplastDec_to = new DateTime(DateTime.Now.AddYears(-1).Year, 12, 1);
                    DateTime emplastDec_from = new DateTime(DateTime.Now.AddYears(-1).Year, 12, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 12), 23, 59, 59, 999);

                    var emplastDec = db.Employees.Count(d => d.deleted == false && (d.employment_date >= emplastDec_to && d.employment_date <= emplastDec_from));
                    ViewBag.emplastDec = emplastDec;

                    //

                    DateTime empthisJan_to = new DateTime(DateTime.Now.Year, 1, 1);
                    DateTime empthisJan_from = new DateTime(DateTime.Now.Year, 1, DateTime.DaysInMonth(DateTime.Now.Year, 1), 23, 59, 59, 999);

                    var empthisJan = db.Employees.Count(d => d.deleted == false && (d.employment_date >= empthisJan_to && d.employment_date <= empthisJan_from));
                    ViewBag.empthisJan = empthisJan;

                    DateTime empthisFeb_to = new DateTime(DateTime.Now.Year, 2, 1);
                    DateTime empthisFeb_from = new DateTime(DateTime.Now.Year, 2, DateTime.DaysInMonth(DateTime.Now.Year, 2), 23, 59, 59, 999);

                    var empthisFeb = db.Employees.Count(d => d.deleted == false && (d.employment_date >= empthisFeb_to && d.employment_date <= empthisFeb_from));
                    ViewBag.empthisFeb = empthisFeb;

                    DateTime empthisMar_to = new DateTime(DateTime.Now.Year, 3, 1);
                    DateTime empthisMar_from = new DateTime(DateTime.Now.Year, 3, DateTime.DaysInMonth(DateTime.Now.Year, 3), 23, 59, 59, 999);

                    var empthisMar = db.Employees.Count(d => d.deleted == false && (d.employment_date >= empthisMar_to && d.employment_date <= empthisMar_from));
                    ViewBag.empthisMar = empthisMar;

                    DateTime empthisApr_to = new DateTime(DateTime.Now.Year, 4, 1);
                    DateTime empthisApr_from = new DateTime(DateTime.Now.Year, 4, DateTime.DaysInMonth(DateTime.Now.Year, 4), 23, 59, 59, 999);

                    var empthisApr = db.Employees.Count(d => d.deleted == false && (d.employment_date >= empthisApr_to && d.employment_date <= empthisApr_from));
                    ViewBag.empthisApr = empthisApr;

                    DateTime empthisMay_to = new DateTime(DateTime.Now.Year, 5, 1);
                    DateTime empthisMay_from = new DateTime(DateTime.Now.Year, 5, DateTime.DaysInMonth(DateTime.Now.Year, 5), 23, 59, 59, 999);

                    var empthisMay = db.Employees.Count(d => d.deleted == false && (d.employment_date >= empthisMay_to && d.employment_date <= empthisMay_from));
                    ViewBag.empthisMay = empthisMay;

                    DateTime empthisJun_to = new DateTime(DateTime.Now.Year, 6, 1);
                    DateTime empthisJun_from = new DateTime(DateTime.Now.Year, 6, DateTime.DaysInMonth(DateTime.Now.Year, 6), 23, 59, 59, 999);

                    var empthisJun = db.Employees.Count(d => d.deleted == false && (d.employment_date >= empthisJun_to && d.employment_date <= empthisJun_from));
                    ViewBag.empthisJun = empthisJun;

                    DateTime empthisJul_to = new DateTime(DateTime.Now.Year, 7, 1);
                    DateTime empthisJul_from = new DateTime(DateTime.Now.Year, 7, DateTime.DaysInMonth(DateTime.Now.Year, 7), 23, 59, 59, 999);

                    var empthisJul = db.Employees.Count(d => d.deleted == false && (d.employment_date >= empthisJul_to && d.employment_date <= empthisJul_from));
                    ViewBag.empthisJul = empthisJul;

                    DateTime empthisAug_to = new DateTime(DateTime.Now.Year, 8, 1);
                    DateTime empthisAug_from = new DateTime(DateTime.Now.Year, 8, DateTime.DaysInMonth(DateTime.Now.Year, 8), 23, 59, 59, 999);

                    var empthisAug = db.Employees.Count(d => d.deleted == false && (d.employment_date >= empthisAug_to && d.employment_date <= empthisAug_from));
                    ViewBag.empthisAug = empthisAug;

                    DateTime empthisSep_to = new DateTime(DateTime.Now.Year, 9, 1);
                    DateTime empthisSep_from = new DateTime(DateTime.Now.Year, 9, DateTime.DaysInMonth(DateTime.Now.Year, 9), 23, 59, 59, 999);

                    var empthisSep = db.Employees.Count(d => d.deleted == false && (d.employment_date >= empthisSep_to && d.employment_date <= empthisSep_from));
                    ViewBag.empthisSep = empthisSep;

                    DateTime empthisOct_to = new DateTime(DateTime.Now.Year, 10, 1);
                    DateTime empthisOct_from = new DateTime(DateTime.Now.Year, 10, DateTime.DaysInMonth(DateTime.Now.Year, 10), 23, 59, 59, 999);

                    var empthisOct = db.Employees.Count(d => d.deleted == false && (d.employment_date >= empthisOct_to && d.employment_date <= empthisOct_from));
                    ViewBag.empthisOct = empthisOct;

                    DateTime empthisNov_to = new DateTime(DateTime.Now.Year, 11, 1);
                    DateTime empthisNov_from = new DateTime(DateTime.Now.Year, 11, DateTime.DaysInMonth(DateTime.Now.Year, 11), 23, 59, 59, 999);

                    var empthisNov = db.Employees.Count(d => d.deleted == false && (d.employment_date >= empthisNov_to && d.employment_date <= empthisNov_from));
                    ViewBag.empthisNov = empthisNov;

                    DateTime empthisDec_to = new DateTime(DateTime.Now.Year, 12, 1);
                    DateTime empthisDec_from = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12), 23, 59, 59, 999);

                    var empthisDec = db.Employees.Count(d => d.deleted == false && (d.employment_date >= empthisDec_to && d.employment_date <= empthisDec_from));
                    ViewBag.empthisDec = empthisDec;

                    //

                    DateTime applastJan_to = new DateTime(DateTime.Now.AddYears(-1).Year, 1, 1);
                    DateTime applastJan_from = new DateTime(DateTime.Now.AddYears(-1).Year, 1, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 1), 23, 59, 59, 999);

                    var applastJan = db.Applicants.Count(d => d.deleted == false && (d.date_created >= applastJan_to && d.date_created <= applastJan_from));
                    ViewBag.applastJan = applastJan;

                    DateTime applastFeb_to = new DateTime(DateTime.Now.AddYears(-1).Year, 2, 1);
                    DateTime applastFeb_from = new DateTime(DateTime.Now.AddYears(-1).Year, 2, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 2), 23, 59, 59, 999);

                    var applastFeb = db.Applicants.Count(d => d.deleted == false && (d.date_created >= emplastFeb_to && d.date_created <= emplastFeb_from));
                    ViewBag.applastFeb = applastFeb;

                    DateTime applastMar_to = new DateTime(DateTime.Now.AddYears(-1).Year, 3, 1);
                    DateTime applastMar_from = new DateTime(DateTime.Now.AddYears(-1).Year, 3, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 3), 23, 59, 59, 999);

                    var applastMar = db.Applicants.Count(d => d.deleted == false && (d.date_created >= applastMar_to && d.date_created <= applastMar_from));
                    ViewBag.applastMar = applastMar;

                    DateTime applastApr_to = new DateTime(DateTime.Now.AddYears(-1).Year, 4, 1);
                    DateTime applastApr_from = new DateTime(DateTime.Now.AddYears(-1).Year, 4, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 4), 23, 59, 59, 999);

                    var applastApr = db.Applicants.Count(d => d.deleted == false && (d.date_created >= applastApr_to && d.date_created <= applastApr_from));
                    ViewBag.applastApr = applastApr;

                    DateTime applastMay_to = new DateTime(DateTime.Now.AddYears(-1).Year, 5, 1);
                    DateTime applastMay_from = new DateTime(DateTime.Now.AddYears(-1).Year, 5, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 5), 23, 59, 59, 999);

                    var applastMay = db.Applicants.Count(d => d.deleted == false && (d.date_created >= applastMay_to && d.date_created <= applastMay_from));
                    ViewBag.applastMay = applastMay;

                    DateTime applastJun_to = new DateTime(DateTime.Now.AddYears(-1).Year, 6, 1);
                    DateTime applastJun_from = new DateTime(DateTime.Now.AddYears(-1).Year, 6, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 6), 23, 59, 59, 999);

                    var applastJun = db.Applicants.Count(d => d.deleted == false && (d.date_created >= applastJun_to && d.date_created <= applastJun_from));
                    ViewBag.applastJun = applastJun;

                    DateTime applastJul_to = new DateTime(DateTime.Now.AddYears(-1).Year, 7, 1);
                    DateTime applastJul_from = new DateTime(DateTime.Now.AddYears(-1).Year, 7, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 7), 23, 59, 59, 999);

                    var applastJul = db.Applicants.Count(d => d.deleted == false && (d.date_created >= applastJul_to && d.date_created <= applastJul_from));
                    ViewBag.applastJul = applastJul;

                    DateTime applastAug_to = new DateTime(DateTime.Now.AddYears(-1).Year, 8, 1);
                    DateTime applastAug_from = new DateTime(DateTime.Now.AddYears(-1).Year, 8, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 8), 23, 59, 59, 999);

                    var applastAug = db.Applicants.Count(d => d.deleted == false && (d.date_created >= applastAug_to && d.date_created <= applastAug_from));
                    ViewBag.applastAug = applastAug;

                    DateTime applastSep_to = new DateTime(DateTime.Now.AddYears(-1).Year, 9, 1);
                    DateTime applastSep_from = new DateTime(DateTime.Now.AddYears(-1).Year, 9, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 9), 23, 59, 59, 999);

                    var applastSep = db.Applicants.Count(d => d.deleted == false && (d.date_created >= applastSep_to && d.date_created <= applastSep_from));
                    ViewBag.applastSep = applastSep;

                    DateTime applastOct_to = new DateTime(DateTime.Now.AddYears(-1).Year, 10, 1);
                    DateTime applastOct_from = new DateTime(DateTime.Now.AddYears(-1).Year, 10, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 10), 23, 59, 59, 999);

                    var applastOct = db.Applicants.Count(d => d.deleted == false && (d.date_created >= applastOct_to && d.date_created <= applastOct_from));
                    ViewBag.applastOct = applastOct;

                    DateTime applastNov_to = new DateTime(DateTime.Now.AddYears(-1).Year, 11, 1);
                    DateTime applastNov_from = new DateTime(DateTime.Now.AddYears(-1).Year, 11, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 11), 23, 59, 59, 999);

                    var applastNov = db.Applicants.Count(d => d.deleted == false && (d.date_created >= applastNov_to && d.date_created <= applastNov_from));
                    ViewBag.applastNov = applastNov;

                    DateTime applastDec_to = new DateTime(DateTime.Now.AddYears(-1).Year, 12, 1);
                    DateTime applastDec_from = new DateTime(DateTime.Now.AddYears(-1).Year, 12, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 12), 23, 59, 59, 999);

                    var applastDec = db.Applicants.Count(d => d.deleted == false && (d.date_created >= applastDec_to && d.date_created <= applastDec_from));
                    ViewBag.applastDec = applastDec;

                    //

                    DateTime appthisJan_to = new DateTime(DateTime.Now.Year, 1, 1);
                    DateTime appthisJan_from = new DateTime(DateTime.Now.Year, 1, DateTime.DaysInMonth(DateTime.Now.Year, 1), 23, 59, 59, 999);

                    var appthisJan = db.Applicants.Count(d => d.deleted == false && (d.date_created >= appthisJan_to && d.date_created <= appthisJan_from));
                    ViewBag.appthisJan = appthisJan;

                    DateTime appthisFeb_to = new DateTime(DateTime.Now.Year, 2, 1);
                    DateTime appthisFeb_from = new DateTime(DateTime.Now.Year, 2, DateTime.DaysInMonth(DateTime.Now.Year, 2), 23, 59, 59, 999);

                    var appthisFeb = db.Applicants.Count(d => d.deleted == false && (d.date_created >= appthisFeb_to && d.date_created <= appthisFeb_from));
                    ViewBag.appthisFeb = appthisFeb;

                    DateTime appthisMar_to = new DateTime(DateTime.Now.Year, 3, 1);
                    DateTime appthisMar_from = new DateTime(DateTime.Now.Year, 3, DateTime.DaysInMonth(DateTime.Now.Year, 3), 23, 59, 59, 999);

                    var appthisMar = db.Applicants.Count(d => d.deleted == false && (d.date_created >= appthisMar_to && d.date_created <= appthisMar_from));
                    ViewBag.appthisMar = appthisMar;

                    DateTime appthisApr_to = new DateTime(DateTime.Now.Year, 4, 1);
                    DateTime appthisApr_from = new DateTime(DateTime.Now.Year, 4, DateTime.DaysInMonth(DateTime.Now.Year, 4), 23, 59, 59, 999);

                    var appthisApr = db.Applicants.Count(d => d.deleted == false && (d.date_created >= appthisApr_to && d.date_created <= appthisApr_from));
                    ViewBag.appthisApr = appthisApr;

                    DateTime appthisMay_to = new DateTime(DateTime.Now.Year, 5, 1);
                    DateTime appthisMay_from = new DateTime(DateTime.Now.Year, 5, DateTime.DaysInMonth(DateTime.Now.Year, 5), 23, 59, 59, 999);

                    var appthisMay = db.Applicants.Count(d => d.deleted == false && (d.date_created >= appthisMay_to && d.date_created <= appthisMay_from));
                    ViewBag.appthisMay = appthisMay;

                    DateTime appthisJun_to = new DateTime(DateTime.Now.Year, 6, 1);
                    DateTime appthisJun_from = new DateTime(DateTime.Now.Year, 6, DateTime.DaysInMonth(DateTime.Now.Year, 6), 23, 59, 59, 999);

                    var appthisJun = db.Applicants.Count(d => d.deleted == false && (d.date_created >= appthisJun_to && d.date_created <= appthisJun_from));
                    ViewBag.appthisJun = appthisJun;

                    DateTime appthisJul_to = new DateTime(DateTime.Now.Year, 7, 1);
                    DateTime appthisJul_from = new DateTime(DateTime.Now.Year, 7, DateTime.DaysInMonth(DateTime.Now.Year, 7), 23, 59, 59, 999);

                    var appthisJul = db.Applicants.Count(d => d.deleted == false && (d.date_created >= appthisJul_to && d.date_created <= appthisJul_from));
                    ViewBag.appthisJul = appthisJul;

                    DateTime appthisAug_to = new DateTime(DateTime.Now.Year, 8, 1);
                    DateTime appthisAug_from = new DateTime(DateTime.Now.Year, 8, DateTime.DaysInMonth(DateTime.Now.Year, 8), 23, 59, 59, 999);

                    var appthisAug = db.Applicants.Count(d => d.deleted == false && (d.date_created >= appthisAug_to && d.date_created <= appthisAug_from));
                    ViewBag.appthisAug = appthisAug;

                    DateTime appthisSep_to = new DateTime(DateTime.Now.Year, 9, 1);
                    DateTime appthisSep_from = new DateTime(DateTime.Now.Year, 9, DateTime.DaysInMonth(DateTime.Now.Year, 9), 23, 59, 59, 999);

                    var appthisSep = db.Applicants.Count(d => d.deleted == false && (d.date_created >= appthisSep_to && d.date_created <= appthisSep_from));
                    ViewBag.appthisSep = appthisSep;

                    DateTime appthisOct_to = new DateTime(DateTime.Now.Year, 10, 1);
                    DateTime appthisOct_from = new DateTime(DateTime.Now.Year, 10, DateTime.DaysInMonth(DateTime.Now.Year, 10), 23, 59, 59, 999);

                    var appthisOct = db.Applicants.Count(d => d.deleted == false && (d.date_created >= appthisOct_to && d.date_created <= appthisOct_from));
                    ViewBag.appthisOct = appthisOct;

                    DateTime appthisNov_to = new DateTime(DateTime.Now.Year, 11, 1);
                    DateTime appthisNov_from = new DateTime(DateTime.Now.Year, 11, DateTime.DaysInMonth(DateTime.Now.Year, 11), 23, 59, 59, 999);

                    var appthisNov = db.Applicants.Count(d => d.deleted == false && (d.date_created >= appthisNov_to && d.date_created <= appthisNov_from));
                    ViewBag.appthisNov = appthisNov;

                    DateTime appthisDec_to = new DateTime(DateTime.Now.Year, 12, 1);
                    DateTime appthisDec_from = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12), 23, 59, 59, 999);

                    var appthisDec = db.Applicants.Count(d => d.deleted == false && (d.date_created >= appthisDec_to && d.date_created <= appthisDec_from));
                    ViewBag.appthisDec = appthisDec;

                    ViewBag.CountEmployees = db.Employees.Count(d => d.deleted == false);
                    ViewBag.CountEmployeesActive = db.Employees.Count(d => d.deleted == false && d.is_active == true);
                    ViewBag.CountEmployeesPassive = db.Employees.Count(d => d.deleted == false && d.is_active == false);
                    ViewBag.CountApplicants = db.Applicants.Count(d => d.deleted == false);
                    ViewBag.CountTrainingsSeminars = db.TrainingSeminars.Count(d => d.deleted == false);
                    ViewBag.CountUsers = db.Users.Count(d => d.deleted == false);

                    ViewBag.LatestEmployee = db.Employees.Where(i => i.deleted == false && i.is_active == true).OrderByDescending(d => d.employment_date).ToList();
                    ViewBag.RecentApplicant = db.Applicants.Where(i => i.deleted == false).OrderByDescending(d => d.applicant_id).ToList();

                    ViewBag.admin = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == "Administrator");
                    ViewBag.faculty = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == "Faculty");
                    ViewBag.personnel = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == "Personnel");
                    ViewBag.staff = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == "Staff");
                    ViewBag.male = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.gender == "Male");
                    ViewBag.female = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.gender == "Female");
                    ViewBag.single = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.civil_status == "Single");
                    ViewBag.married = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.civil_status == "Married");
                    ViewBag.substitute = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.appointment_status == "Substitute");
                    ViewBag.parttimeAS = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.appointment_status == "Part-time");
                    ViewBag.probationary = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.appointment_status == "Probationary");
                    ViewBag.permanent = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.appointment_status == "Permanent");

                    ViewBag.deptSAS = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == "SAS");
                    ViewBag.deptSBA = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == "SBA");
                    ViewBag.deptSE = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == "SE");
                    ViewBag.deptSEA = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == "SEA");
                    ViewBag.deptSIT = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == "SIT");
                    ViewBag.deptSN = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == "SN");
                    ViewBag.deptSBE1 = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == "SBE (Elementary)");
                    ViewBag.deptSBE2 = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == "SBE (High School)");

                    ViewBag.postGrad = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.educational_attainment == "Postgraduate");
                    ViewBag.Grad = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.educational_attainment == "Graduate");
                    ViewBag.underGrad = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.educational_attainment == "Undergraduate");

                    ViewBag.parttimeWS = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.working_status == "Part-time");
                    ViewBag.fulltime = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.working_status == "Full-time");
                }

                if (Session["User_role"].ToString() == "Dean SAS" || Session["User_role"].ToString() == "Dean SBA" || Session["User_role"].ToString() == "Dean SE" || Session["User_role"].ToString() == "Dean SEA" || Session["User_role"].ToString() == "Dean SIT" || Session["User_role"].ToString() == "Dean SN" || Session["User_role"].ToString() == "Principal Elementary" || Session["User_role"].ToString() == "Principal High School")
                {
                    var dept = Session["dept"].ToString();

                    DateTime emplastJan_to = new DateTime(DateTime.Now.AddYears(-1).Year, 1, 1);
                    DateTime emplastJan_from = new DateTime(DateTime.Now.AddYears(-1).Year, 1, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 1), 23, 59, 59, 999);

                    var emplastJan = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= emplastJan_to && d.employment_date <= emplastJan_from));
                    ViewBag.emplastJan = emplastJan;

                    DateTime emplastFeb_to = new DateTime(DateTime.Now.AddYears(-1).Year, 2, 1);
                    DateTime emplastFeb_from = new DateTime(DateTime.Now.AddYears(-1).Year, 2, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 2), 23, 59, 59, 999);

                    var emplastFeb = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= emplastFeb_to && d.employment_date <= emplastFeb_from));
                    ViewBag.emplastFeb = emplastFeb;

                    DateTime emplastMar_to = new DateTime(DateTime.Now.AddYears(-1).Year, 3, 1);
                    DateTime emplastMar_from = new DateTime(DateTime.Now.AddYears(-1).Year, 3, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 3), 23, 59, 59, 999);

                    var emplastMar = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= emplastMar_to && d.employment_date <= emplastMar_from));
                    ViewBag.emplastMar = emplastMar;

                    DateTime emplastApr_to = new DateTime(DateTime.Now.AddYears(-1).Year, 4, 1);
                    DateTime emplastApr_from = new DateTime(DateTime.Now.AddYears(-1).Year, 4, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 4), 23, 59, 59, 999);

                    var emplastApr = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= emplastApr_to && d.employment_date <= emplastApr_from));
                    ViewBag.emplastApr = emplastApr;

                    DateTime emplastMay_to = new DateTime(DateTime.Now.AddYears(-1).Year, 5, 1);
                    DateTime emplastMay_from = new DateTime(DateTime.Now.AddYears(-1).Year, 5, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 5), 23, 59, 59, 999);

                    var emplastMay = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= emplastMay_to && d.employment_date <= emplastMay_from));
                    ViewBag.emplastMay = emplastMay;

                    DateTime emplastJun_to = new DateTime(DateTime.Now.AddYears(-1).Year, 6, 1);
                    DateTime emplastJun_from = new DateTime(DateTime.Now.AddYears(-1).Year, 6, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 6), 23, 59, 59, 999);

                    var emplastJun = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= emplastJun_to && d.employment_date <= emplastJun_from));
                    ViewBag.emplastJun = emplastJun;

                    DateTime emplastJul_to = new DateTime(DateTime.Now.AddYears(-1).Year, 7, 1);
                    DateTime emplastJul_from = new DateTime(DateTime.Now.AddYears(-1).Year, 7, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 7), 23, 59, 59, 999);

                    var emplastJul = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= emplastJul_to && d.employment_date <= emplastJul_from));
                    ViewBag.emplastJul = emplastJul;

                    DateTime emplastAug_to = new DateTime(DateTime.Now.AddYears(-1).Year, 8, 1);
                    DateTime emplastAug_from = new DateTime(DateTime.Now.AddYears(-1).Year, 8, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 8), 23, 59, 59, 999);

                    var emplastAug = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= emplastAug_to && d.employment_date <= emplastAug_from));
                    ViewBag.emplastAug = emplastAug;

                    DateTime emplastSep_to = new DateTime(DateTime.Now.AddYears(-1).Year, 9, 1);
                    DateTime emplastSep_from = new DateTime(DateTime.Now.AddYears(-1).Year, 9, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 9), 23, 59, 59, 999);

                    var emplastSep = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= emplastSep_to && d.employment_date <= emplastSep_from));
                    ViewBag.emplastSep = emplastSep;

                    DateTime emplastOct_to = new DateTime(DateTime.Now.AddYears(-1).Year, 10, 1);
                    DateTime emplastOct_from = new DateTime(DateTime.Now.AddYears(-1).Year, 10, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 10), 23, 59, 59, 999);

                    var emplastOct = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= emplastOct_to && d.employment_date <= emplastOct_from));
                    ViewBag.emplastOct = emplastOct;

                    DateTime emplastNov_to = new DateTime(DateTime.Now.AddYears(-1).Year, 11, 1);
                    DateTime emplastNov_from = new DateTime(DateTime.Now.AddYears(-1).Year, 11, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 11), 23, 59, 59, 999);

                    var emplastNov = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= emplastNov_to && d.employment_date <= emplastNov_from));
                    ViewBag.emplastNov = emplastNov;

                    DateTime emplastDec_to = new DateTime(DateTime.Now.AddYears(-1).Year, 12, 1);
                    DateTime emplastDec_from = new DateTime(DateTime.Now.AddYears(-1).Year, 12, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 12), 23, 59, 59, 999);

                    var emplastDec = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= emplastDec_to && d.employment_date <= emplastDec_from));
                    ViewBag.emplastDec = emplastDec;

                    //

                    DateTime empthisJan_to = new DateTime(DateTime.Now.Year, 1, 1);
                    DateTime empthisJan_from = new DateTime(DateTime.Now.Year, 1, DateTime.DaysInMonth(DateTime.Now.Year, 1), 23, 59, 59, 999);

                    var empthisJan = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= empthisJan_to && d.employment_date <= empthisJan_from));
                    ViewBag.empthisJan = empthisJan;

                    DateTime empthisFeb_to = new DateTime(DateTime.Now.Year, 2, 1);
                    DateTime empthisFeb_from = new DateTime(DateTime.Now.Year, 2, DateTime.DaysInMonth(DateTime.Now.Year, 2), 23, 59, 59, 999);

                    var empthisFeb = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= empthisFeb_to && d.employment_date <= empthisFeb_from));
                    ViewBag.empthisFeb = empthisFeb;

                    DateTime empthisMar_to = new DateTime(DateTime.Now.Year, 3, 1);
                    DateTime empthisMar_from = new DateTime(DateTime.Now.Year, 3, DateTime.DaysInMonth(DateTime.Now.Year, 3), 23, 59, 59, 999);

                    var empthisMar = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= empthisMar_to && d.employment_date <= empthisMar_from));
                    ViewBag.empthisMar = empthisMar;

                    DateTime empthisApr_to = new DateTime(DateTime.Now.Year, 4, 1);
                    DateTime empthisApr_from = new DateTime(DateTime.Now.Year, 4, DateTime.DaysInMonth(DateTime.Now.Year, 4), 23, 59, 59, 999);

                    var empthisApr = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= empthisApr_to && d.employment_date <= empthisApr_from));
                    ViewBag.empthisApr = empthisApr;

                    DateTime empthisMay_to = new DateTime(DateTime.Now.Year, 5, 1);
                    DateTime empthisMay_from = new DateTime(DateTime.Now.Year, 5, DateTime.DaysInMonth(DateTime.Now.Year, 5), 23, 59, 59, 999);

                    var empthisMay = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= empthisMay_to && d.employment_date <= empthisMay_from));
                    ViewBag.empthisMay = empthisMay;

                    DateTime empthisJun_to = new DateTime(DateTime.Now.Year, 6, 1);
                    DateTime empthisJun_from = new DateTime(DateTime.Now.Year, 6, DateTime.DaysInMonth(DateTime.Now.Year, 6), 23, 59, 59, 999);

                    var empthisJun = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= empthisJun_to && d.employment_date <= empthisJun_from));
                    ViewBag.empthisJun = empthisJun;

                    DateTime empthisJul_to = new DateTime(DateTime.Now.Year, 7, 1);
                    DateTime empthisJul_from = new DateTime(DateTime.Now.Year, 7, DateTime.DaysInMonth(DateTime.Now.Year, 7), 23, 59, 59, 999);

                    var empthisJul = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= empthisJul_to && d.employment_date <= empthisJul_from));
                    ViewBag.empthisJul = empthisJul;

                    DateTime empthisAug_to = new DateTime(DateTime.Now.Year, 8, 1);
                    DateTime empthisAug_from = new DateTime(DateTime.Now.Year, 8, DateTime.DaysInMonth(DateTime.Now.Year, 8), 23, 59, 59, 999);

                    var empthisAug = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= empthisAug_to && d.employment_date <= empthisAug_from));
                    ViewBag.empthisAug = empthisAug;

                    DateTime empthisSep_to = new DateTime(DateTime.Now.Year, 9, 1);
                    DateTime empthisSep_from = new DateTime(DateTime.Now.Year, 9, DateTime.DaysInMonth(DateTime.Now.Year, 9), 23, 59, 59, 999);

                    var empthisSep = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= empthisSep_to && d.employment_date <= empthisSep_from));
                    ViewBag.empthisSep = empthisSep;

                    DateTime empthisOct_to = new DateTime(DateTime.Now.Year, 10, 1);
                    DateTime empthisOct_from = new DateTime(DateTime.Now.Year, 10, DateTime.DaysInMonth(DateTime.Now.Year, 10), 23, 59, 59, 999);

                    var empthisOct = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= empthisOct_to && d.employment_date <= empthisOct_from));
                    ViewBag.empthisOct = empthisOct;

                    DateTime empthisNov_to = new DateTime(DateTime.Now.Year, 11, 1);
                    DateTime empthisNov_from = new DateTime(DateTime.Now.Year, 11, DateTime.DaysInMonth(DateTime.Now.Year, 11), 23, 59, 59, 999);

                    var empthisNov = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= empthisNov_to && d.employment_date <= empthisNov_from));
                    ViewBag.empthisNov = empthisNov;

                    DateTime empthisDec_to = new DateTime(DateTime.Now.Year, 12, 1);
                    DateTime empthisDec_from = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12), 23, 59, 59, 999);

                    var empthisDec = db.Employees.Count(d => d.deleted == false && d.department == dept && (d.employment_date >= empthisDec_to && d.employment_date <= empthisDec_from));
                    ViewBag.empthisDec = empthisDec;

                    ViewBag.CountEmployees = db.Employees.Count(d => d.deleted == false && d.department == dept);
                    ViewBag.CountEmployeesActive = db.Employees.Count(d => d.deleted == false && d.is_active == true && d.department == dept);
                    ViewBag.CountEmployeesPassive = db.Employees.Count(d => d.deleted == false && d.is_active == false && d.department == dept);

                    ViewBag.LatestEmployee = db.Employees.Where(i => i.deleted == false && i.is_active == true && i.department == dept).OrderByDescending(d => d.employment_date).ToList();
                    
                    ViewBag.admin = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.employment_type == "Administrator");
                    ViewBag.faculty = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.employment_type == "Faculty");
                    ViewBag.personnel = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.employment_type == "Personnel");
                    ViewBag.staff = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.employment_type == "Staff");
                    ViewBag.male = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.gender == "Male");
                    ViewBag.female = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.gender == "Female");
                    ViewBag.single = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.civil_status == "Single");
                    ViewBag.married = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.civil_status == "Married");
                    ViewBag.substitute = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.appointment_status == "Substitute");
                    ViewBag.parttimeAS = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.appointment_status == "Part-time");
                    ViewBag.probationary = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.appointment_status == "Probationary");
                    ViewBag.permanent = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.appointment_status == "Permanent");

                    ViewBag.postGrad = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.educational_attainment == "Postgraduate");
                    ViewBag.Grad = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.educational_attainment == "Graduate");
                    ViewBag.underGrad = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.educational_attainment == "Undergraduate");

                    ViewBag.parttimeWS = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.working_status == "Part-time");
                    ViewBag.fulltime = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.department == dept && i.working_status == "Full-time");
                }

                if (Session["User_role"].ToString() == "VPA" || Session["User_role"].ToString() == "VPAA")
                {
                    var emp_type = Session["emp_type"].ToString();

                    DateTime emplastJan_to = new DateTime(DateTime.Now.AddYears(-1).Year, 1, 1);
                    DateTime emplastJan_from = new DateTime(DateTime.Now.AddYears(-1).Year, 1, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 1), 23, 59, 59, 999);

                    var emplastJan = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= emplastJan_to && d.employment_date <= emplastJan_from));
                    ViewBag.emplastJan = emplastJan;

                    DateTime emplastFeb_to = new DateTime(DateTime.Now.AddYears(-1).Year, 2, 1);
                    DateTime emplastFeb_from = new DateTime(DateTime.Now.AddYears(-1).Year, 2, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 2), 23, 59, 59, 999);

                    var emplastFeb = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= emplastFeb_to && d.employment_date <= emplastFeb_from));
                    ViewBag.emplastFeb = emplastFeb;

                    DateTime emplastMar_to = new DateTime(DateTime.Now.AddYears(-1).Year, 3, 1);
                    DateTime emplastMar_from = new DateTime(DateTime.Now.AddYears(-1).Year, 3, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 3), 23, 59, 59, 999);

                    var emplastMar = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= emplastMar_to && d.employment_date <= emplastMar_from));
                    ViewBag.emplastMar = emplastMar;

                    DateTime emplastApr_to = new DateTime(DateTime.Now.AddYears(-1).Year, 4, 1);
                    DateTime emplastApr_from = new DateTime(DateTime.Now.AddYears(-1).Year, 4, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 4), 23, 59, 59, 999);

                    var emplastApr = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= emplastApr_to && d.employment_date <= emplastApr_from));
                    ViewBag.emplastApr = emplastApr;

                    DateTime emplastMay_to = new DateTime(DateTime.Now.AddYears(-1).Year, 5, 1);
                    DateTime emplastMay_from = new DateTime(DateTime.Now.AddYears(-1).Year, 5, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 5), 23, 59, 59, 999);

                    var emplastMay = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= emplastMay_to && d.employment_date <= emplastMay_from));
                    ViewBag.emplastMay = emplastMay;

                    DateTime emplastJun_to = new DateTime(DateTime.Now.AddYears(-1).Year, 6, 1);
                    DateTime emplastJun_from = new DateTime(DateTime.Now.AddYears(-1).Year, 6, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 6), 23, 59, 59, 999);

                    var emplastJun = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= emplastJun_to && d.employment_date <= emplastJun_from));
                    ViewBag.emplastJun = emplastJun;

                    DateTime emplastJul_to = new DateTime(DateTime.Now.AddYears(-1).Year, 7, 1);
                    DateTime emplastJul_from = new DateTime(DateTime.Now.AddYears(-1).Year, 7, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 7), 23, 59, 59, 999);

                    var emplastJul = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= emplastJul_to && d.employment_date <= emplastJul_from));
                    ViewBag.emplastJul = emplastJul;

                    DateTime emplastAug_to = new DateTime(DateTime.Now.AddYears(-1).Year, 8, 1);
                    DateTime emplastAug_from = new DateTime(DateTime.Now.AddYears(-1).Year, 8, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 8), 23, 59, 59, 999);

                    var emplastAug = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= emplastAug_to && d.employment_date <= emplastAug_from));
                    ViewBag.emplastAug = emplastAug;

                    DateTime emplastSep_to = new DateTime(DateTime.Now.AddYears(-1).Year, 9, 1);
                    DateTime emplastSep_from = new DateTime(DateTime.Now.AddYears(-1).Year, 9, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 9), 23, 59, 59, 999);

                    var emplastSep = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= emplastSep_to && d.employment_date <= emplastSep_from));
                    ViewBag.emplastSep = emplastSep;

                    DateTime emplastOct_to = new DateTime(DateTime.Now.AddYears(-1).Year, 10, 1);
                    DateTime emplastOct_from = new DateTime(DateTime.Now.AddYears(-1).Year, 10, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 10), 23, 59, 59, 999);

                    var emplastOct = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= emplastOct_to && d.employment_date <= emplastOct_from));
                    ViewBag.emplastOct = emplastOct;

                    DateTime emplastNov_to = new DateTime(DateTime.Now.AddYears(-1).Year, 11, 1);
                    DateTime emplastNov_from = new DateTime(DateTime.Now.AddYears(-1).Year, 11, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 11), 23, 59, 59, 999);

                    var emplastNov = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= emplastNov_to && d.employment_date <= emplastNov_from));
                    ViewBag.emplastNov = emplastNov;

                    DateTime emplastDec_to = new DateTime(DateTime.Now.AddYears(-1).Year, 12, 1);
                    DateTime emplastDec_from = new DateTime(DateTime.Now.AddYears(-1).Year, 12, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, 12), 23, 59, 59, 999);

                    var emplastDec = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= emplastDec_to && d.employment_date <= emplastDec_from));
                    ViewBag.emplastDec = emplastDec;

                    //

                    DateTime empthisJan_to = new DateTime(DateTime.Now.Year, 1, 1);
                    DateTime empthisJan_from = new DateTime(DateTime.Now.Year, 1, DateTime.DaysInMonth(DateTime.Now.Year, 1), 23, 59, 59, 999);

                    var empthisJan = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= empthisJan_to && d.employment_date <= empthisJan_from));
                    ViewBag.empthisJan = empthisJan;

                    DateTime empthisFeb_to = new DateTime(DateTime.Now.Year, 2, 1);
                    DateTime empthisFeb_from = new DateTime(DateTime.Now.Year, 2, DateTime.DaysInMonth(DateTime.Now.Year, 2), 23, 59, 59, 999);

                    var empthisFeb = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= empthisFeb_to && d.employment_date <= empthisFeb_from));
                    ViewBag.empthisFeb = empthisFeb;

                    DateTime empthisMar_to = new DateTime(DateTime.Now.Year, 3, 1);
                    DateTime empthisMar_from = new DateTime(DateTime.Now.Year, 3, DateTime.DaysInMonth(DateTime.Now.Year, 3), 23, 59, 59, 999);

                    var empthisMar = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= empthisMar_to && d.employment_date <= empthisMar_from));
                    ViewBag.empthisMar = empthisMar;

                    DateTime empthisApr_to = new DateTime(DateTime.Now.Year, 4, 1);
                    DateTime empthisApr_from = new DateTime(DateTime.Now.Year, 4, DateTime.DaysInMonth(DateTime.Now.Year, 4), 23, 59, 59, 999);

                    var empthisApr = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= empthisApr_to && d.employment_date <= empthisApr_from));
                    ViewBag.empthisApr = empthisApr;

                    DateTime empthisMay_to = new DateTime(DateTime.Now.Year, 5, 1);
                    DateTime empthisMay_from = new DateTime(DateTime.Now.Year, 5, DateTime.DaysInMonth(DateTime.Now.Year, 5), 23, 59, 59, 999);

                    var empthisMay = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= empthisMay_to && d.employment_date <= empthisMay_from));
                    ViewBag.empthisMay = empthisMay;

                    DateTime empthisJun_to = new DateTime(DateTime.Now.Year, 6, 1);
                    DateTime empthisJun_from = new DateTime(DateTime.Now.Year, 6, DateTime.DaysInMonth(DateTime.Now.Year, 6), 23, 59, 59, 999);

                    var empthisJun = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= empthisJun_to && d.employment_date <= empthisJun_from));
                    ViewBag.empthisJun = empthisJun;

                    DateTime empthisJul_to = new DateTime(DateTime.Now.Year, 7, 1);
                    DateTime empthisJul_from = new DateTime(DateTime.Now.Year, 7, DateTime.DaysInMonth(DateTime.Now.Year, 7), 23, 59, 59, 999);

                    var empthisJul = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= empthisJul_to && d.employment_date <= empthisJul_from));
                    ViewBag.empthisJul = empthisJul;

                    DateTime empthisAug_to = new DateTime(DateTime.Now.Year, 8, 1);
                    DateTime empthisAug_from = new DateTime(DateTime.Now.Year, 8, DateTime.DaysInMonth(DateTime.Now.Year, 8), 23, 59, 59, 999);

                    var empthisAug = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= empthisAug_to && d.employment_date <= empthisAug_from));
                    ViewBag.empthisAug = empthisAug;

                    DateTime empthisSep_to = new DateTime(DateTime.Now.Year, 9, 1);
                    DateTime empthisSep_from = new DateTime(DateTime.Now.Year, 9, DateTime.DaysInMonth(DateTime.Now.Year, 9), 23, 59, 59, 999);

                    var empthisSep = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= empthisSep_to && d.employment_date <= empthisSep_from));
                    ViewBag.empthisSep = empthisSep;

                    DateTime empthisOct_to = new DateTime(DateTime.Now.Year, 10, 1);
                    DateTime empthisOct_from = new DateTime(DateTime.Now.Year, 10, DateTime.DaysInMonth(DateTime.Now.Year, 10), 23, 59, 59, 999);

                    var empthisOct = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= empthisOct_to && d.employment_date <= empthisOct_from));
                    ViewBag.empthisOct = empthisOct;

                    DateTime empthisNov_to = new DateTime(DateTime.Now.Year, 11, 1);
                    DateTime empthisNov_from = new DateTime(DateTime.Now.Year, 11, DateTime.DaysInMonth(DateTime.Now.Year, 11), 23, 59, 59, 999);

                    var empthisNov = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= empthisNov_to && d.employment_date <= empthisNov_from));
                    ViewBag.empthisNov = empthisNov;

                    DateTime empthisDec_to = new DateTime(DateTime.Now.Year, 12, 1);
                    DateTime empthisDec_from = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12), 23, 59, 59, 999);

                    var empthisDec = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type && (d.employment_date >= empthisDec_to && d.employment_date <= empthisDec_from));
                    ViewBag.empthisDec = empthisDec;

                    ViewBag.CountEmployees = db.Employees.Count(d => d.deleted == false && d.employment_type == emp_type);
                    ViewBag.CountEmployeesActive = db.Employees.Count(d => d.deleted == false && d.is_active == true && d.employment_type == emp_type);
                    ViewBag.CountEmployeesPassive = db.Employees.Count(d => d.deleted == false && d.is_active == false && d.employment_type == emp_type);

                    ViewBag.LatestEmployee = db.Employees.Where(i => i.deleted == false && i.is_active == true && i.employment_type == emp_type).OrderByDescending(d => d.employment_date).ToList();

                    ViewBag.male = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == emp_type && i.gender == "Male");
                    ViewBag.female = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == emp_type && i.gender == "Female");
                    ViewBag.single = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == emp_type && i.civil_status == "Single");
                    ViewBag.married = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == emp_type && i.civil_status == "Married");
                    ViewBag.substitute = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == emp_type && i.appointment_status == "Substitute");
                    ViewBag.parttimeAS = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == emp_type && i.appointment_status == "Part-time");
                    ViewBag.probationary = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == emp_type && i.appointment_status == "Probationary");
                    ViewBag.permanent = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == emp_type && i.appointment_status == "Permanent");

                    ViewBag.postGrad = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == emp_type && i.educational_attainment == "Postgraduate");
                    ViewBag.Grad = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == emp_type && i.educational_attainment == "Graduate");
                    ViewBag.underGrad = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == emp_type && i.educational_attainment == "Undergraduate");

                    ViewBag.parttimeWS = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == emp_type && i.working_status == "Part-time");
                    ViewBag.fulltime = db.Employees.Count(i => i.deleted == false && i.is_active == true && i.employment_type == emp_type && i.working_status == "Full-time");
                }

                else if (Session["User_role"].ToString() == "Employee")
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

        public ActionResult About()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.ActiveHomeAbout = "class = active";
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        public FileContentResult UserPicture(int id)
        {

            byte[] byteArray = db.Users.Find(id).userimage;

            string default_userImage_path = Server.MapPath("~/Content/dist/img/defaultuserimage.png");
            byte[] default_userImage = System.IO.File.ReadAllBytes(default_userImage_path);

            if (byteArray != null)
            {
                return new FileContentResult(byteArray, "image/jpeg");
            }

            else
            {
                return new FileContentResult(default_userImage, "image/jpeg");
            }
        }

        public FileContentResult EmployeePicture(int id)
        {

            byte[] byteArray = db.Employees.Find(id).employee_image;

            string default_maleImage_path = Server.MapPath("~/Content/dist/img/defaultmaleimage.jpg");
            byte[] default_maleImage = System.IO.File.ReadAllBytes(default_maleImage_path);

            string default_femaleImage_path = Server.MapPath("~/Content/dist/img/defaultfemaleimage.jpg");
            byte[] default_femaleImage = System.IO.File.ReadAllBytes(default_femaleImage_path);

            if (byteArray != null)
            {
                return new FileContentResult(byteArray, "image/jpeg");
            }

            else
            {
                string gender = db.Employees.Find(id).gender;
                if (gender == "Male")
                {
                    return new FileContentResult(default_maleImage, "image/jpeg");
                }

                else
                {
                    return new FileContentResult(default_femaleImage, "image/jpeg");
                }
            }
        }

        public FileContentResult ApplicantPicture(int id)
        {

            byte[] byteArray = db.Applicants.Find(id).applicant_image;

            string default_maleImage_path = Server.MapPath("~/Content/dist/img/defaultmaleimage.jpg");
            byte[] default_maleImage = System.IO.File.ReadAllBytes(default_maleImage_path);

            string default_femaleImage_path = Server.MapPath("~/Content/dist/img/defaultfemaleimage.jpg");
            byte[] default_femaleImage = System.IO.File.ReadAllBytes(default_femaleImage_path);

            if (byteArray != null)
            {
                return new FileContentResult(byteArray, "image/jpeg");
            }

            else
            {
                string gender = db.Applicants.Find(id).gender;
                if (gender == "Male")
                {
                    return new FileContentResult(default_maleImage, "image/jpeg");
                }

                else
                {
                    return new FileContentResult(default_femaleImage, "image/jpeg");
                }
            }
        }

    }
}
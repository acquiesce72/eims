using EmployeeInformationManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeInformationManagementSystem.Controllers
{
    public class ValidationController : Controller
    {
        // GET: Validation
        private MyDbContext db = new MyDbContext();

        [HttpGet]
        public JsonResult IsUsernameExist(string username)
        {
            return Json(!db.Users.Any(user => user.username == username), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult IsEmployeeNumberExist(string employee_number)
        {
            return Json(!db.Employees.Any(employee => employee.employee_number == employee_number), JsonRequestBehavior.AllowGet);
        }

    }
}
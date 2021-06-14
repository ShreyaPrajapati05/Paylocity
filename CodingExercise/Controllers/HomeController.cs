using CodingExercise.DataAccess.Data;
using CodingExercise.Services;
using System.Web.Mvc;
using System.Collections.Generic;
using CodingExercise.Model;

namespace CodingExercise.Controllers
{
    // Home controller
    public class HomeController : Controller
    {
        #region private variables
        private EmployeeService employeeService;
        #endregion

        #region public methods
        // constructor
        public HomeController()
        {
            employeeService = new EmployeeService();
            ViewBag.title = "Employee Page";
        }

        /// <summary>
        /// Employee Action method which return Employee view
        /// </summary>
        /// <returns></returns>
        public ActionResult Employee()
        {
            return View();
        }

        /// <summary>
        /// Get Employee deduction calculations
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns>EmployeeModel objects</returns>
        [HttpPost]
        public ActionResult GetEmployee(EmployeeModel employeeModel)
        {
            Employee emp = employeeService.GetEmployeeByName(employeeModel.Name);
            if(emp == null)
            {
                return Json(new { });
            }
            employeeModel.DeductableSalary=(decimal)employeeService.CalculateDeducatableSalary(employeeModel);
            employeeService.GetDetails((double)employeeModel.DeductableSalary,employeeModel);
            return Json(employeeModel);
        }

        /// <summary>
        /// Create Employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateEmployee(EmployeeModel employeeModel)
        {
            Employee emp = employeeService.GetEmployeeByName(employeeModel.Name);
           
            if (emp != null)
                return Json(new { });

            Employee employee = new Employee
            {
                Name = employeeModel.Name,
                Email = employeeModel.Email,
                DeductableSalary = (decimal)employeeModel.DeductableSalary,
                Phone = employeeModel.Phone,
            };
           employeeService.Save(employee);
            return Json(employeeModel);
        }

        /// <summary>
        /// to get all Employees details
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEmployees()
        {
            List<Employee> employees = employeeService.GetAllEmployee();
            return Json(employees, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
using CodingExercise.Controllers;
using CodingExercise.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CodingExercise
{
    [TestClass]
    public class ControllerTest
    {
        readonly HomeController controller = new HomeController();
        private Random _random = new Random();
        [TestMethod]
        public void Index()
        {
            ViewResult result = controller.Employee() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Employee Page", result.ViewBag.Title);
        }
        [TestMethod]
        public void AddEmployee()
        {
            EmployeeModel employeeModel = new EmployeeModel() {
                Name = "Test" + _random.Next(100).ToString(),
                Email = "Test" + _random.Next(100).ToString() + "@gmail.com",
                Phone = "5106050935"
        };
            var result = (JsonResult)controller.CreateEmployee(employeeModel);
            Assert.IsNotNull(result);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            EmployeeModel savedEmployee = serializer.Deserialize<EmployeeModel>(serializer.Serialize(result.Data));
            Assert.AreEqual(savedEmployee.Name,employeeModel.Name);
            Assert.AreEqual(savedEmployee.Email, employeeModel.Email);

        }
        [TestMethod]
        public void GetEmployee()
        {
            EmployeeModel employeeModel = new EmployeeModel()
            {
                Name = "Shreya"
            };
            var employee = controller.GetEmployee(employeeModel);
            Assert.IsNotNull(employee);
        }


    }
}
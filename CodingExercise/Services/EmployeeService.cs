using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingExercise.DataAccess;
using CodingExercise.DataAccess.Data;
using CodingExercise.Model;

namespace CodingExercise.Services
{
    public class EmployeeService : BaseClass
    {
        /// <summary>
        /// get all sales data
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployee()
        {
            return _entities.Employees.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public Employee GetEmployeeByName(string employeeName)
        {
            return _entities.Employees.Where(s => s.Name == employeeName).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        public void Save(Employee employee)
        {
            _entities.Employees.Add(employee);
            _entities.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public double CalculateDeducatableSalary(EmployeeModel employee)
        {
            double amount = 0;
            if (employee.Spouse)
                amount += ConstantValue.BenefitsAmountforSpouse;
            if (employee.NumberOfChild > 0)
                amount += employee.NumberOfChild * ConstantValue.BenefitsAmountforChild;
            if (employee.Name.StartsWith("a") || employee.Name.StartsWith("A"))
                amount -= amount / 10;
            return amount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deductableSalary"></param>
        /// <param name="employeeModel"></param>
        public void GetDetails(double deductableSalary, EmployeeModel employeeModel)
        {
            employeeModel.TotalAnualSalary = ConstantValue.SalaryPerPayCheck * 26 - deductableSalary;
            employeeModel.TotalPerPayCheckSalary = employeeModel.TotalAnualSalary / 12;
        }
    }
}

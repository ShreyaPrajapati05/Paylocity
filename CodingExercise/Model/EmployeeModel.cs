using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingExercise.Model
{
    //Employee Model
    public class EmployeeModel : IEmployeeModel
    {
        /// <summary>
        /// Employee ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Employee Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Employee Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Employee Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Deductable Salary
        /// </summary>
        public decimal DeductableSalary { get; set; }

        /// <summary>
        /// Total Annual Salary
        /// </summary>
        public double TotalAnualSalary { set; get; }

        /// <summary>
        /// TotalPerPayCheckSalary
        /// </summary>
        public double TotalPerPayCheckSalary { get; set; }

        /// <summary>
        /// Number of child
        /// </summary>
        public int NumberOfChild { get; set; }
        public bool Spouse { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.Model
{
    public interface IEmployeeModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        decimal DeductableSalary { get; set; }
        double TotalAnualSalary { set; get; }
        double TotalPerPayCheckSalary { get; set; }
        int NumberOfChild { get; set; }
        bool Spouse { get; set; }
    }
}

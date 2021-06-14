using CodingExercise.DataAccess.Data;

namespace CodingExercise.DataAccess
{
    public class BaseClass
    {
        public EmployeeEntities _entities;
        public BaseClass()
        {
            _entities = new EmployeeEntities();
        }
    }

}

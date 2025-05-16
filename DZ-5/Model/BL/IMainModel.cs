using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL
{
    public class EmployeeEventArgs : EventArgs
    {
        public Entities Employee { get; set; }
        public EmployeeEventArgs(Entities employee)
        {
            Employee = employee;
        }
    }

    public interface IMainModel
    {
        event EventHandler<EmployeeEventArgs> EventAddEmployee;
        event EventHandler<EmployeeEventArgs> EventDelEmployee;

        void AddEmployee(Entities employee);
        void DeleteEmployee(Entities employee); // прототипы - их нужно будет переопределить в наследниках
        IList<Entities> GetEmployees();
    }
}

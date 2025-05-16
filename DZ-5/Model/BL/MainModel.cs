using Model.DAL;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL
{
    public class MainModel : IMainModel
    {
        public MainModel(IRepository<Entities> repository)
        {
            _repository = repository;
        }

        public event EventHandler<EmployeeEventArgs> EventAddEmployee; //= delegate { };
        public event EventHandler<EmployeeEventArgs> EventDelEmployee; //= delegate { };

        public void AddEmployee(Entities employee)
        {
            _repository.Add(employee);
            EventAddEmployee?.Invoke(this, new EmployeeEventArgs(employee));
        }

        public void DeleteEmployee(Entities employee)
        {
            _repository.Delete(employee);
            EventDelEmployee?.Invoke(this, new EmployeeEventArgs(employee));
        }

        public IList<Entities> GetEmployees()
        {
            return _repository.GetAll().ToList();
        }

        public IRepository<Entities> _repository { get; set; }
    }
}

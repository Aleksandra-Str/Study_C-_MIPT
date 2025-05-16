using Model.BL;
using Model.Domain;

namespace Shared
{
    public interface IMainView
    {
        event EventHandler<EmployeeEventArgs> EventAddEmployee;
        event EventHandler<EmployeeEventArgs> EventDelEmployee;
        event EventHandler EventLoadView;

        void Add(Entities employee);
        void Run();
        void Del(Entities employee);
        void Loud(IList<Entities> employees);
    }
}

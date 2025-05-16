using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public interface IDomainObject
    {
        int Id { get; set; }
    }

    public class Entities : IDomainObject
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    // Класс, представляющий группу
    public class Group : IDomainObject
    {
        public int Id { get; set; }
        public string Name { get; set; } // Название группы
        public List<Subject> Subjects { get; set; } = new List<Subject>(); // Список предметов, которые изучает группа
        public List<Teacher> Teachers { get; set; } = new List<Teacher>(); // Список преподавателей группы
    }

    // Класс, представляющий преподавателя
    public class Teacher : IDomainObject
    {
        public int Id { get; set; }
        public string Name { get; set; } // Имя преподавателя
        public List<Subject> Subjects { get; set; } = new List<Subject>(); // Список предметов, которые преподаёт
        public List<Group> Groups { get; set; } = new List<Group>(); // Список групп, у которых преподаёт
    }

    // Класс, представляющий предмет
    public class Subject : IDomainObject
    {
        public int Id { get; set; }
        public string Name { get; set; } // Название предмета
        public List<Teacher> Teachers { get; set; } = new List<Teacher>(); // Список преподавателей, ведущих предмет
        public List<Group> Groups { get; set; } = new List<Group>(); // Список групп, изучающих предмет
    }
}

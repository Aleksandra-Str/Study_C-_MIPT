using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UniversitySchedule.Models
{
    // Класс, представляющий преподавателя
    public class Teacher
    {
        public string Name { get; set; } // Имя преподавателя
        public List<Subject> Subjects { get; set; } = new List<Subject>(); // Список предметов, которые преподаёт
        public List<Group> Groups { get; set; } = new List<Group>(); // Список групп, у которых преподаёт
    }
}

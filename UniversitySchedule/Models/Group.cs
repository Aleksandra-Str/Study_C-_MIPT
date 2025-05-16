using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UniversitySchedule.Models
{
    // Класс, представляющий группу
    public class Group
    {
        public string Name { get; set; } // Название группы
        public List<Subject> Subjects { get; set; } = new List<Subject>(); // Список предметов, которые изучает группа
        public List<Teacher> Teachers { get; set; } = new List<Teacher>(); // Список преподавателей группы
    }
}

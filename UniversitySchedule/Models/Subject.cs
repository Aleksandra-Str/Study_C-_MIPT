using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UniversitySchedule.Models
{
    // Класс, представляющий предмет
    public class Subject
    {
        public string Name { get; set; } // Название предмета
        public List<Teacher> Teachers { get; set; } = new List<Teacher>(); // Список преподавателей, ведущих предмет
        // public Teacher Teacher { get; set; } // Преподаватель, ведущий предмет
        public List<Group> Groups { get; set; } = new List<Group>(); // Список групп, изучающих предмет
    }
}

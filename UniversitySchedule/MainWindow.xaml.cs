using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UniversitySchedule.Models;
using UniversitySchedule.Repositories;


namespace UniversitySchedule
{
    // Главное окно приложения
    public partial class MainWindow : Window
    {

        private readonly MemoryRepository _repository = new MemoryRepository(); // Репозиторий данных

        public MainWindow()
        {
            InitializeComponent(); // Инициализация компонентов интерфейса
            LoadData(); // Загрузка данных в интерфейс
        }

        private void ClearSelections()
        {
            // Преподаватель
            TeacherListBox.SelectedItem = null;
            TeacherSubjectsListBox.ItemsSource = null;
            TeacherGroupsListBox.ItemsSource = null;

            // Группа
            GroupListBox.SelectedItem = null;
            GroupSubjectsListBox.ItemsSource = null;
            GroupTeachersListBox.ItemsSource = null;

            // Предмет
            SubjectListBox.SelectedItem = null;
            SubjectTeacherListBox.ItemsSource = null;
            SubjectGroupsListBox.ItemsSource = null;
        }
        private void LoadData()
        {
            // Заполнение списков данными
            TeacherListBox.ItemsSource = _repository.Teachers.Select(t => t.Name);
            GroupListBox.ItemsSource = _repository.Groups.Select(g => g.Name);
            SubjectListBox.ItemsSource = _repository.Subjects.Select(s => s.Name);
        }

        private void TeacherListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обработка выбора преподавателя
            var teacherName = TeacherListBox.SelectedItem as string;
            if (teacherName == null) return;

            var teacher = _repository.Teachers.FirstOrDefault(t => t.Name == teacherName);
            if (teacher != null)
            {
                TeacherSubjectsListBox.ItemsSource = teacher.Subjects.Select(s => s.Name); // Отображение предметов преподавателя
                TeacherGroupsListBox.ItemsSource = teacher.Groups.Select(g => g.Name); // Отображение групп преподавателя
            }
        }

        private void GroupListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обработка выбора группы
            var groupName = GroupListBox.SelectedItem as string;
            if (groupName == null) return;

            var group = _repository.Groups.FirstOrDefault(g => g.Name == groupName);
            if (group != null)
            {
                GroupSubjectsListBox.ItemsSource = group.Subjects.Select(s => s.Name); // Отображение предметов группы
                GroupTeachersListBox.ItemsSource = group.Teachers.Select(t => t.Name); // Отображение преподавателей группы
            }
        }

        private void SubjectListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обработка выбора предмета
            var subjectName = SubjectListBox.SelectedItem as string;
            if (subjectName == null) return;

            var subject = _repository.Subjects.FirstOrDefault(s => s.Name == subjectName);
            if (subject != null)
            {
                SubjectTeacherListBox.ItemsSource = subject.Teachers.Select(t => t.Name); // Отображение преподавателей предмета
                SubjectGroupsListBox.ItemsSource = subject.Groups.Select(g => g.Name); // Отображение групп предмета
            }
        }

        private void AddAndLinkTeacherGroupSubject_Click(object sender, RoutedEventArgs e)
        {
            var teacherName = NewLinkedTeacherTextBox.Text.Trim();
            var groupName = NewLinkedGroupTextBox.Text.Trim();
            var subjectName = NewLinkedSubjectTextBox.Text.Trim();

            if (string.IsNullOrEmpty(teacherName) || string.IsNullOrEmpty(groupName) || string.IsNullOrEmpty(subjectName))
            {
                MessageBox.Show("Пожалуйста, заполните все три поля.");
                return;
            }

            // Получаем или создаём преподавателя
            var teacher = _repository.Teachers.FirstOrDefault(t => t.Name == teacherName);
            if (teacher == null)
            {
                teacher = new Teacher { Name = teacherName };
                _repository.Teachers.Add(teacher);
            }

            // Получаем или создаём группу
            var group = _repository.Groups.FirstOrDefault(g => g.Name == groupName);
            if (group == null)
            {
                group = new Group { Name = groupName };
                _repository.Groups.Add(group);
            }

            // Получаем или создаём предмет
            var subject = _repository.Subjects.FirstOrDefault(s => s.Name == subjectName);
            if (subject == null)
            {
                subject = new Subject { Name = subjectName };
                _repository.Subjects.Add(subject);
            }

            // Связи (добавляем только если их ещё нет)
            if (!teacher.Groups.Contains(group))
                teacher.Groups.Add(group);
            if (!teacher.Subjects.Contains(subject))
                teacher.Subjects.Add(subject);

            if (!group.Teachers.Contains(teacher))
                group.Teachers.Add(teacher);
            if (!group.Subjects.Contains(subject))
                group.Subjects.Add(subject);

            if (!subject.Teachers.Contains(teacher))
                subject.Teachers.Add(teacher);
            if (!subject.Groups.Contains(group))
                subject.Groups.Add(group);

            LoadData();
        }

        private void RemoveSelectedTeacher_Click(object sender, RoutedEventArgs e)
        {
            var teacherName = TeacherListBox.SelectedItem as string;
            if (teacherName == null) return;

            var teacher = _repository.Teachers.FirstOrDefault(t => t.Name == teacherName);
            if (teacher != null)
            {
                foreach (var group in teacher.Groups)
                    group.Teachers.Remove(teacher);
                foreach (var subject in teacher.Subjects)
                    subject.Teachers.Remove(teacher);

                _repository.Teachers.Remove(teacher);
                LoadData();

                ClearSelections();
            }
        }

        private void RemoveSelectedGroup_Click(object sender, RoutedEventArgs e)
        {
            var groupName = GroupListBox.SelectedItem as string;
            if (groupName == null) return;

            var group = _repository.Groups.FirstOrDefault(g => g.Name == groupName);
            if (group != null)
            {
                foreach (var teacher in group.Teachers)
                    teacher.Groups.Remove(group);
                foreach (var subject in group.Subjects)
                    subject.Groups.Remove(group);

                _repository.Groups.Remove(group);
                LoadData();

                ClearSelections();
            }
        }

        private void RemoveSelectedSubject_Click(object sender, RoutedEventArgs e)
        {
            var subjectName = SubjectListBox.SelectedItem as string;
            if (subjectName == null) return;

            var subject = _repository.Subjects.FirstOrDefault(s => s.Name == subjectName);
            if (subject != null)
            {
                foreach (var teacher in subject.Teachers)
                    teacher.Subjects.Remove(subject);
                foreach (var group in subject.Groups)
                    group.Subjects.Remove(subject);

                _repository.Subjects.Remove(subject);
                LoadData();

                ClearSelections();
            }
        }


        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _repository.Save();
        }
        private void RemoveSubjectFromTeacher_Click(object sender, RoutedEventArgs e)
        {
            var teacherName = TeacherListBox.SelectedItem as string;
            var subjectName = TeacherSubjectsListBox.SelectedItem as string;

            if (teacherName == null || subjectName == null) return;

            var teacher = _repository.Teachers.FirstOrDefault(t => t.Name == teacherName);
            var subject = _repository.Subjects.FirstOrDefault(s => s.Name == subjectName);

            if (teacher != null && subject != null)
            {
                teacher.Subjects.Remove(subject);
                subject.Teachers.Remove(teacher);
                LoadData();
                TeacherSubjectsListBox.SelectedItem = null;

            }
            ClearSelections();
        }
        //Удалить группу у преподавателя:
        private void RemoveGroupFromTeacher_Click(object sender, RoutedEventArgs e)
        {
            var teacherName = TeacherListBox.SelectedItem as string;
            var groupName = TeacherGroupsListBox.SelectedItem as string;

            if (teacherName == null || groupName == null) return;

            var teacher = _repository.Teachers.FirstOrDefault(t => t.Name == teacherName);
            var group = _repository.Groups.FirstOrDefault(g => g.Name == groupName);

            if (teacher != null && group != null)
            {
                teacher.Groups.Remove(group);
                group.Teachers.Remove(teacher);
                LoadData();
                TeacherGroupsListBox.SelectedItem = null;
            }
            ClearSelections();
        }
        //Удалить предмет у группы:
        private void RemoveSubjectFromGroup_Click(object sender, RoutedEventArgs e)
        {
            var groupName = GroupListBox.SelectedItem as string;
            var subjectName = GroupSubjectsListBox.SelectedItem as string;

            if (groupName == null || subjectName == null) return;

            var group = _repository.Groups.FirstOrDefault(g => g.Name == groupName);
            var subject = _repository.Subjects.FirstOrDefault(s => s.Name == subjectName);

            if (group != null && subject != null)
            {
                group.Subjects.Remove(subject);
                subject.Groups.Remove(group);
                LoadData();
                GroupSubjectsListBox.SelectedItem = null;
            }
            ClearSelections();
        }
        //Удалить преподавателя у группы:
        private void RemoveTeacherFromGroup_Click(object sender, RoutedEventArgs e)
        {
            var groupName = GroupListBox.SelectedItem as string;
            var teacherName = GroupTeachersListBox.SelectedItem as string;

            if (groupName == null || teacherName == null) return;

            var group = _repository.Groups.FirstOrDefault(g => g.Name == groupName);
            var teacher = _repository.Teachers.FirstOrDefault(t => t.Name == teacherName);

            if (group != null && teacher != null)
            {
                group.Teachers.Remove(teacher);
                teacher.Groups.Remove(group);
                LoadData();
                GroupTeachersListBox.SelectedItem = null;
            }
                ClearSelections();
        }
        //Удалить группу у предмета:
        private void RemoveGroupFromSubject_Click(object sender, RoutedEventArgs e)
        {
            var subjectName = SubjectListBox.SelectedItem as string;
            var groupName = SubjectGroupsListBox.SelectedItem as string;

            if (subjectName == null || groupName == null) return;

            var subject = _repository.Subjects.FirstOrDefault(s => s.Name == subjectName);
            var group = _repository.Groups.FirstOrDefault(g => g.Name == groupName);

            if (subject != null && group != null)
            {
                subject.Groups.Remove(group);
                group.Subjects.Remove(subject);
                LoadData();
                SubjectGroupsListBox.SelectedItem = null;
            }
            ClearSelections();
        }
        //Удалить преподавателя у предмета:
        private void RemoveTeacherFromSubject_Click(object sender, RoutedEventArgs e)
        {
            var subjectName = SubjectListBox.SelectedItem as string;
            var teacherName = SubjectTeacherListBox.SelectedItem as string;

            if (subjectName == null || teacherName == null) return;

            var subject = _repository.Subjects.FirstOrDefault(s => s.Name == subjectName);
            var teacher = _repository.Teachers.FirstOrDefault(t => t.Name == teacherName);

            if (subject != null && teacher != null)
            {
                subject.Teachers.Remove(teacher);
                teacher.Subjects.Remove(subject);
                LoadData();
                SubjectTeacherListBox.SelectedItem = null;
            }
            ClearSelections();
        }
        



    }
}

//namespace UniversitySchedule
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        private readonly MemoryRepository _repository = new MemoryRepository();

//        public MainWindow()
//        {
//            InitializeComponent();
//            LoadData();
//        }

//        private void LoadData()
//        {
//            // Загрузка данных
//        }
//    }
//}

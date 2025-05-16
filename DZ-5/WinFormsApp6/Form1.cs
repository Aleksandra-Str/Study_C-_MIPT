using Model.BL;
using Model.Domain;
using Shared;

namespace WinFormsApp6
{
    public partial class Form1 : Form, IMainView
    {
        public void Run()
        {
            Application.Run(this);
        }
        public event EventHandler<EmployeeEventArgs> EventAddEmployee;
        public event EventHandler<EmployeeEventArgs> EventDelEmployee;
        public event EventHandler EventLoadView;

        public void Add(Entities employee)
        {
            listBox1.Items.Add(employee);
        }

        public void Del(Entities employee)
        {
            listBox1.Items.Remove(employee);
        }

        public void Loud(IList<Entities> employees)
        {
            foreach (Entities employee in employees)
            {
                listBox1.Items.Add(employee);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventAddEmployee?.Invoke(this,
               new EmployeeEventArgs(
                                       new Entities
                                       {
                                           Name = textBox1.Text,
                                           Age = (int)numericUpDown1.Value
                                       }
                                   )
               );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EventDelEmployee?.Invoke(this,
              new EmployeeEventArgs(listBox1.SelectedItem as Entities));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

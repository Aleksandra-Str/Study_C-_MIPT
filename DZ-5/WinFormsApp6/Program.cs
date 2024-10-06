using Model.BL;
using Model.DAL;
using Model.Domain;
using Ninject;
using Ninject.Modules;
using Presenter;
using Shared;
using System.Data.Entity;


namespace WinFormsApp6
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            string dbFilePath = "database.db";// database.db - ���� � ���� ������

            ApplicationConfiguration.Initialize();
            string connectionString = "Data Source=database.db";// ����������� � ���� ������, connectionString - � ��� �������� �����������
            DatabaseInitializer.Initializer(connectionString);// �������� ���� ������
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());// ������� ����
            MainPresenter presenter = ninjectKernel.Get<MainPresenter>();
                
        
        }
    }

    class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Employee>>().ToMethod(ctx => // ��������� dapperrepozitory � irepozitory � ����������� �� �������
            {
                string connectionString = "Data Source=database.db"; 
                return new DapperRepozitory<Employee>(connectionString);// ���������� ����� ������ ������ DapperRepozitory, ������� ����� �������� � ����� ������ Employee, connectionString ���������� � �����������
            }).InSingletonScope();// ��������� ���� ���

            Bind<IMainView>().To<Form1>().InSingletonScope();// ������ IMainView ������������ ��������� Form1 (����) (����� ������������ class SimpleConfigModule)
            Bind<IMainModel>().To<MainModel>().InSingletonScope();
        }
    }

  

}
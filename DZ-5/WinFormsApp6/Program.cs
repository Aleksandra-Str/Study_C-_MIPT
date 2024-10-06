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
            string dbFilePath = "database.db";// database.db - путь к базе данных

            ApplicationConfiguration.Initialize();
            string connectionString = "Data Source=database.db";// подключение к базе данных, connectionString - в ней хранится подключение
            DatabaseInitializer.Initializer(connectionString);// создание базы данных
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());// создаем ядро
            MainPresenter presenter = ninjectKernel.Get<MainPresenter>();
                
        
        }
    }

    class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Employee>>().ToMethod(ctx => // связывает dapperrepozitory и irepozitory и подписывает на события
            {
                string connectionString = "Data Source=database.db"; 
                return new DapperRepozitory<Employee>(connectionString);// возвращаем новый объект класса DapperRepozitory, который будет работать с типом данных Employee, connectionString передается в конструктор
            }).InSingletonScope();// подлючаем один раз

            Bind<IMainView>().To<Form1>().InSingletonScope();// вместо IMainView отправляется наследник Form1 (мечи) (часть конфигурации class SimpleConfigModule)
            Bind<IMainModel>().To<MainModel>().InSingletonScope();
        }
    }

  

}
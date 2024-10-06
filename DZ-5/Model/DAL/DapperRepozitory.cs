using Dapper;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class DapperRepozitory<T> : IRepository<T> where T : IDomainObject, new()
    {

        private readonly string _connectionString;

        public DapperRepozitory(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new SQLiteConnection(_connectionString); // подключение к базе данных второй раз

        public IEnumerable<T> GetAll()
        {
            using IDbConnection dbConnection = Connection; // using - создать поток подключения к базе данных
            return dbConnection.Query<T>("SELECT * FROM " + typeof(T).Name); //typeof(T).Name - T - тип данных класса, Query - метод класса IDbConnection для получения данных из баззы данных
        }

        public void Add(T entity) //принимает одного работника
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Execute($"INSERT INTO {typeof(T).Name} (Name, Age) VALUES (@Name, @Age)", entity); //$ - позволяет внутри строки передавать переменные
                                                                                                     
        }

        public void Delete(T entity)
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Execute($"DELETE FROM {typeof(T).Name} WHERE Id = @Id", entity);
        }


        public void Update(IList<T> values)
        {
            using IDbConnection dbConnection = Connection;
            foreach (var value in values)
            {
                dbConnection.Execute($"UPDATE {typeof(T).Name} SET Name = @Name, Age = @Age WHERE Id = @Id", value);
            }
        }

        
        public void Save()
        {

        }
    }
}

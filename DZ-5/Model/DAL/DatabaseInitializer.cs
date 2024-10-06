using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class DatabaseInitializer
    {
        public static void Initializer (string connectionString)
        {
            using (var connection = new SQLiteConnection(connectionString)) //
            {
                connection.Open(); // создает файл с базой данных или подключается к существующей

                // создаем таблицу если она не существует
                var createTable = @" 
                       CREATE TABLE IF NOT EXISTS Employee (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT, -- Поле Id, автоматически увеличиваемое, является первичным ключом.
                    Name TEXT, -- Поле Name для хранения текста.
                    Age INTEGER -- Поле Age для хранения целого числа.
                  )";

                using (var command = new SQLiteCommand(createTable, connection)) //отправляем команду на создание таблицы в SQLite
                { 
                 command.ExecuteNonQuery();
                
                }

            }
        }
    }
}

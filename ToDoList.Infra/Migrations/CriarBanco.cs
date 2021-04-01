using System;
using System.Data.SQLite;
using System.IO;

using ToDoList.Domain.Interfaces;

namespace ToDoList.Infra.Migrations
{
    public class CriarBanco : IMigration
    {
        public void Up()
        {
            try
            {
                if (!File.Exists("db_todo.db"))
                    SQLiteConnection.CreateFile("db_todo.db");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

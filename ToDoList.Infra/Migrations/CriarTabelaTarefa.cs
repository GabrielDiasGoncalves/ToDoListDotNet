using System;
using System.Data.SQLite;

using ToDoList.Domain.Interfaces;

namespace ToDoList.Infra.Migrations
{
    public class CriarTabelaTarefa : IMigration
    {
        private string _connectionString;

        public CriarTabelaTarefa(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Up()
        {
            try
            {
                var comandoTexto = "CREATE TABLE IF NOT EXISTS tb_tarefa (" +
                        "ID int, Nome Varchar(50), Descricao Varchar(100), DataInicio Varchar(25), DataTermino Varchar(25))";
                using (var conexao = new SQLiteConnection(_connectionString))
                using (var comando = new SQLiteCommand(comandoTexto, conexao))
                {
                    conexao.Open();
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

using Dapper;

using ToDoList.Domain.Models;

namespace ToDoList.Infra.Repositories
{
    public class TarefaRepository : RepositoryBase
    {
        public TarefaRepository(string connectionString) : base (connectionString) { }

        public void AdicionarTarefa(Tarefa tarefa)
        {
            try
            {
                using (var conexao = new SQLiteConnection(ConnectionString))
                {
                    conexao.Open();

                    var query = "INSERT INTO tb_tarefa (Nome, Descricao, DataInicio, DataTermino) VALUES (@Nome, @Descricao, @DataInicio, @DataTermino)";

                    var resultado = conexao.Execute(query, tarefa);
                    Console.WriteLine(resultado);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Tarefa> RecuperarTodos()
        {
            try
            {
                using (var conexao = new SQLiteConnection(ConnectionString))
                {
                    conexao.Open();

                    var query = "SELECT * FROM tb_tarefa;";

                    var resultado = conexao.Query<Tarefa>(query).AsList();
                    return resultado;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Tarefa>();
            }
        }
    }
}
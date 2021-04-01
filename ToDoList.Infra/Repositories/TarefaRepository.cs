using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;
using ToDoList.Domain.Models;

namespace ToDoList.Infra.Repositories
{
    public class TarefaRepository : RepositoryBase
    {
        public TarefaRepository(string connectionString) : base (connectionString) { }

        public async Task AdicionarTarefaAsync(Tarefa tarefa)
        {
            try
            {
                using(var conexao = new SQLiteConnection(ConnectionString))
                {
                    conexao.Open();

                    var query = "INSERT INTO tb_tarefa (Nome, Descricao, DataInicio, DataTermino) VALUES (@Nome, @Descricao, @DataInicio, @DataTermino)";

                    var resultado = await conexao.ExecuteAsync(query, tarefa);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
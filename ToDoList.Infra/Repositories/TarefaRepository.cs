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
    public class TarefaRepository
    {


        public void AdicionarTarefa(Tarefa tarefa)
        {
            try
            {
                using(var conexao = new SQLiteConnection("string connection"))
                {
                    conexao.Open();

                    var query = "INSERT INTO tb_tarefa (Nome, Descricao, DataInicio, DataTermino) VALUES (@Nome, @Descricao, @DataInicio, @DataTermino)";

                    var resultado = conexao.Execute(query, tarefa);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
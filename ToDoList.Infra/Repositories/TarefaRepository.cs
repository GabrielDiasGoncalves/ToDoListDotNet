using System;
using System.Collections.Generic;
using System.Data.SQLite;

using Dapper;

using ToDoList.Domain.Models;

namespace ToDoList.Infra.Repositories
{
    public class TarefaRepository : RepositoryBase
    {
        public TarefaRepository(string connectionString) : base (connectionString) { }

        public void Adicionar(Tarefa tarefa)
        {
            try
            {
                using (var conexao = new SQLiteConnection(ConnectionString))
                {
                    conexao.Open();

                    var query = "INSERT INTO tb_tarefa (Nome, Descricao, DataInicio, DataTermino) VALUES (@Nome, @Descricao, @DataInicio, @DataTermino)";

                    var resultado = conexao.Execute(query, new
                    {
                        Nome = tarefa.Nome,
                        Descricao = tarefa.Descricao,
                        DataInicio = tarefa.DataInicio.ToString("yyyy-MM-dd HH:mm:ss"),
                        DataTermino = tarefa.DataTermino.ToString("yyyy-MM-dd HH:mm:ss")
                    });

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

        public void Atualizar(Tarefa tarefa)
        {
            try
            {
                using (var conexao = new SQLiteConnection(ConnectionString))
                {
                    conexao.Open();

                    var query = "UPDATE tb_tarefa SET Nome = @Nome, Descricao = @Descricao, DataInicio = @DataInicio, DataTermino = @DataTermino WHERE ID = @ID;";

                    var resultado = conexao.Execute(query, new
                    {
                        ID = tarefa.ID,
                        Nome = tarefa.Nome,
                        Descricao = tarefa.Descricao,
                        DataInicio = tarefa.DataInicio.ToString("yyyy-MM-dd HH:mm:ss"),
                        DataTermino = tarefa.DataTermino.ToString("yyyy-MM-dd HH:mm:ss")
                    });

                    Console.WriteLine(resultado);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
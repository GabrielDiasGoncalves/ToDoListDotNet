using System.Collections.Generic;

using ToDoList.Domain.Interfaces;
using ToDoList.Infra.Migrations;

namespace ToDoList.UI.Factory
{
    public class MigrationFactory
    {
        public ICollection<IMigration> Criar(string connectionString)
        {
            return new List<IMigration>()
            {
                new CriarBanco(),
                new CriarTabelaTarefa(connectionString)
            };
        }
    }
}

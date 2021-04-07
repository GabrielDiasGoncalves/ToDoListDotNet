using System.Collections.Generic;

using ToDoList.Domain.Extensions;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Domain.Services
{
    public class MigrationService
    {
        public void ExecutarMigrations(ICollection<IMigration> migrations)
        {
            migrations.ForEach(x => x.Up());
        }
    }
}

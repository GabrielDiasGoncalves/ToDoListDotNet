using System.Collections.Generic;

using ToDoList.Domain.Interfaces;

namespace ToDoList.Domain.Services
{
    public class MigrationService
    {
        public void ExecutarMigrations(ICollection<IMigration> migrations)
        {
            foreach (var item in migrations)
                item.Up();
        }
    }
}

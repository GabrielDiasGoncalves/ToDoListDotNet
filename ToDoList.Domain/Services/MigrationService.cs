using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Services
{
    public class MigrationService
    {
        public void ExecutarMigrations(ICollection<Interfaces.IMigration> migrations)
        {
            foreach (var item in migrations)
                item.Up();
        }
    }
}

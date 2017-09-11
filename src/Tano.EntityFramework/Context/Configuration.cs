using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Tano.EntityFramework.Context
{
    public class Configuration : DbConfiguration
    {
        public Configuration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new DefaultExecutionStrategy());
        }
    }
}

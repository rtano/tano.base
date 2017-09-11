using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tano.EntityFramework.InterfacesRepositories;

namespace Tano.EntityFramework
{
    public class TesteChamadaApiRepository : BaseRepositorio<TesteChamadaApi>, ITesteChamadaApiRepository
    {
        public TesteChamadaApiRepository()
        {
            Initialize();
        }

        public TesteChamadaApi Get()
        {
            var parametros = new Dictionary<object, object>();

            var result = ExecuteProcedure(new RepositoryParam
            {
                Params = parametros,
                ProcedureName = "Consultar_TesteChamadaApi"
            });

            return result.FirstOrDefault();
        }
    }
}

using System;

namespace Tano.EntityFramework.InterfacesRepositories
{
    public class TesteChamadaApi
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInclusao { get; set; }
    }

    public interface ITesteChamadaApiRepository
    {
        TesteChamadaApi Get();
    }
}

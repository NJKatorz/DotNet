using Repository;
using Semaine_4___LegumesDemo.Models;

namespace LegumesPatternRepository.Repository
{
    class UnitOfWorkLegumesMemory : IUnitOfWorkLegumes
    {
        private LegumesRepositoryMem _legumesRepository;

        public UnitOfWorkLegumesMemory()
        {
            this._legumesRepository = new LegumesRepositoryMem();
        }

        public IRepository<Legume> LegumesRepository
        {
            get { return this._legumesRepository; }
        }
    }
}

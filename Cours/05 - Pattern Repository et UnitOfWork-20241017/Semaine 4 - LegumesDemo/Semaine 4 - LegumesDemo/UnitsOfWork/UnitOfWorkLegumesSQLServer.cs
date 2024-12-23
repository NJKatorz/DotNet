using Repository;
using Semaine_4___LegumesDemo.Models;

namespace LegumesPatternRepository.Repository
{
    class UnitOfWorkLegumesSQLServer : IUnitOfWorkLegumes
    {
        private readonly LegumesContext _context;

        private BaseRepositorySQL<Legume> _legumesRepository;


        public UnitOfWorkLegumesSQLServer(LegumesContext context)
        {
            this._context = context;
            this._legumesRepository = new BaseRepositorySQL<Legume>(context);

        }

        public IRepository<Legume> LegumesRepository
        {
            get { return this._legumesRepository; }
        }
    }
}

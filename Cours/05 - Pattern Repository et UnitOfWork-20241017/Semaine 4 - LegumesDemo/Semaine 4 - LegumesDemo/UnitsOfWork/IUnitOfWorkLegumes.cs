using Repository;
using Semaine_4___LegumesDemo.Models;

namespace LegumesPatternRepository.Repository
{
    interface IUnitOfWorkLegumes
    {
        IRepository<Legume> LegumesRepository { get; }
    }
}

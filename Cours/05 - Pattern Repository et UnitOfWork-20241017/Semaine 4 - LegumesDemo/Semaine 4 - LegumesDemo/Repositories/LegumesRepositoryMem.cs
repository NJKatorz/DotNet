using Repository;
using Semaine_4___LegumesDemo.Models;
using System.Linq.Expressions;

namespace LegumesPatternRepository.Repository
{
    class LegumesRepositoryMem : IRepository<Legume>
    {

        private List<Legume> _legumes;

        public LegumesRepositoryMem()
        {
            _legumes = new List<Legume>();
            _legumes.Add(new Legume { Name = "Chou" });
            _legumes.Add(new Legume { Name = "Salade" });
        }


        public void Delete(Legume entity)
        {
            throw new NotImplementedException();
        }

        public IList<Legume> GetAll()
        {


            return _legumes;

        }

        public Legume GetById(int id)
        {
            return _legumes[id];
        }

        public void Insert(Legume entity)
        {
            _legumes.Add(entity);
        }

        public bool Save(Legume entity, Expression<Func<Legume, bool>> predicate)
        {
            
            
            
            Legume findLegume = (SearchFor(predicate)).FirstOrDefault();

            if (findLegume == null)
            {
                Insert(entity);
                return true;
            }
            return false;
        }

        public IList<Legume> SearchFor(Expression<Func<Legume, bool>> predicate)
        {
            return _legumes.AsQueryable().Where(predicate).ToList();
        }
    }
}

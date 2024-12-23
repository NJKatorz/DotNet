using Semaine_4___LegumesDemo.Models;

namespace Repository
{
    // Cette classe n'est pas nécessaire si vous n'ajoutez aucune autre méthode que le constructeur !!!
    class LegumesRepositorySQL : BaseRepositorySQL<Legume>
    {
        public LegumesRepositorySQL(LegumesContext context) : base(context) { }
    }
}

// See https://aka.ms/new-console-template for more information
using LegumesPatternRepository.Repository;
using Repository;
using Semaine_4___LegumesDemo.Models;

Console.WriteLine("Legumes Démo - Pattern Repository SEUL très peu utilisé");

/***** UNIQUEMENT Avec Pattern Repository ... rarement utilisé sans UnitOfWork  */

// SQL
//LegumesContext context = new LegumesContext();
//BaseRepositorySQL<Legume> repoLegumes = new BaseRepositorySQL<Legume>(context);

// Mem
LegumesRepositoryMem repoLegumes = new LegumesRepositoryMem();

Console.WriteLine("Liste des légumes");

foreach (Legume legume in repoLegumes.GetAll())
{
    Console.WriteLine(legume.Name);
}

Console.ReadLine();


// search for

Console.WriteLine("Liste des légumes commençant par Sa");
foreach (Legume legume in repoLegumes.SearchFor(l => l.Name.StartsWith("Sa")))
{
    Console.WriteLine(legume.Name);
}

Console.ReadLine();

Console.WriteLine("Legumes Démo - Pattern Repository & UnitOfWork très utilisé");

// Use of UnitOfWork  ... très utilisé ! 

// Mem -> pour test ... pipeline ...
IUnitOfWorkLegumes unitofWorkLegumes = new UnitOfWorkLegumesMemory();
// SQL -> pour production
//IUnitOfWorkLegumes unitofWorkLegumes = new UnitOfWorkLegumesSQLServer(context);

Console.WriteLine("Liste des légumes");

foreach (Legume legume in unitofWorkLegumes.LegumesRepository.GetAll())
{
    Console.WriteLine(legume.Name);
}

Console.ReadLine();
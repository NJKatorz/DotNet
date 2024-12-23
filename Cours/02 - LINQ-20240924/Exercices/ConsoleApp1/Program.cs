// See https://aka.ms/new-console-template for more information
using LINQDataContext;
using System.Runtime.Intrinsics.Arm;
using static System.Collections.Specialized.BitVector32;

DataContext dc = new DataContext();

Student? jdepp = (from student in dc.Students
                  where student.Login == "jdepp"
                  select student).SingleOrDefault();

if (jdepp != null)
{
    // Console.WriteLine(jdepp.Last_Name + jdepp.First_Name);
}


// Ex2.2)

// Expression de méthode
IEnumerable<Student> QueryResult = dc.Students.Cast<Student>();

// Parcours
foreach (Student s in QueryResult)
{
    // Console.WriteLine(" {0} {1} - id = {2} and année de naissance = {3}", s.Last_Name, s.First_Name, s.Student_ID, s.BirthDate);
}


// Ex3.1)

var QueryResult3_1 = from q in dc.Students
                       where q.BirthDate.Year < 1955
                       select new
                       {
                           q.Last_Name,
                           q.Year_Result,
                           Status = q.Year_Result >= 12 ? "ok" : "ko"
                       };

// Parcours
foreach (var s in QueryResult3_1)
{
   // Console.WriteLine("nom = {0} résultat annuel = {1} - statut = {2}", s.Last_Name, s.Year_Result, s.Status);
}


// Ex3.4)
var QueryResult3_4 = from s in dc.Students
                     where s.Year_Result <= 3
                     orderby s.Year_Result descending
                     select new {
                        s.Last_Name,
                        s.Year_Result,
                     };

foreach (var s in QueryResult3_4)
{
    // Console.WriteLine("nom = {0} | résultat annuel = {1}", s.Last_Name, s.Year_Result);
}

// Ex3.5)
var QueryResult3_5 = from s in dc.Students
                     where s.Section_ID == 1110
                     orderby s.Year_Result
                     select new
                     {
                         s.Last_Name,
                         s.First_Name,
                     };

foreach (var s in QueryResult3_5)
{
    // Console.WriteLine("nom = {0} {1}", s.Last_Name, s.First_Name);
}

// Ex4.1)
IEnumerable<Student> Students = dc.Students.Cast<Student>();
// Console.WriteLine("Résultat annuel moyen pour l’ensemble des étudiants : {0}",  (double)Students.Average(c => c.Year_Result));

// Ex4.5)
// Console.WriteLine("Nombre de lignes qui composent la « table » STUDENT : {0}", Students.Count());

// Ex5.1)
IEnumerable<IGrouping<int, Student>> QueryResult5_1 = dc.Students.GroupBy(s => s.Section_ID);

foreach (IGrouping<int, Student> g in QueryResult5_1)
{
   // Console.WriteLine("Section ID = {0} - Max Resultat = {1}", g.Key, g.Max(s => s.Year_Result));
   
}


// Ex5.3)
var QueryResult5_3 = from s in dc.Students
                     where s.BirthDate.Year >= 1970 && s.BirthDate.Year <= 1985
                     group s by s.BirthDate.Month into g
                     select new
                     {
                         BirthMonth = g.Key,
                         AVG_Result = g.Average(s => s.Year_Result)
                     };

foreach (var s in QueryResult5_3)
{
    // Console.WriteLine("Résultat moyen  = {0} | Mois de naissance = {1}", s.AVG_Result, s.BirthMonth);
}

// Ex5.5)
var QueryResult5_5 = from c in dc.Courses
                     join p in dc.Professors on c.Professor_ID equals p.Professor_ID
                     join s in dc.Sections on p.Section_ID equals s.Section_ID
                     select new
                     {
                         CourseName = c.Course_Name,
                         SectionName = s.Section_Name,
                         ProfessorName = p.Professor_Name,
                     };

foreach (var q in QueryResult5_5)
{
    // Console.WriteLine("Course Name = {0} | Section Name = {1} | Professor Name = {2}", q.CourseName, q.SectionName, q.ProfessorName);
}

// Ex5.7)
var QueryResult5_7 = from s in dc.Sections
                     join p in dc.Professors on s.Section_ID equals p.Section_ID into g
                     select new
                     {
                         SectionId = s.Section_ID,
                         SectionName = s.Section_Name,
                         Professors = g
                     };

foreach (var s in QueryResult5_7)
{
    Console.WriteLine("{0} -> {1}", s.SectionId, s.SectionName);
    if (s.Professors.Count() > 0)
    {
        foreach (Professor prof in s.Professors)
        {
            Console.WriteLine("{0}", prof.Professor_Name);
        }
    }
    else
    {
        Console.WriteLine("Aucun professeur dans cette section");
    }

}

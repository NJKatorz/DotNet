using Microsoft.EntityFrameworkCore;
using Semaine3.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

NorthwindContext context = new NorthwindContext();

/**
// Ex b.1)
Console.WriteLine("B1 - Recherche clients par ville");
Console.WriteLine("Entrez le nom d'une ville :");

string ville = Console.ReadLine();
IQueryable<Customer> custs = from c in context.Customers
                             where c.City == ville
                             select c;

foreach (Customer cust in custs)
{
   Console.WriteLine("{0} : {1}", cust.CompanyName, cust.ContactName);
   
}


// Ex b.2)
IQueryable<Product> products = from p in context.Products
                               where p.Category.CategoryName == "Beverages" || p.Category.CategoryName == "Condiments"
                               select p;

string currentCategory = null;

foreach (Product product in products)
{
    if (product.Category.CategoryName != currentCategory)
    {
        currentCategory = product.Category.CategoryName;
        Console.WriteLine("Catégorie : {0}", currentCategory);
    }

    Console.WriteLine(product.ProductName);

ou 

IQueryable<Category> categories = from Category c in context.Categories
                                  where (c.CategoryName == "Beverages" || c.CategoryName == "Condiments")
                                  select c;

foreach (Category c in categories)
{
    Console.WriteLine("Catégorie :  " + c.CategoryName);
    foreach (Product p in c.Products)
    {
        Console.WriteLine(p.ProductName);
    }
}
}


// Ex b.3)
IQueryable<Category> categories = from Category c in context.Categories.Include("Products")
                                  where (c.CategoryName == "Beverages" || c.CategoryName == "Condiments")
                                  select c;

foreach (Category c in categories)
{
    Console.WriteLine("Catégorie :  " + c.CategoryName);
    foreach (Product p in c.Products)
    {
        Console.WriteLine(p.ProductName);
    }
}


// Ex b.4)
Console.WriteLine("Entrez l'ID d'un client ");

string custId = Console.ReadLine();
IQueryable<Order> custsOrders = from o in context.Orders
                             where o.CustomerId == custId && o.ShippedDate != null
                             orderby o.OrderDate descending
                             select o;

foreach (Order co in custsOrders)
{
    Console.WriteLine("CustomerID : {0} OrderDate: {1} ShippedDate : {2}", co.CustomerId, co.OrderDate, co.ShippedDate);
    // Console.WriteLine("CustomerID : " + co.CustomerId + " OrderDate : " + co.OrderDate + " ShippedDate :" + co.ShippedDate);
}

// Ex b.5)
var query = from od in context.OrderDetails.AsEnumerable()
            orderby od.ProductId
            group od by od.ProductId;

foreach (IGrouping<int, OrderDetail> orderDetails in query)
{
    Console.WriteLine(orderDetails.Key + " ----> " + orderDetails.Sum(o => o.UnitPrice * o.Quantity));
}



// Ex b.6)
IQueryable<Employee> query = from e in context.Employees
                             where e.Territories.Any(t => t.Region.RegionDescription.Equals("Western"))
                             select e;

Console.WriteLine("Liste des employés de la région Western");
foreach(Employee e in query)
{
    Console.WriteLine("{0} {1}", e.LastName, e.FirstName);
}


// Ex b.7)
var query = (from e in context.Employees
            where e.LastName == "Suyama"
            select e.ReportsToNavigation.Territories).SingleOrDefault();

Console.WriteLine("Les territoire gérés par le supérieur de Suyama");
foreach (Territory t in query)
{
    Console.WriteLine(t.TerritoryDescription);
}

// Ex c.1)
IQueryable<Customer> custs = from c in context.Customers
                             select c;


foreach (Customer cust in custs)
{
    cust.ContactName = cust.ContactName.ToUpper();
}

try
{
    context.SaveChanges();
}
catch (Exception e)
{
    Console.WriteLine("Erreur {0}", e.Message);
}


// Ex c.2)
IQueryable<Customer> custs = from c in context.Customers
                             select c;
Console.WriteLine("Vérifier que tous les noms des clients sont en majuscule");


foreach (Customer cust in custs)
{
    Console.WriteLine("{0}", cust.ContactName);
}


// Ex d.1)
Console.WriteLine("Entrez une catégorie :");
string categoryInput = Console.ReadLine();

try
{
    Category? cat = (from c in context.Categories
                     where c.CategoryName == categoryInput
                     select c).SingleOrDefault<Category>();
    if (cat == null  && categoryInput is not null)
    {
        cat = new Category();
        cat.CategoryName = categoryInput;
        context.Categories.Add(cat);
        context.SaveChanges();
    }
    else
    {
        Console.WriteLine("Une catégorie existe déjà avec ce nom");
    }

} catch (Exception e)
{
    Console.WriteLine(e.Message);
}



// Ex d.2)
IQueryable<Category> cats = from c in context.Categories
                            select c;

Console.WriteLine("Vérifiez que l’ajout a bien été effectué en DB");

foreach (Category c in cats)
{
    Console.WriteLine(c.CategoryName);

}


// Ex e.1)
Console.WriteLine("Entrez une catégorie à supprimer :");
string categoryInput = Console.ReadLine();

try
{
    Category? cat = (from c in context.Categories
                     where c.CategoryName == categoryInput
                     select c).SingleOrDefault<Category>();

    if (cat != null && categoryInput is not null)
    {
        context.Categories.Remove(cat);
        context.SaveChanges();
    }
    else
    {
        Console.WriteLine("Cette catégorie n'existe pas");
    }

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


// Ex e.2)
IQueryable<Category> cats = from c in context.Categories
                            select c;

Console.WriteLine("Vérifiez que l’ajout a bien été effectué en DB");

foreach (Category c in cats)
{
    Console.WriteLine(c.CategoryName);

}
*/

// Ex e.3)
Console.WriteLine("Entrez l'ID de l'employé à supprimer");
string? emp1 = Console.ReadLine();

Console.WriteLine("Entrez l'ID de l'employé qui reprend les Orders de celui à supprimer");
string? emp2 = Console.ReadLine();

//int e1 = int.Parse(emp1);  ou mieux TryParse
if (!int.TryParse(emp1, out int e1))
{
    Console.WriteLine("Employé 1 inconnu");
}
if (!int.TryParse(emp2, out int e2))
{
    Console.WriteLine("Employé 2 inconnu");
}

Employee employee1 = (from e in context.Employees.Include("Territories").Include("InverseReportsToNavigation")
                      where e.EmployeeId == e1
                      select e).Single<Employee>();


Employee employee2 = (from e in context.Employees
                      where e.EmployeeId == e2
                      select e).Single<Employee>();

IQueryable<Order> employee1Orders = (from o in context.Orders
                                     where o.EmployeeId == e1
                                     select o);

foreach (Order o in employee1Orders)
{
    employee2.Orders.Add(o);
    employee1.Orders.Remove(o);

}

employee1.Territories.Clear();
employee1.InverseReportsToNavigation.Clear();



context.Employees.Remove(employee1);
int affected = context.SaveChanges();
Console.WriteLine("Nombre de lignes affectées " + affected);




// Ex e.4)
IQueryable<Category> cats = from c in context.Categories
                            select c;

Console.WriteLine("Vérifiez que l’ajout a bien été effectué en DB");

foreach (Category c in cats)
{
    Console.WriteLine(c.CategoryName);

}
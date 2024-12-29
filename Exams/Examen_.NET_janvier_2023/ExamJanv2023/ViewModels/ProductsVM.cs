using ExamJanv2023.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.ViewModels;

namespace ExamJanv2023.ViewModels
{
    class ProductsVM : INotifyPropertyChanged
    {

        private NorthwindContext dc = new NorthwindContext();

        // Property changed standard handling
        public event PropertyChangedEventHandler PropertyChanged; // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // On notifie que la propriété a changé
            }
        }


        private ProductsModel _selectedProduct;
        private ObservableCollection<ProductsModel> _productsList;
        private List<ProductsSalesModel> _productsSoldByCountry;


        private DelegateCommand _discontinueCommand;



        public ObservableCollection<ProductsModel> ProductsList
        {
            get
            {
                if (_productsList == null)
                {
                    _productsList = loadProducts();
                }

                return _productsList;

            }
        }

        public List<ProductsSalesModel> ProductsSoldByCountry
        {
            get
            {
                if (_productsSoldByCountry == null)
                {
                    _productsSoldByCountry = loadProductsSoldByCountry();
                }

                return _productsSoldByCountry;
            }
        }

        private ObservableCollection<ProductsModel> loadProducts()
        {
            ObservableCollection<ProductsModel> products = new ObservableCollection<ProductsModel>();
            foreach (var product in dc.Products)
            {
                if (product.Discontinued == false)
                {
                    products.Add(new ProductsModel(product));
                }
            }
            return products;
        }

        private List<ProductsSalesModel> loadProductsSoldByCountry()
        {
            List<ProductsSalesModel> localCollection = new List<ProductsSalesModel>();
            var productSales = dc.OrderDetails
                .Where(od => od.Quantity > 0) // Filtrer les lignes de commande avec au moins une vente
                .Select(od => new { od.Product.Supplier.Country, od.Product.ProductName })
                .GroupBy(p => p.Country)
                .Select(g => new
                {
                    Country = g.Key,
                    ProductCount = g.Select(p => p.ProductName).Distinct().Count()
                })
                .OrderByDescending(p => p.ProductCount);

            foreach (var item in productSales)
            {

                localCollection.Add(new ProductsSalesModel(item.Country, item.ProductCount));
            }

            return localCollection;
        }

        public ProductsModel SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; }

        }

        public DelegateCommand DiscontinueCommand
        {
            get
            {
                return _discontinueCommand = _discontinueCommand ?? new DelegateCommand(DiscontinueProduct);
            }
        }

        private void DiscontinueProduct()
        {
            Product foundProduct = dc.Products.Where(p => p.ProductId == SelectedProduct.MyProduct.ProductId).SingleOrDefault();
            foundProduct.Discontinued = true;
            dc.SaveChanges();
            ProductsList.Remove(SelectedProduct);
        }
    }
}

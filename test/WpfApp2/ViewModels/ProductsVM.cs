using WpfApp2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.ViewModels
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
            foreach (Product product in dc.Products)
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
            var productSales =
                                dc.OrderDetails
                                  .Where(od => od.Quantity > 0)
                                  .Select(od => new { od.Product.Supplier.Country, od.Product.ProductName })
                                  .Distinct()
                                  .GroupBy(x => x.Country)
                                  .Select(g => new
                                  {
                                      Country = g.Key,
                                      ProductCount = g.Count()
                                  })
                                  .OrderByDescending(p => p.ProductCount)
                                  .ToList();

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
            // Trace.Write($"llskkskdksddsssssss {SelectedProduct.ProductId}");
            Product foundProduct = dc.Products.Where(p => p.ProductId == SelectedProduct.ProductId).SingleOrDefault();
            foundProduct.Discontinued = true;
            dc.SaveChanges();
            ProductsList.Remove(SelectedProduct);
        }
    }
}

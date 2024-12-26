using ExamSept2022.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.ViewModels;

namespace ExamSept2022.ViewModels
{
    class ProductsVM : INotifyPropertyChanged
    {
        private NorthwindContext dc = new NorthwindContext();

        private ProductsModel _selectedProduct;


        // Property changed standard handling
        public event PropertyChangedEventHandler PropertyChanged; // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // On notifie que la propriété a changé
            }
        }

        private DelegateCommand _saveCommand;


        private ObservableCollection<ProductsModel> _productsList;
        private ObservableCollection<OrdersDetailsModel> _ordersDetailsList;


        public ObservableCollection<ProductsModel> ProductsList
        {
            get
            {
                return _productsList = loadProducts();
                
            }
        }

        public ObservableCollection<OrdersDetailsModel> OrdersDetailsList
        {
            get { return _ordersDetailsList = loadOrdersDetails();  }
        }

        private ObservableCollection<ProductsModel> loadProducts()
        {
            ObservableCollection<ProductsModel> products = new ObservableCollection<ProductsModel>();
            foreach (var product in dc.Products)
            {
                products.Add(new ProductsModel(product));
            }
            return products;
        }

        private ObservableCollection<OrdersDetailsModel> loadOrdersDetails()
        {
            ObservableCollection<OrdersDetailsModel> localCollection = new ObservableCollection<OrdersDetailsModel>();
            var query = dc.OrderDetails
                .GroupBy(od => od.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    TotalSales = g.Sum(od => od.UnitPrice * od.Quantity)
                })
                .OrderBy(item => item.ProductId);

            foreach (var item in query) { 
                localCollection.Add(new OrdersDetailsModel(item.ProductId, item.TotalSales));
            }

            return localCollection;
        }


        public ProductsModel SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; }

        }

        public DelegateCommand SaveCommand
        {
            get
            {
                return _saveCommand = _saveCommand ?? new DelegateCommand(SaveProduct);
            }
        }

        private void SaveProduct()
        {
            Product verif = dc.Products.Where(p => p.ProductId == SelectedProduct.MyProduct.ProductId).SingleOrDefault();
            if (verif == null)
            {
                dc.Products.Add(SelectedProduct.MyProduct);
            }

            dc.SaveChanges();
            MessageBox.Show("Enregistrement en base de données fait");
        }



    }
}

using ExamSept2022.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSept2022.ViewModels
{
    class ProductsModel : INotifyPropertyChanged
    {
        private readonly Product _myProduct;

        // Property changed standard handling
        public event PropertyChangedEventHandler PropertyChanged;
        // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ProductsModel(Product currentProduct)
        {
            this._myProduct = currentProduct;
        }

        public Product MyProduct
        {
            get { return _myProduct; }
        }

        public int ProductID
        {
            get { return _myProduct.ProductId; }
            set { _myProduct.ProductId = value; }
        }

        public string ProductName
        {
            get { return _myProduct.ProductName; }
            set { _myProduct.ProductName = value; OnPropertyChanged("ProductName"); }
        }

        public string SupplierContactName
        {
            get { return _myProduct.Supplier.ContactName; }
            set { _myProduct.Supplier.ContactName = value; }
        }

        public string QauntityPerUnit
        {
            get { return _myProduct.QuantityPerUnit; }
            set { _myProduct.QuantityPerUnit = value; }
        }
    }
}

using WpfApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.ViewModels
{
    class ProductsModel
    {
        private readonly Product _myProduct;

        public ProductsModel(Product currentProduct)
        {
            this._myProduct = currentProduct;
        }

        public Product MyProduct
        {
            get { return _myProduct; }
        }

        public int ProductId
        {
            get { return _myProduct.ProductId; }
            set { _myProduct.ProductId = value; }
        }

        public string ProductName
        {
            get { return _myProduct.ProductName; }
            set { _myProduct.ProductName = value; }
        }

        public string Category
        {
            get { return _myProduct.Category.CategoryName; }
            set { _myProduct.Category.CategoryName = value; }
        }

        public string SupplierContactName
        {
            get { return _myProduct.Supplier.ContactName; }
            set { _myProduct.Supplier.ContactName = value; }
        }


    }
}

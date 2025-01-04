using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    class ProductsSalesModel
    {
        private string _country;
        private int _productCount;

        public ProductsSalesModel(string country, int productCount)
        {
            this._country = country;
            this._productCount = productCount;
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public int ProductCount
        {
            get { return _productCount; }
            set { _productCount = value; }
        }
    }
}

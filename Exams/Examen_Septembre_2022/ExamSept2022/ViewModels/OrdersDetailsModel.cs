using ExamSept2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSept2022.ViewModels
{
    class OrdersDetailsModel
    {
        // private readonly OrderDetail _myOrderDetail;
        private int _productID;
        private decimal _totalSales;

        public OrdersDetailsModel(int productId, decimal totalSales)
        {
            this._productID = productId;
            this._totalSales = totalSales;
        }

        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        public decimal TotalSales
        {
            get { return _totalSales; }
            set { _totalSales = value; }
        }
    }
}

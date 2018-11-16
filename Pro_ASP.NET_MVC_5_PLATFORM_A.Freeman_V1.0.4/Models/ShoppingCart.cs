using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pro_ASP.NET_MVC_5_PLATFORM_A.Freeman_V1._0._4.Models
{
    public class ShoppingCart
    {
        private IValueCalculator calc;

        public ShoppingCart(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        public IEnumerable<Product> Products { get; set; }

        public decimal CalculateProductTotal()
        {
            return calc.ValueProducts(Products);
        }
    }
}
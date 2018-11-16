using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pro_ASP.NET_MVC_5_PLATFORM_A.Freeman_V1._0._4.Models
{
    public class LinqValueCalculator : IValueCalculator
    {
        private IDiscountHelper discounter;
        private static int counter = 0;

        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            discounter = discountParam;
            System.Diagnostics.Debug.WriteLine(
                string.Format("Utworzono egzemplarz {0}", ++counter));
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return  discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pro_ASP.NET_MVC_5_PLATFORM_A.Freeman_V1._0._4.Models
{
    public class DefaultDiscountHelper : IDiscountHelper


    {
        private decimal discountSize { get; set; }

        public DefaultDiscountHelper(decimal discountParam)
        {
            discountSize = discountParam;
        }

        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (discountSize / 100m * totalParam));

        }
    }
}
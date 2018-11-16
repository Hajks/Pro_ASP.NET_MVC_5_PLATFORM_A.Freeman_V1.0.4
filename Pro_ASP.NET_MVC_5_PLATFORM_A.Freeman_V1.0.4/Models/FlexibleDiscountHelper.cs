using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pro_ASP.NET_MVC_5_PLATFORM_A.Freeman_V1._0._4.Models;

namespace Pro_ASP.NET_MVC_5_PLATFORM_A.Freeman_V1._0._4.Models
{
    public class FlexibleDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalParam)
        {
            decimal discount = totalParam > 100 ? 70 : 25;
            return (totalParam - (discount / 100m * totalParam));
        }
    }
}
﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pro_ASP.NET_MVC_5_PLATFORM_A.Freeman_V1._0._4.Models;
using Moq;

namespace Pro_ASP.NET_MVC_5_PLATFORM_A.Freeman_V1._0._4.Tests
{
    [TestClass]
    public class UnitTest2
    {

        private Product[] products =
        {
            new Product {Name = "Kajak", Category = "Sporty wodne", Price = 275M},
            new Product {Name = "Kamizelka ratunkowa", Category = "Sporty wodne", Price = 48.95M},
            new Product {Name = "Piłka nożna", Category = "Piłka nożna", Price = 19.50M},
            new Product {Name = "Flaga narożna", Category = "Piłka nożna", Price = 34.95M}
        };

        [TestMethod]
        public void Sum_Products_Correctly()
        {
            //var discounter = new MinimumDiscountHelper();
            //var target = new LinqValueCalculator(discounter);
            //var goalTotal = products.Sum(e => e.Price);

            //var result = target.ValueProducts(products);

            //Assert.AreEqual(goalTotal, result);


            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<Decimal>())).Returns<decimal>(total => total);
            var target =new LinqValueCalculator(mock.Object);

            var result = target.ValueProducts(products);

            Assert.AreEqual(products.Sum(e => e.Price), result);
        }

        private Product[] createProduct(decimal value)
        {
            return new[] {new Product() {Price = value}};
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Pass_Through_Variable_Discounts()
        {
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v == 0))).Throws<System.ArgumentOutOfRangeException>();
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v > 100))).Returns<decimal>(total => (total* 0.9M));
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive))).Returns<decimal>(total => (total -5));
            
            var target = new LinqValueCalculator(mock.Object);

            decimal FiveDollarDiscount = target.ValueProducts(createProduct(5));
            decimal TenDollarDiscount = target.ValueProducts((createProduct(10)));
            decimal FiftyDollarDiscount = target.ValueProducts(createProduct(50));
            decimal HundredDollarDiscount = target.ValueProducts(createProduct(100));
            decimal FiveHundredDollarDiscount = target.ValueProducts(createProduct(500));

            Assert.AreEqual(5, FiveDollarDiscount, "Niepowodzenie 5 zł");
            Assert.AreEqual(5, TenDollarDiscount, "Niepowodzenie 10 zł");
            Assert.AreEqual(45, FiftyDollarDiscount, "Niepowodzenie 50 zł");
            Assert.AreEqual(95, HundredDollarDiscount, "Niepowodzenie 100 zł");
            Assert.AreEqual(450, FiveHundredDollarDiscount, "Niepowodzenie 500 zł");
            target.ValueProducts(createProduct(0));
        }
        
    }
}

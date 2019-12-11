using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;

namespace Testy
{
    [TestClass]
    public class Stage3LinqTests
    {
        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<Product> products = Stage3Linq.GetProductsByName("Fork");
            Assert.AreEqual(5, products.Count);
            
        }

        [TestMethod]
        public void GetProductsByVendorNameTest()
        {
            List<Product> products = Stage3Linq.GetProductsByVendorName("American Bikes");
            Assert.AreEqual(1, products.Count);
           
        }

        [TestMethod]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> names = Stage3Linq.GetProductNamesByVendorName("Jeff's Sporting Goods");
            Assert.AreEqual(4, names.Count);
            Assert.AreEqual('M', names[0].FirstOrDefault());

        }

        [TestMethod]
        public void GetProductVendorByProductNameTest()
        {
            string vendorName = Stage3Linq.GetProductVendorByProductName("Mountain Bike Socks, M");
            Assert.AreEqual("Jeff's Sporting Goods", vendorName);

        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> products = Stage3Linq.GetProductsWithNRecentReviews(1);
            Assert.AreEqual(2, products.Count());
            Assert.AreEqual(798, products[1].ProductID);

        }


        [TestMethod]
        public void GetNRecentlyReviewedProductsTest()
        {
            List<Product> products = Stage3Linq.GetNRecentlyReviewedProducts(2);
            Assert.AreEqual(2, products.Count());
            Assert.AreEqual(937, products[0].ProductID);

        }

        [TestMethod]
        public void GetNProductsFromCategoryTest()
        {
            List<Product> products = Stage3Linq.GetNProductsFromCategory("Clothing",5);
            Assert.AreEqual(5, products.Count());
        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryTest()
        {
            ProductCategory bikes = new ProductCategory
            {
                Name = "Bikes"
            };

            int totalStandardCost = Stage3Linq.GetTotalStandardCostByCategory(bikes);
            Assert.AreEqual(92092, totalStandardCost);
        }




    }
}

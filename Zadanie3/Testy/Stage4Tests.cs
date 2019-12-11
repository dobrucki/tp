using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;
using System.Linq;

namespace Testy
{
    [TestClass]
    public class Stage4Tests
    {

        [TestMethod]
        public void GetProductsWithoutCategory_Declarative_Test()
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<Product> products = db.GetTable<Product>().ToList();
                List<Product> productListWithoutCategory = products.GetProductsWithoutCategory_Declarative();

                foreach (Product product in productListWithoutCategory)
                    Assert.IsNull(product.ProductSubcategory);
            }
        }



        [TestMethod]
        public void GetProductsWithoutCategory_Imperative_Test()
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<Product> products = db.GetTable<Product>().ToList();
                List<Product> productListWithoutCategory = products.GetProductsWithoutCategory_Imperative();

                foreach (Product product in productListWithoutCategory)
                    Assert.IsNull(product.ProductSubcategory);
            }
        }

        [TestMethod]
        public void SplitToPages_Declarative_Test()
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<Product> products = db.GetTable<Product>().ToList();
                List<Product> productPages = products.SplitToPages_Declarative(5, 3);

                Assert.AreEqual(5, productPages.Count);
                Assert.AreEqual(products[10].ProductID, productPages[0].ProductID);
            }
        }

        [TestMethod]
        public void SplitToPages_Imperative_Test()
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<Product> products = db.GetTable<Product>().ToList();
                List<Product> productPages = products.SplitToPages_Imperative(5, 3);

                Assert.AreEqual(5, productPages.Count);
                Assert.AreEqual(products[10].ProductID, productPages[0].ProductID);
            }
        }

        [TestMethod]
        public void ProductsAndVendorsToString_Declarative_Test()
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<Product> products = db.GetTable<Product>().ToList();
                List<ProductVendor> vendors = db.GetTable<ProductVendor>().ToList();

                string output = products.ProductsAndVendorsToString_Declarative(vendors);
                string firstline = output.Substring(0, output.IndexOf(Environment.NewLine));

                
                Assert.AreEqual("Adjustable Race-Litware, Inc.", firstline);
            }
        }

        [TestMethod]
        public void ProductsAndVendorsToString_Imperative_Test()
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<Product> products = db.GetTable<Product>().ToList();
                List<ProductVendor> vendors = db.GetTable<ProductVendor>().ToList();

                string output = products.ProductsAndVendorsToString_Imperative(vendors);
                string firstline = output.Substring(0, output.IndexOf(Environment.NewLine));

               
                Assert.AreEqual("Adjustable Race-Litware, Inc.", firstline);
            }
        }






    }
}

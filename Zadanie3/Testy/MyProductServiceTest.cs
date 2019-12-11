using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;

namespace Testy
{
    [TestClass]
    public class MyProductServiceTest
    {
        [TestMethod]
        public void MyProductService_GetProductsByName_Test()
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                MyProductRepository myProductRepository = new MyProductRepository(db);
                MyProductService myProductService = new MyProductService(myProductRepository);

                List<MyProduct> products = myProductService.GetProductsByName("Fork");
                Assert.AreEqual(5, products.Count);
            }
        }



        [TestMethod]
        public void MyProductService_GetNProductsFromCategory_Test()
        {

            using (ProductionDataContext db = new ProductionDataContext())
            {
                MyProductRepository myProductRepository = new MyProductRepository(db);
                MyProductService myProductService = new MyProductService(myProductRepository);

                List<MyProduct> products = myProductService.GetNProductsFromCategory("Clothing", 4);
                Assert.AreEqual(4, products.Count);
                foreach (Product product in products)
                    Assert.AreEqual(product.ProductSubcategory.ProductCategory.Name, "Clothing");


            }
        }


        [TestMethod]
        public void MyProductService_GetProductsWithNRecentReviews_Test()
        {

            using (ProductionDataContext db = new ProductionDataContext())
            {
                MyProductRepository myProductRepository = new MyProductRepository(db);
                MyProductService myProductService = new MyProductService(myProductRepository);

                List<MyProduct> products = myProductService.GetProductsWithNRecentReviews(1);
                Assert.AreEqual(2, products.Count());
                Assert.AreEqual(709, products[0].ProductID);


            }
        }




    }



}

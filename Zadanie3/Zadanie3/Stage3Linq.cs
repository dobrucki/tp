using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class Stage3Linq
    {
        public static List<Product> GetProductsByName(string namePart)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                IQueryable<Product> output = from product in db.Product
                                             where product.Name.Contains(namePart)
                                             select product;

                return output.ToList();
            }
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                IQueryable<Product> output = from vendor in db.ProductVendor
                                             where vendor.Vendor.Name.Equals(vendorName)
                                             select vendor.Product;
                return output.ToList();
            }
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                IQueryable<string> output = from vendor in db.ProductVendor
                                            where vendor.Vendor.Name.Equals(vendorName)
                                            select vendor.Product.Name;
                return output.ToList();
            }

        }

        public static string GetProductVendorByProductName(string productName)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                string output = (from vendor in db.ProductVendor
                                 where vendor.Product.Name.Equals(productName)
                                 select vendor.Vendor.Name).FirstOrDefault();
                return output;
            }
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                IQueryable<Product> output = from product in db.Product
                                             where product.ProductReview.Count.Equals(howManyReviews)
                                             select product;
                return output.ToList();
            }
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<Product> products = (from review in db.ProductReview
                                          orderby review.ReviewDate descending
                                          select review.Product).Take(howManyProducts).ToList();
                return products;

            }
        }



        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                List<Product> products = (from product in db.Product
                                          where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                          select product).Take(n).ToList();
                return products;
            }
        }


        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            using (ProductionDataContext db = new ProductionDataContext())
            {
                IQueryable<decimal> output = from product in db.Product
                             where product.ProductSubcategory.ProductCategory.Name.Equals(category.Name)
                             select product.StandardCost;

                return (int)output.Sum();
            }

        }
    }
}


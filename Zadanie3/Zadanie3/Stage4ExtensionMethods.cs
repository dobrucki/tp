using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public static class Stage4ExtensionMethods
    {
        #region Declarative
        public static List<Product> GetProductsWithoutCategory_Declarative(this List<Product> products)
        {

            IEnumerable<Product> output = from product in products
                                          where product.ProductSubcategory == null
                                          select product;

            return output.ToList();

        }

        public static List<Product> SplitToPages_Declarative(this List<Product> products, int size, int pageNumber)
        {
            List<Product> output = (from product in products
                                    select product).Skip((pageNumber - 1) * size).Take(size).ToList();
            return output;
        }

        public static string ProductsAndVendorsToString_Declarative(this List<Product> products, List<ProductVendor> productVendors)
        {

            StringBuilder sB = new StringBuilder();

            var pairs = from product in products
                        from productVendor in productVendors
                        where productVendor.ProductID == product.ProductID
                        select new { Product = product.Name, Vendor = productVendor.Vendor.Name };

            foreach (var pair in pairs)
            {
                sB.Append(pair.Product).Append("-").Append(pair.Vendor);
                sB.AppendLine();
            }
            return sB.ToString();
        }
        #endregion

        #region Imperative
        public static List<Product> GetProductsWithoutCategory_Imperative(this List<Product> products)
        {
            return products.Where(p => p.ProductSubcategory == null).ToList();
        }

        public static List<Product> SplitToPages_Imperative(this List<Product> products, int size, int pageNumber)
        {
            return products.Skip((pageNumber - 1) * size).Take(size).ToList();
        }

        public static string ProductsAndVendorsToString_Imperative(this List<Product> products, List<ProductVendor> productVendors)
        {

            StringBuilder sB = new StringBuilder();

            var pairs = products.Join(productVendors, product => product.ProductID, vendor => vendor.ProductID, (product, vendor)
                 => new { Product = product.Name, Vendor = vendor.Vendor.Name });

            foreach (var pair in pairs)
            {
                sB.Append(pair.Product).Append("-").Append(pair.Vendor);
                sB.AppendLine();
            }
            return sB.ToString();
        }

        #endregion

    }
}

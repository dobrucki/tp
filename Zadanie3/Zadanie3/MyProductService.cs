using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MyProductService
    {
        private readonly MyProductRepository _myProductRepository;

        public MyProductService(MyProductRepository myProductRepository)
        {
            _myProductRepository = myProductRepository;
        }

        public List<MyProduct> GetProductsByName(string namePart)
        {
            return (from product in _myProductRepository.myProducts
                   where product.Name.Contains(namePart)
                   select product).ToList();
            
        }

        public List<MyProduct> GetProductsWithNRecentReviews(int howManyReviews)
        {

            return (from product in _myProductRepository.myProducts
                    where product.ProductReview.Count.Equals(howManyReviews)
                    select product).ToList();
        }


        public List<MyProduct> GetNProductsFromCategory(string categoryName, int n)
        {
            return (from product in _myProductRepository.myProducts
                    where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                    select product).Take(n).ToList();
        }







    }
}

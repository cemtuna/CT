using CT.Sfa.Business.Abstract;
using CT.Sfa.DataAccess.Abstract;
using CT.Sfa.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CT.Sfa.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { ProductId = productId });
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int productId)
        {

            return _productDal.Get(p => p.ProductId == productId);
        }

        public List<Product> GetProductListStarsWith(string letter)
        {
            return _productDal.GetAll(p => p.ProductName.StartsWith(letter));
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}

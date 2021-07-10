using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);

            return new SuccesResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);

            return new SuccesResult(Messages.ProductDeteled);
        }
        public IResult Update(Product product)
        {
            _productDal.Update(product);

            return new SuccesResult(Messages.ProductUpdated);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccesDataResult<Product>(_productDal.Get(x=>x.ProductId == productId), Messages.ProductByIdListed);
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccesDataResult<List<Product>>(_productDal.GetList().ToList(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccesDataResult<List<Product>>(_productDal.GetList(x => x.CategoryId == categoryId).ToList(), Messages.ProductsByCategoryListed);
        }
    }
}

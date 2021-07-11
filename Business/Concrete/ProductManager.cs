using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttinConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttinConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspects(typeof(ProductValidator), Priority = 1)]
        //[ValidationAspects(typeof(ProductValidator), Priority = 2)]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);

            return new SuccessResult(Messages.ProductDeteled);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);

            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x=>x.ProductId == productId), Messages.ProductByIdListed);
        }

        [PerformanceAspect(5)]
        [SecuredOperation("admin,product.list")]
        public IDataResult<List<Product>> GetList()
        {
            //Thread.Sleep(5000); //performance test
            
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList(), Messages.ProductsListed);
        }

        [CacheAspect(1)]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(x => x.CategoryId == categoryId).ToList(), Messages.ProductsByCategoryListed);
        }

        [TransactionScopeAspect]
        //Sadece test için uydurma bir method
        public IResult TransactionalOperation(Product product)
        {
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
    }
}

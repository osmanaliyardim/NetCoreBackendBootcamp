﻿using Business.Abstract;
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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);

            return new SuccesResult(Messages.CategoryAdded);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);

            return new SuccesResult(Messages.CategoryDeteled);
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);

            return new SuccesResult(Messages.CategoryUpdated);
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccesDataResult<Category>(_categoryDal.Get(x=>x.CategoryId == categoryId), Messages.CategoryByIdListed);
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccesDataResult<List<Category>>(_categoryDal.GetList().ToList(), Messages.CategoriesListed);
        }
    }
}
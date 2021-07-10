﻿using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccesResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);

            return new SuccesResult(Messages.UserDeteled);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);

            return new SuccesResult(Messages.UserUpdated);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccesDataResult<User>(_userDal.Get(x=>x.Id == userId), Messages.UserByIdListed);
        }

        public IDataResult<List<User>> GetList()
        {
            return new SuccesDataResult<List<User>>(_userDal.GetList().ToList(), Messages.UsersListed);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccesDataResult<List<OperationClaim>>(_userDal.GetClaims(user), Messages.UserByClaimListed);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccesDataResult<User>(_userDal.Get(x => x.Email == email), Messages.UserByMailListed);
        }
    }
}

using Business.Abstract;
using Core.Utilities.Results;
using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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

        public IResult Add(User car)
        {
            _userDal.Add(car);

            return new SuccessResult();
        }

        public IResult Delete(User car)
        {
            _userDal.Delete(car);

            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.Id == id));
        }

        public IResult Update(User car)
        {
            _userDal.Update(car);

            return new SuccessResult();
        }
    }
}

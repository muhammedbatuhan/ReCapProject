using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                _rentalDal.Add(rental);
            }
            else
            {
                return new ErrorResult(Messages.CarsListed);
            }


            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);

            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);

            return new SuccessResult();
        }
    }
}

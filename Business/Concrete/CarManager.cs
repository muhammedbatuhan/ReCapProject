using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            //business codes

            if (car.CarName.Length<2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
           _carDal.Add(car);
            
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<List<Car>> GetAll()
        {

            if (DateTime.Now.Hour==12)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int CarId)
        {
            return new SuccessDataResult<Car> (_carDal.Get(c=>c.Id == CarId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {

            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int CarId)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.BrandId == CarId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int CarId)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.ColorId == CarId));
        }
    }
}

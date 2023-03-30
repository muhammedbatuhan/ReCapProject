using Core.DataAccess.EntityFramework;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, mbgContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (mbgContext context = new mbgContext())
            {
                var result = from c in context.Cars
                             join k in context.Colors
                             on c.Id equals k.Id
                             select new CarDetailDto 
                             {
                                 BrandName = k.Name, CarName = c.CarName,
                                 ColorName = k.Name, DailyPrice = c.DailyPrice
                             };
                return result.ToList();

            }
        }
    }
}

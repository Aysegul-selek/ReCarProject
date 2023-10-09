using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepoSitoryBase<Car, RecapContext>, IcarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from car in context.cars
                             join b in context.brands
                             on car.BrandId equals b.BrandId
                             join c in context.colors
                             on car.ColorId equals c.ColorId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = c.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 ModelName = car.ModelName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,

                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailByBrandId(int brandId)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.cars
                             join b in context.brands
                             on c.BrandId equals b.BrandId
                             join d in context.colors
                             on c.ColorId equals d.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId
                             ,
                                 BrandId = b.BrandId,
                                 ColorId = c.ColorId,
                                 BrandName = b.BrandName


                             };
                return result.ToList();
            }
        }
            public List<CarDetailDto> GetCarDetailByColorId(int colorId)
            {
            using (RecapContext context=new RecapContext())
            {
                var result = from p in context.cars
                             join c in context.colors
                             on p.ColorId equals c.ColorId
                             select new CarDetailDto
                             {
                                 CarId = p.CarId,
                                 CarName = p.CarName,
                                 ColorId = c.ColorId,
                                 ColorName = c.ColorName,
                             };
                return result.ToList();
            }
            }
        }
    }

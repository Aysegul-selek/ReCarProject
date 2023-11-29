using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepoSitoryBase<Car, RecapContext>, IcarDal
    {
        public List<CarDetailDto> GetCarDetailByBrandId(int brandId)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join c in context.Colors
                             on car.ColorId equals c.ColorId
                             where b.BrandId == brandId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = c.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 ModelName = car.ModelName,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 File = (from ci in context.CarImages where car.CarId == ci.CarId select ci.File).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailByCarId(int carId)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join c in context.Colors
                             on car.ColorId equals c.ColorId
                             where car.CarId == carId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = c.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 ModelName = car.ModelName,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 File = (from ci in context.CarImages where car.CarId == ci.CarId select ci.File).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailByColorId(int colorId)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join c in context.Colors
                             on car.ColorId equals c.ColorId
                             where c.ColorId == colorId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = c.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 ModelName = car.ModelName,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 File = (from ci in context.CarImages where car.CarId == ci.CarId select ci.File).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join c in context.Colors
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
                                 File = (from ci in context.CarImages where ci.CarId == car.CarId select ci.File).FirstOrDefault()
                             };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandAndColor(int brandId, int colorId)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join carImage in context.CarImages on car.CarId equals carImage.CarId
                             where car.BrandId == brandId && car.ColorId == colorId
                             select new CarDetailDto()
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 ColorName = color.ColorName,
                                 BrandName = brand.BrandName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,
                                 File = (from ci in context.CarImages where car.CarId == ci.CarId select ci.File).FirstOrDefault()
                             };

                return result.ToList();
            }
        }
    }

}


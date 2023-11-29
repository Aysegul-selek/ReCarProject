using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IcarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetailByBrandId(int brandId);
        List<CarDetailDto> GetCarDetailByColorId(int colorId);
        List<CarDetailDto> GetCarDetailsByBrandAndColor(int brandId, int colorId);
        List<CarDetailDto> GetCarDetailByCarId(int carId);

    }
}

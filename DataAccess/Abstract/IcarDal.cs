using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IcarDal:IEntityRepository<Car>
    {
       List<CarDetailDto> GetCarDetail();
        List<CarDetailDto> GetCarDetailByBrandId(int brandId);
      List<CarDetailDto>GetCarDetailByColorId(int colorId);
    }
}

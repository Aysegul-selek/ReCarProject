using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarServices
    {
        IDataResult<List<Car>>GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetailByBrandId(int brandId);//Brand e göre  getir
        IDataResult<List<CarDetailDto>> GetCarDetailByColorId(int colorId);
        IDataResult<Car> GetById(int id);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult Add(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetail();
    }
}

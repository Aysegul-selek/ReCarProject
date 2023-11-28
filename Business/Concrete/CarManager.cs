using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;

namespace Business.Concrete
{
    public class CarManager : ICarServices
    {
        IcarDal _cars;
        public CarManager(IcarDal ıcarDal)
        {
            _cars = ıcarDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.Success);
            }
            _cars.Add(car);

            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(Car car)
        {
            if (car.CarId == null)
            { return new ErrorResult(Messages.Error); }
            _cars.Delete(car);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.Error);
            }
            //iş kodları
            return new SuccessDataResult<List<Car>>(_cars.GetAll(), Messages.Success);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_cars.Get(p => p.CarId == id));
        }

     

        public IDataResult<List<CarDetailDto>> GetCarDetailByBrandId(int brandId)
        {
            List<CarDetailDto> carDetails = _cars.GetCarDetails(c => c.BrandId == brandId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>("");
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails, "");
            }
        }

    
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_cars.GetAll(b => b.BrandId == brandId));
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cars.GetCarDetails(), Messages.Success);
        }

        public IResult Update(Car car)
        {
            if (car.CarId == null)
            { return new ErrorResult(Messages.Error); }
            _cars.Update(car);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_cars.GetAll(b => b.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cars.GetCarDetails(p => p.CarId == carId));
        }
    }
}

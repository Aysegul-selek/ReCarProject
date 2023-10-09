using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : IcarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car> {
                new Car{ CarId=1,BrandId=1,ColorId=2,DailyPrice=255,Description="BMW",ModelYear=1999},
                new Car{ CarId=2,BrandId=1,ColorId=3,DailyPrice=655,Description="MINI",ModelYear=1999},
                new Car{ CarId=3,BrandId=1,ColorId=4,DailyPrice=55,Description="BMWX5",ModelYear=1999}};
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete = _car.SingleOrDefault(p => p.CarId == car.CarId);
            _car.Remove(car);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _car.Where(_car => _car.CarId == id).ToList();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carupdate = _car.SingleOrDefault(p => p.CarId == car.CarId);
            carupdate.CarId = car.CarId;
            carupdate.BrandId = car.BrandId;
            carupdate.ColorId = car.ColorId;
            carupdate.BrandId = car.BrandId;
            carupdate.Description = car.Description;
            carupdate.DailyPrice = car.DailyPrice;
            carupdate.ModelYear = car.ModelYear;
        }
    }
}

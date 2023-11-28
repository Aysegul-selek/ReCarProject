using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.Utilities.Helpers.FileHelper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;
using Core.Utilities.Business;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageServices
    {
        ICarImageDal _ıcarImageDal;
        IFileHelper _fileHelperService;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelperService)
        {
            _ıcarImageDal = carImageDal;
            _fileHelperService = fileHelperService;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(ChechCarImageCount(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.File = _fileHelperService.Upload(file, PathConstants.ImagesPath);
            carImage.ImageDate = DateTime.Now;
            _ıcarImageDal.Add(carImage);
            return new SuccessResult("Foto başarıyla yüklendi");
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelperService.Delete(PathConstants.ImagesPath + carImage.File);
            _ıcarImageDal.Delete(carImage);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_ıcarImageDal.GetAll(), Messages.Success);
        }

      
     
        private IResult CheckCarImage(int carId)
        {
            var result = _ıcarImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        public IDataResult<CarImage> GetById(int id)
        {
           return new SuccessDataResult<CarImage>(_ıcarImageDal.Get(p=>p.CarImageId == id), Messages.Success);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.File = _fileHelperService.Update(file, PathConstants.ImagesPath + carImage.File,
                PathConstants.ImagesPath);

            carImage.ImageDate = DateTime.Now;
            _ıcarImageDal.Update(carImage);
            return new SuccessResult(Messages.Success);
        }

        private IResult ChechCarImageCount(int carId)
        {//bir arabanınen fazla 5 resmi olabilir
            var result = _ıcarImageDal.GetAll(p=>p.CarId==carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_ıcarImageDal.GetAll(c => c.CarId == carId));
        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();
            carImages.Add(new CarImage { CarId = carId, ImageDate = DateTime.Now, File = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImages);
        }
    }
}

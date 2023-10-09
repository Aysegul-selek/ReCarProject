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
            IResult result = BusinessRules.Run(ChechCarImageCount(carImage.CarImageId));
            if (result != null)
            {
                return result;
            }
            carImage.File = _fileHelperService.Upload(file, PathConstants.ImagesPath);
            carImage.ImageDate = DateTime.Now;
            _ıcarImageDal.Add(carImage);
            return new SuccessResult(Messages.Success);
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

        private IResult ChechCarImageCount(int carImageId)
        {//bir arabanınen fazla 5 resmi olabilir
            var result = _ıcarImageDal.GetAll(p=>p.CarImageId==carImageId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}

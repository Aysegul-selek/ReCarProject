using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorServices
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.Success);
            }
            _colorDal.Add(color);

            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(Color color)
        {
            if (color.ColorId == null)
            { return new ErrorResult(Messages.Error); }
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Color>>(Messages.Error);
            }
            //iş kodları
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.Success);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>( _colorDal.Get(c => c.ColorId == id));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
           return new SuccessResult(Messages.Success);
        }
    }
}

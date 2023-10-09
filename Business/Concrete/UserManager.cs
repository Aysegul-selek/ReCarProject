using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserServices
    {
        IUserDal _user;

        public UserManager(IUserDal user)
        {
            _user = user;
        }

        public IResult Add(User user)
        {
            _user.Add(user);
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(User user)
        {
            _user.Delete(user); return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<User>> GetAll()
        {
           return new SuccessDataResult<List<User>>(_user.GetAll(),Messages.Success);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_user.Get(p=>p.Id==userId),Messages.Success);
        }

        public IResult Update(User user)
        {
            _user.Update(user);
            return new SuccessResult(Messages.Success);
        }
    }
}

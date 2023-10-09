using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : IcustomerServices
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(Customer customer)
        {
           _customerDal.Delete(customer);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Customer>> GetAll()
        {
           return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.Success);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
           return new SuccessDataResult<Customer>(_customerDal.Get(p=>p.CustomerId==customerId));
        }

        public IResult Update(Customer customer)
        {
           _customerDal.Update(customer);
            return new SuccessResult(Messages.Success);
        }
    }
}

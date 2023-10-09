using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using  Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal :EfEntityRepoSitoryBase<Color,RecapContext>, IColorDal
    {
        

       
    }
}

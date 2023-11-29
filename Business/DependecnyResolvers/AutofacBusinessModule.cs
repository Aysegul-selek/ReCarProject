using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Helpers.FileHelper;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System.Reflection;
using Module = Autofac.Module;

namespace Business.DependecnyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarServices>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<IcarDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorServices>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandServices>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalServices>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<CarImageManager>().As<ICarImageServices>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();
            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();
            builder.RegisterType<PaymentManager>().As<IPaymentServices>().SingleInstance();
            builder.RegisterType<EfPaymentDal>().As<IPaymentDal>().SingleInstance();
        }
    }
}

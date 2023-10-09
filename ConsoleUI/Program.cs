using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            carmethod2();
        }

        private static void carmethod()
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (Car service in carManager.GetAll())
            //{
            //    Console.WriteLine(service.Description);
            //}
        }
        private static void carmethod2()
        {
            CarManager carManager2 = new (new EfCarDal());
            foreach (Car service in carManager2.GetAll().Data)
            {
                Console.WriteLine(service.Description);
            }
        }
    }
}

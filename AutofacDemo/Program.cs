using Autofac;
using AutofacDemo.Class;
using AutofacDemo.Interface;
using AutofacDemo.Service;
using System;
using System.Reflection;

namespace AutofacDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Sedan>().As<ICar>();
            builder.RegisterType<Hatchback>().As<ICar>().InstancePerLifetimeScope();
            builder.RegisterType<Truck>().SingleInstance();
            builder.RegisterType<FactoryService>().As<IFactory>();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            Console.WriteLine($"LifeScope1");
            using (var scope = container.BeginLifetimeScope())
            {
                var car1 = container.Resolve<Truck>();
                Console.WriteLine($"{car1.ToString()},{car1.Uniqkey}");
                var car2 = container.Resolve<ICar>();
                Console.WriteLine($"{car2.ToString()},{car2.Uniqkey}");
                var factory = container.Resolve<IFactory>();
            }

            Console.WriteLine($"\nLifeScope2");
            using (var scope = container.BeginLifetimeScope())
            {
                var car3 = container.Resolve<Truck>();
                Console.WriteLine($"{car3.ToString()},{car3.Uniqkey}");
                var car4 = container.Resolve<ICar>();
                Console.WriteLine($"{car4.ToString()},{car4.Uniqkey}");
                var factory = container.Resolve<IFactory>();
            }


            Console.WriteLine($"\nLifeScope3");
            using (var scope = container.BeginLifetimeScope(newBuilder =>
            {
                newBuilder.RegisterType<SportsCar>().As<ICar>();
            }))
            {
                var car5 = container.Resolve<SportsCar>();
                Console.WriteLine($"{car5.ToString()},{car5.Uniqkey}");
                var car6 = container.Resolve<ICar>();
                Console.WriteLine($"{car6.ToString()},{car6.Uniqkey}");
                var factory = container.Resolve<IFactory>();
            }
            

            Console.ReadLine();
        }
    }

    public static class helper
    {
        private static void Print(this ICar car)
        {
            Console.WriteLine($"{car.ToString()},{car.Uniqkey}");
        }
    }
}

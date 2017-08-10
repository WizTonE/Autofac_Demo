using Autofac;
using AutofacDemo.Class;
using System.Reflection;

namespace AutofacDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Sedan>().As<ICar>();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var car = container.Resolve<ICar>();
            }
        }
    }
}

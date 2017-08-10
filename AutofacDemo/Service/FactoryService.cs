using Autofac.Features.OwnedInstances;
using AutofacDemo.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDemo.Service
{
    public class FactoryService : AbstractFactory
    {
        private Owned<ICar> _car { get; set; }
        public FactoryService(Owned<ICar> car)
        {
            _car = car;
            Console.WriteLine($"In Factory : {_car.Value.ToString()},{_car.Value.Uniqkey}");
        }
    }
}

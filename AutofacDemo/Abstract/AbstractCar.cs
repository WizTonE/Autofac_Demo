using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDemo.Abstract
{
    public abstract class AbstractCar : ICar
    {
        public int Doors { get; set; }
        public int Tires { get; set; }
    }
}

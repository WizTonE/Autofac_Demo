using AutofacDemo.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDemo.Class
{
    public class Hatchback : AbstractCar
    {
        private Guid _UniqueKey = Guid.NewGuid();
        public override Guid Uniqkey { get => _UniqueKey;}
    }
}

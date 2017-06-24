using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Elemnts.Curcuit
{
    public interface ICircuit : IComponent
    {
        string Name { get; set; }
    }
}

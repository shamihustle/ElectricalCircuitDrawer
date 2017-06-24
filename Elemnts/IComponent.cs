using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Elemnts
{
    public interface IComponent
    {
        void AddComponent(IComponent component);

        void RemoveComponent(IComponent component);

        Complex CalculateZ(double angularFrequency);

    }
}

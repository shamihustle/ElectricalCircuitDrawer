using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Elemnts
{
    public interface IElement : IComponent
    {
        string Name { get; set; }

        /// <summary>
        /// Значение номинала
        /// </summary>
        double Value { get; set; }
        
    }
}

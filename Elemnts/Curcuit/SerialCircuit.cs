using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Elemnts.Curcuit
{
    public class SerialCircuit : ICircuit
    {
        public string Name { get; set; }
        
        private List<IComponent> _components = new List<IComponent>();

        public void AddComponent(IComponent component)
        {
            _components.Add(component);
        }

        public void RemoveComponent(IComponent component)
        {
            _components.Remove(component);
        }

        public Complex CalculateZ(double angularFrequency)
        {
            Complex result = new Complex();

            for (int i = 0; i < _components.Count; i++)
            {
                result += _components[i].CalculateZ(angularFrequency);
            }

            return result;
        } 
    }
}

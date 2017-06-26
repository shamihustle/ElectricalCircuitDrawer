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
        List<IComponent> Components { get; set; }

        /// <summary>
        /// Добавить компонент
        /// </summary>
        /// <param name="component">Элемент или соединение</param>
        void Add(IComponent component);

        /// <summary>
        /// Удалить компонент
        /// </summary>
        /// <param name="component">Элемент или соединение</param>
        void Remove(IComponent component);
    }
}

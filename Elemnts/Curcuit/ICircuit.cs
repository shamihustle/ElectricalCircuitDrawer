using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Elements.Curcuit;
using Elemnts.Elements;

namespace Elemnts.Curcuit
{
    public interface ICircuit : IComponent
    {
        List<IComponent> Components { get; set; }

        event EventHandler CircuitChanged;


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

        void ModifyElement(IElement componentOld, IElement componentNew);

        void ModifyCircuit(ICircuit componentOld, ICircuit componentNew);

        void RemoveElement(IElement element);

        void RemoveCircuit(ICircuit component);

        void OnCircuitChanged(object sender, EventArgs args);

    }
}

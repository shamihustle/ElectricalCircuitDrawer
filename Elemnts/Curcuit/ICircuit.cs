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

        void ModifyElement(IElement componentOld, IElement componentNew, ICircuit mainCircuit);

        void ModifyCircuit(ICircuit componentOld, ICircuit componentNew, ICircuit mainCircuit);

        void RemoveElement(IElement element, ICircuit mainCircuit);

        void RemoveCircuit(ICircuit components, ICircuit mainCircuit);

        void OnCircuitChanged(object sender, EventArgs args);

    }
}

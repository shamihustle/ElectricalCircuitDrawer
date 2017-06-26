namespace Elemnts.Elements
{
    public interface IElement : IComponent
    {
        /// <summary>
        /// Значение номинала
        /// </summary>
        double Value { get; set; }
        
    }
}

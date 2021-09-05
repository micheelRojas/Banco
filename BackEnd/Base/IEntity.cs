namespace BackEnd.Base
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}

namespace Content.Actors.Attack
{
    public interface IPrototype<T>
    {
        public T Clone();
    }
}
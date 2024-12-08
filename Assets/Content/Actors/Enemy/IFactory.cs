namespace Content.Actors.Enemy
{
    public interface IFactory<T>
    {
        public T Get();
    }
}
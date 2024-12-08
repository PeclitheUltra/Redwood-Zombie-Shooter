using Content.Actors.Attack;

namespace Content.Actors.Health
{
    public interface IHealth : IPrototype<IHealth>, IHealthDataSource, IDamageable
    {
    }
}
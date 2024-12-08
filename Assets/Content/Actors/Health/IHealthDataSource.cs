using System;

namespace Content.Actors.Health
{
    public interface IHealthDataSource
    {
        public float GetHealth01();
        public event Action HealthChanged;
    }
}
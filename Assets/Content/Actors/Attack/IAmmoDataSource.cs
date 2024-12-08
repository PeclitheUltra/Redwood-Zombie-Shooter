using System;

namespace Content.Actors.Attack
{
    public interface IAmmoDataSource
    {
        public int GetAmmo();
        public event Action AmmoChanged;
    }
}
using Content.Sounds;
using UnityEngine;

namespace Content.Actors.Attack
{
    public class AmmoPack : MonoBehaviour, IPickupable
    {
        [SerializeField] private int _ammoAmount = 15;
        
        public void Pickup(Player.Player player)
        {
            player.AddAmmo(_ammoAmount);
            SoundPlayer.PlayGlobalOneShot(ESoundType.AmmoPickup);
            Destroy(gameObject);
        }
    }
}

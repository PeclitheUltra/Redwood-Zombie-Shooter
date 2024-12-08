using UnityEngine;

namespace Content.Actors.Player
{
    internal interface IPlayerInput
    {
        public Vector2 GetMovementInput();
        public bool GetPressingShoot();
    }
}
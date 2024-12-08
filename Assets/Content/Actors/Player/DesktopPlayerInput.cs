using UnityEngine;

namespace Content.Actors.Player
{
    public class DesktopPlayerInput : IPlayerInput
    {
        public Vector2 GetMovementInput()
        {
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        public bool GetPressingShoot()
        {
            return Input.GetKey(KeyCode.Space);
        }
    }
}
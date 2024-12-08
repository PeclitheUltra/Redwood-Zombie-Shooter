using System;
using Content.Actors.Attack;
using Reflex.Attributes;
using UnityEngine;

namespace Content.Actors.Player
{
    public class Player : Actor, IAmmoDataSource
    {
        public event Action AmmoChanged;
        private ActorConfigDatabase _database;
        private IPlayerInput _input;
        private IAmmoDataSource _ammoDataSource;

        [Inject]
        private void Construct(ActorConfigDatabase database, IPlayerInput input)
        {
            _input = input;
            _database = database;
        }

        private void Awake()
        {
            PullActorSettingsFromConfig(_database.Player);
            if (_attack is IAmmoDataSource ammoDataSource)
            {
                _ammoDataSource = ammoDataSource;
                _ammoDataSource.AmmoChanged += HandleAmmoChanged;
            }
        }

        private void HandleAmmoChanged()
        {
            AmmoChanged?.Invoke();
        }

        private void Update()
        {
            var movementInput = _input.GetMovementInput();
            var attackInput = _input.GetPressingShoot();
            if (attackInput)
            {
                _attack.TryAttack();
                State = EActorState.Attacking;
            }
            else if (movementInput.x != 0)
            {
                _movement.Move(movementInput.x);

                transform.localScale = movementInput.x > 0 ? new Vector3(1, 1, 1) : new Vector3(-1,1, 1);
                State = EActorState.Moving;
            }
            else
            {
                State = EActorState.Idle;
            }

        }

        public int GetAmmo()
        {
            if (_ammoDataSource != null)
                return _ammoDataSource.GetAmmo();
            return -1;
        }

        public void AddAmmo(in int ammoAmount)
        {
            if(_attack is IAmmoReceiver ammoReceiver)
                ammoReceiver.AddAmmo(ammoAmount);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IPickupable>(out var pickupable))
            {
                pickupable.Pickup(this);
            }
        }
    }
}
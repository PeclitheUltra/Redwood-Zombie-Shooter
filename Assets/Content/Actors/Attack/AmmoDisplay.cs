using TMPro;
using UnityEngine;

namespace Content.Actors.Attack
{
    public class AmmoDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _ammoCounter;
        private IAmmoDataSource _ammoDataSource;

        public void SetSource(IAmmoDataSource ammoDataSource)
        {
            _ammoDataSource = ammoDataSource;
            _ammoDataSource.AmmoChanged += UpdateDisplay;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            _ammoCounter.text = _ammoDataSource.GetAmmo().ToString();
        }
    }
}

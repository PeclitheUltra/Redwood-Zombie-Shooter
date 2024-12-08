using System;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Actors.Health
{
    public class HealthDisplay : MonoBehaviour
    {
        private IHealthDataSource _healthDataSource;
        [SerializeField] private Image _fill;
        
        private void Start()
        {
            _healthDataSource = GetComponentInParent<IHealthDataSource>();
            _healthDataSource.HealthChanged += UpdateDisplay;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            _fill.fillAmount = _healthDataSource.GetHealth01();
        }
    }
}

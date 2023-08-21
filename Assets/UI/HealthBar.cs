using System;
using Actor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private TextMeshProUGUI hpText;
        [SerializeField] private Slider slider;

        private void Start()
        {
            DisplayHp();
        }

        private void Update()
        {
            DisplayHp();
        }

        private void DisplayHp()
        {
            hpText.text = character.GetHp().ToString();
            slider.value = (float)character.GetHp() / character.GetMaxHp();
        }
    }
}
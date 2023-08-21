using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Actor
{
    public class Monster : Character
    {
        [SerializeField] private Character player;
        [SerializeField] private int damageAmout;
        [SerializeField] private TextMeshProUGUI countdown;
        private int totalCountdown;

        private void Start()
        {
            StartCoroutine(DoTimer());
        }

        private void CountDownNumber(int secondLeft)
        {
            countdown.text = secondLeft.ToString();
        }

        private void UpdateCountdownNumber()
        {
            countdown.text = totalCountdown.ToString();
        }
        
        IEnumerator DoTimer(float timer = 1f)
        {
            while (true)
            {
                totalCountdown = 3;
                while (totalCountdown >= 0)
                {
                    CountDownNumber(totalCountdown);
                    yield return new WaitForSeconds(timer);
                    totalCountdown--;
                    Debug.Log("Counting!");
                }
                player.Damage(damageAmout);
                UpdateCountdownNumber();
            }
        }
    }
}
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
        [SerializeField] private Coroutine attackCoroutine;
        private float totalCountdown;
        private bool isStunned = false;
        private bool isCouroutinePaused = false;

        private void Start()
        {
            attackCoroutine = StartCoroutine(AttackBehaviour(3));
        }

        private void CountDownNumber(float secondLeft)
        {
            countdown.text = secondLeft.ToString();
        }

        private void UpdateCountdownNumber()
        {
            countdown.text = totalCountdown.ToString();
        }

        public void SetIsStunned(bool isStunned)
        {
            if (isStunned)
            {
                StopCoroutine(attackCoroutine);
            }
            else
            {
                attackCoroutine = StartCoroutine(AttackBehaviour(totalCountdown));
            }
        }

        IEnumerator AttackBehaviour(float startingCountdown)
        {
            while (true)
            {
                if (!isCouroutinePaused)
                {
                    totalCountdown = startingCountdown;
                    while (totalCountdown >= 0)
                    {
                        CountDownNumber(totalCountdown);
                        yield return new WaitForSeconds(0.1f);
                        totalCountdown = totalCountdown - 0.1f;
                        Debug.Log("Counting!");
                    }

                    player.Damage(damageAmout);
                    UpdateCountdownNumber();
                }

            }
        }


    }
}
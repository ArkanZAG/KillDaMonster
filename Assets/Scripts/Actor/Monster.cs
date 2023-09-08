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
        [SerializeField] private TextMeshPro countdown;
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
                Debug.Log("stunning!");
                StopCoroutine(attackCoroutine);
            }
            else
            {
                Debug.Log("Stun Finish");
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
                        yield return new WaitForEndOfFrame();
                        totalCountdown = totalCountdown - Time.deltaTime;
                        countdown.text = totalCountdown.ToString("F1");
                    }
                    player.Damage(damageAmout);
                    UpdateCountdownNumber();
                }
                if (isStunned)
                {
                    yield break;
                }

            }
        }


    }
}
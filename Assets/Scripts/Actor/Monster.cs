using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Actor
{
    public class Monster : Character
    {
        [SerializeField] private Character player;
        [FormerlySerializedAs("damageAmout")] [SerializeField] private int damageAmount;
        [SerializeField] private TextMeshPro countdown;
        [SerializeField] private Coroutine attackCoroutine;
        [SerializeField] private float startingCountdown = 3f;
        private float totalCountdown;
        private bool isStunned = false;
        private bool isCouroutinePaused = false;

        private void Start()
        {
            attackCoroutine = StartCoroutine(AttackBehaviour());
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
                attackCoroutine = StartCoroutine(AttackAfterStunBehaviour());
            }
        }

        IEnumerator AttackBehaviour()
        {
            while (true)
            {
                totalCountdown = startingCountdown;
                while (totalCountdown >= 0)
                {
                    yield return new WaitForEndOfFrame();
                    totalCountdown = totalCountdown - Time.deltaTime;
                    countdown.text = totalCountdown.ToString("f1");
                }
                player.Damage(damageAmount);
            }
        }
        
        IEnumerator AttackAfterStunBehaviour()
        {
            while (totalCountdown >= 0)
            {
                yield return new WaitForEndOfFrame();
                totalCountdown = totalCountdown - Time.deltaTime;
                countdown.text = totalCountdown.ToString("f1");
            }
            player.Damage(damageAmount);
           attackCoroutine = StartCoroutine(AttackBehaviour());
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Actor;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackMechanic : MonoBehaviour
{
    [SerializeField] private Button attackButton;
    [SerializeField] private Character monster;
    [SerializeField] private int damageAmount;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private TextMeshProUGUI cooldownText;
    [SerializeField] private float cooldown = 2f;
    private float currentCooldown;
    
    private void Start()
    {
        cooldownText.gameObject.SetActive(false);
        attackButton.onClick.AddListener(Attack);
    }

    private IEnumerator CooldownAttack()
    {
        currentCooldown = cooldown;
        attackButton.interactable = false;
        cooldownText.gameObject.SetActive(true);
        while (currentCooldown >= 0)
        {
            yield return new WaitForEndOfFrame();
            currentCooldown = currentCooldown - Time.deltaTime;
            cooldownText.text = currentCooldown.ToString("f1");
        }
        attackButton.interactable = true;
        cooldownText.gameObject.SetActive(false);
    }

    private void Attack()
    {
        monster.Damage(damageAmount);
        StartCoroutine(CooldownAttack());
        playerAnimator.SetTrigger("Attack");
        Debug.Log("Attacking!");
    }
}

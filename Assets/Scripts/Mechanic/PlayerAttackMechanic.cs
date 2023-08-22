using System;
using System.Collections;
using System.Collections.Generic;
using Actor;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackMechanic : MonoBehaviour
{
    [SerializeField] private Button attackButton;
    [SerializeField] private Character monster;
    [SerializeField] private int damageAmount;

    private void Start()
    {
        attackButton.onClick.AddListener(Attack);
    }

    private IEnumerator CooldownAttack()
    {
        float cooldown = 1f;

        attackButton.interactable = false;

        yield return new WaitForSeconds(cooldown);

        attackButton.interactable = true;
    }

    private void Attack()
    {
        monster.Damage(damageAmount);
        StartCoroutine(CooldownAttack());
        Debug.Log("Attacking!");
    }
    
    
    

    
}

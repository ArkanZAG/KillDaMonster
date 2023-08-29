using System;
using System.Collections;
using System.Collections.Generic;
using Actor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStunMechanic : MonoBehaviour
{
    [SerializeField] private Button stunButton;
    [SerializeField] private Monster monster;

    private void Start()
    {
        stunButton.onClick.AddListener(Stun);
    }

    private void Stun()
    {
        monster.SetIsStunned(true);
    }

    
}

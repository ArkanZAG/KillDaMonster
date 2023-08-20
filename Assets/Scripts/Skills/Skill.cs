using System.Collections;
using System.Collections.Generic;
using Actor;
using DefaultNamespace;
using UnityEngine;

public class Skill
{
    
    [SerializeField] private float cooldown;
    private float currentCooldown;

    public virtual void DoSkill(Character target)
    {
       
    }
    
}

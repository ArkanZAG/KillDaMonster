using System.Collections;
using System.Collections.Generic;
using Actor;
using Mono.Cecil;
using Unity.VisualScripting;
using UnityEngine;

public class DotSkill : Skill
{
    [SerializeField] private int damage;
    [SerializeField] private float dotInternval;
    [SerializeField] private float dotDuration;
    [SerializeField] private Character target;

    private IEnumerator DoT(Character target)
    {
        float elapsedTime = 0f;

        while (elapsedTime < dotDuration)
        {
            target.Damage(damage);
            yield return new WaitForSeconds(dotInternval);
            elapsedTime += dotInternval;
        }
    }

    private void Start()
    {
        
    }

    public void Damage(int amount)
    {
        target.Damage(damage);
    }
}

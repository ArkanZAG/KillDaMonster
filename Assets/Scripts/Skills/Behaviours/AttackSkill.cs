using Actor;
using UnityEngine;

namespace DefaultNamespace
{
    public class AttackSkill : Skill
    {
        private int damage;

        public override void DoSkill(Character target)
        {
            target.Damage(damage);
        }
    }
}
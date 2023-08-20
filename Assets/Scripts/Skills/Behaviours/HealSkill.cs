using Actor;

namespace DefaultNamespace
{
    public class HealSkill : Skill
    {
        private int healAmount;

        public override void DoSkill(Character target)
        {
            target.Heal(healAmount);
        }
    }
}
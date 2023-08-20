using UnityEngine;

namespace Actor
{
    public class Character : MonoBehaviour
    {
        private Skill[] skill;
        [SerializeField] private int hp;
        [SerializeField] private int maxHp;

        public void Damage(int damage)
        {
            hp = hp - damage;
        }

        public void Heal(int heal)
        {
            hp = hp + heal;
        }
    }
}
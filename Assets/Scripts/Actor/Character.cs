using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Actor
{
    public class Character : MonoBehaviour
    {
        private Skill[] skill;
        [SerializeField] private int hp;
        [SerializeField] private int maxHp;
        [SerializeField] private bool isBlocked = false;
        [SerializeField] private bool isStuned = false;

        public void Damage(int damage)
        {
            if (!isBlocked)
            {
                hp = hp - damage;
                transform.DOShakePosition(0.2f, Vector3.right * 10f);
            }
        }

        public void Heal(int heal)
        {
            hp = hp + heal;
            if (hp >= maxHp)
            {
                hp = maxHp;
            }
        }

        public void DotSkill()
        {
            
        }

        public void Stun()
        {
            if (!isStuned)
            {
                
            }
        }

        public int GetHp()
        {
            return hp;
        }

        public int GetMaxHp()
        {
            return maxHp;
        }
        
        public void SetBlockState(bool block)
        {
            isBlocked = block;
        }
        
        
    }
}
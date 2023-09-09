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
        [SerializeField] private ParticleSystem blockParticle;
        [SerializeField] private ParticleSystem damageParticle;
        [SerializeField] private AudioSource damageAudio;
        [SerializeField] private AudioClip damageClip;
        [SerializeField] private AudioClip healClip;

        public void Damage(int damage)
        {
            if (!isBlocked)
            {
                damageParticle.Stop();
                hp = hp - damage;
                if (hp <= 0)
                {
                    OnDeath();
                }
                transform.DOShakePosition(0.2f, Vector3.right * 1f);
                damageParticle.Play();
                damageAudio.PlayOneShot(damageClip);
            }
            else
            {
                blockParticle.Stop();
                blockParticle.Play();
            }
        }

        protected virtual void OnDeath()
        {
            
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
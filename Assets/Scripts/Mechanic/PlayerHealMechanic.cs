using System.Collections;
using Actor;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Mechanic
{
    public class PlayerHealMechanic : MonoBehaviour
    {
        [SerializeField] private Button healButton;
        [SerializeField] private Character player;
        [SerializeField] private int healAmount;
        [SerializeField] private Animator playerAnimator;

        private void Start()
        {
            healButton.onClick.AddListener(Heal);
        }

        private IEnumerator CooldownHeal()
        {
            float cooldown = 5f;

            healButton.interactable = false;
            
            player.transform.localScale = new Vector3(1, 1.3f, 1);
            player.transform.DOScale(Vector3.one, 0.3f);

            yield return new WaitForSeconds(cooldown);

            healButton.interactable = true;
        }
        
        private void Heal()
        {
            player.Heal(healAmount);
            StartCoroutine(CooldownHeal());
            playerAnimator.SetTrigger("Heal");
            Debug.Log("Healing!");
        }
    }
}
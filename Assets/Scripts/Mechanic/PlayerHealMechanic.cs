using System.Collections;
using Actor;
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

        private void Start()
        {
            healButton.onClick.AddListener(Heal);
        }

        private IEnumerator CooldownHeal()
        {
            float cooldown = 5f;

            healButton.interactable = false;

            yield return new WaitForSeconds(cooldown);

            healButton.interactable = true;
        }
        
        

        private void Heal()
        {
            player.Heal(healAmount);
            StartCoroutine(CooldownHeal());
            Debug.Log("Healing!");
        }
    }
}
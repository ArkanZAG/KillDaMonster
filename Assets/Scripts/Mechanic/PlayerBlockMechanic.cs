using System;
using System.Collections;
using Actor;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


namespace Mechanic
{
    public class PlayerBlockMechanic : MonoBehaviour
    {
        [SerializeField] private Button blockButton;
        [SerializeField] private Character player;
        [SerializeField] private Image imageColor;

        private void Start()
        {
            blockButton.onClick.AddListener(DoBlock);
        }

        private IEnumerator BlockCoroutine()
        {
            float blockDuration = 2f;
            
            player.SetBlockState(true);

            blockButton.interactable = false;
            
            player.transform.localScale = Vector3.one * 1.2f;
            player.transform.DOScale(Vector3.one, 0.3f);
            
            imageColor.color = Color.yellow;

            yield return new WaitForSeconds(blockDuration);
            
            player.SetBlockState(false);

            blockButton.interactable = true;
            
            imageColor.color = Color.white;
        }

        private void DoBlock()
        {
            StartCoroutine(BlockCoroutine());
        }
        
       
    }
}
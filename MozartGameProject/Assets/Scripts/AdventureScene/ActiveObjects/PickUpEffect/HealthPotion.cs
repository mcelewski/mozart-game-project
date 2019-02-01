using System;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
   [SerializeField] private HealthBarBehaviour heathBar;
   [SerializeField] private PlayerLifeTime player;
   [SerializeField] private ItemInfo item;
   
   private void Start()
   {
      if (heathBar == null)
      {
         heathBar = FindObjectOfType<HealthBarBehaviour>();
      }
      
      if (player == null)
      {
         player = FindObjectOfType<PlayerLifeTime>();
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (!other.CompareTag("Player")) return;

      item.Print();
      player.SetPoisonStatus(PlayerLifeTime.PlayerPoisonStatus.Healty);
      heathBar.BonusTime(item.amount);
   }
}

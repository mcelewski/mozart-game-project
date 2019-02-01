using System;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
   public uint amount;
   [SerializeField] private HealthBarBehaviour heathBar;
   [SerializeField] private PlayerLifeTime player;
   
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
      
      player.SetPoisonStatus(PlayerLifeTime.PlayerPoisonStatus.Healty);
      heathBar.BonusTime(amount);
   }
}

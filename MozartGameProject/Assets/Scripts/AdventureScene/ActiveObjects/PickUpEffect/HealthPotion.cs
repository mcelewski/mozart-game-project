using System;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
   public uint amount;
   [SerializeField] private HealthBarBehaviour heathBar;

   private void Start()
   {
      if (heathBar == null)
      {
         heathBar = FindObjectOfType<HealthBarBehaviour>();
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (!other.CompareTag("Player")) return;
      
      heathBar.BonusTime(amount);
   }
}

using UnityEngine;

public class HealthPotion : MonoBehaviour
{
   [SerializeField] HealthBarBehaviour heathBar;
   [SerializeField] PlayerLifeTime player;
   [SerializeField] ItemInfo item;
   
   void Start()
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

   void OnTriggerEnter2D(Collider2D other)
   {
      if (!other.CompareTag("Player")) return;

      item.Print();
      player.SetPoisonStatus(PlayerLifeTime.PlayerPoisonStatus.Healty);
      heathBar.BonusTime(item.amount);
   }
}

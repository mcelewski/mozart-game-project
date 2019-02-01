using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPotion : MonoBehaviour
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
      
        player.SetPoisonStatus(PlayerLifeTime.PlayerPoisonStatus.Poisoned);
        heathBar.DecrementTime(amount);
    }
}

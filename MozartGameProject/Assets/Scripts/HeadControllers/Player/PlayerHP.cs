using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public enum PlayerPoisonStatus
    {
        Healty,
        Poisoned
    }
    
    private float playerLifetime = 100;

    public PlayerPoisonStatus poisonedStatus = PlayerPoisonStatus.Healty;

    public float GetPlayerHP()
    {
        return playerLifetime;
    }

    public void SetPlayerHP(float amount)
    {
        if (amount < 20)
        {
            playerLifetime += amount;
        }
    }

    bool IsPlayerAlive()
    {
        bool alive = false || (playerLifetime > 1 && poisonedStatus == PlayerPoisonStatus.Healty ||
                               playerLifetime > 1 && poisonedStatus == PlayerPoisonStatus.Poisoned);

        return alive;
    }

    private void Update()
    {
        if (!IsPlayerAlive())
        {
            Debug.Log("Mozart gleba ;)");
        }
    }
}

using UnityEngine;

public class PlayerLifeTime : MonoBehaviour
{
    [SerializeField] private float playerLifetime = 100;
    [SerializeField] private PlayerPoisonStatus poisonedStatus = PlayerPoisonStatus.Healty;
    public float GetPlayerTime()
    {
        return playerLifetime;
    }

    public bool IsHealty()
    {
        return poisonedStatus == PlayerPoisonStatus.Healty;
    }

    public PlayerPoisonStatus GetPlayerStatus()
    {
        return poisonedStatus;
    }

    public void SetPoisonStatus(PlayerPoisonStatus status)
    {
        poisonedStatus = status;
    }
    
    public enum PlayerPoisonStatus
    {
        Healty,
        Poisoned
    }
}

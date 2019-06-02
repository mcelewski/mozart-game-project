using UnityEngine;

public class HealthBarBehaviour : MonoBehaviour
{
    public float hpTimer = .1f;
    public float maxTime;
    public float timeCalc = 10f;
    [SerializeField] float extraPenaltyTime;
    public bool beginPoison;
    public HealthInfoChange infoChange;
    [SerializeField] PlayerLifeTime player;
    public PlayerDeatchUI dead;

    void Start()
    {
        CheckReferences();
        SetBar();
    }

    public void CheckPoison()
    {
        //Debug.Log("calc: " + timeCalc);
        if (beginPoison && hpTimer > 0)
        {
            hpTimer -= (Time.deltaTime * extraPenaltyTime)/ timeCalc;
            infoChange.SetHeart(hpTimer);
        }
    }
    
    bool IsPlayerAlive()
    {
        return hpTimer > 1f;
    }

    void Update()
    {
        if (!IsPlayerAlive())
        {
            player.SetPoisonStatus(PlayerLifeTime.PlayerPoisonStatus.Dead);
            dead.OnUIShow();
        }
    }
    
    public void BonusTime(float xTime)
    {
        hpTimer += xTime;
        SetCalcTime(10);
    }
    
    public void PenaltyTime(float time)
    {
        FasterTimeFor(ref time);
        SetCalcTime(1);
    }
    
    public void SetCalcTime(float calc)
    {
        timeCalc = calc;
    }

    //TODO fixes needed
    void FasterTimeFor(ref float time)
    {
        extraPenaltyTime = time;
        while (extraPenaltyTime > 0 && !player.IsHealty())
        {
            extraPenaltyTime -= Time.deltaTime;
            hpTimer -= Time.deltaTime / 1f;
        }

        Debug.Log("out");
        SetCalcTime(10);
    }

    void SetBar()
    {
        SetMaxTime();
        ResetTimer();
        ReadyToPoison();
    }
    
    void SetMaxTime()
    {
        maxTime = player.GetPlayerTime();
    }
    
    void ResetTimer()
    {
        hpTimer = maxTime;
    }

    void CheckReferences()
    {
        if (infoChange == null)
            infoChange = FindObjectOfType<HealthInfoChange>();

        if (player == null)
            player = FindObjectOfType<PlayerLifeTime>();
    }

    #region Booleans

    public void PausePoison()
    {
        beginPoison = false;
    }
    
    public void ResumePoison()
    {
        beginPoison = true;
    }
    
    void ReadyToPoison()
    {
        beginPoison = true;
    }

    #endregion
}

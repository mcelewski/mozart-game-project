using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBehaviour : MonoBehaviour
{
    public float hpTimer = .1f;
    public float maxTime;
    public float timeCalc = 1f;
    public bool beginPoison;
    public HealthInfoChange infoChange;
    [SerializeField] private PlayerLifeTime player;

    private void Start()
    {
        SetBar();
    }

    public void CheckPoison()
    {
        if (beginPoison && hpTimer > 0)
        {
            hpTimer -= Time.deltaTime / timeCalc;
            infoChange.SetHeart(hpTimer);
        }
    }
    
    bool IsPlayerAlive()
    {
        return hpTimer > 1f;
    }

    void SetProperHeartz()
    {
        
    }

    private void Update()
    {
        if (!IsPlayerAlive())
        {
            Debug.Log("Mozart gleba ;)");
        }
    }
    
    public void BonusTime(float xTime)
    {
        hpTimer += xTime;
    }
    
    public void DecrementTime(float xTime)
    {
        hpTimer -= xTime;
    }
    
    public void SetCalcTime(float calc)
    {
        timeCalc = calc;
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

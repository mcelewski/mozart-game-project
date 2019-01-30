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
    [SerializeField] private PlayerHP player;

    private void Start()
    {
        SetBar();
    }
    
    public void PausePoison()
    {
        beginPoison = false;
    }
    
    public void ResumePoison()
    {
        beginPoison = true;
    }

    public void RestartPoison()
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
    
    public void BonusTime(float xTime)
    {
        hpTimer += xTime;
    }
    
    public void DecrementTime(float xTime)
    {
        hpTimer -= xTime;
    }

    /// <summary>
    /// Decrease speed of timeleft
    /// </summary>
    /// <param name="calc"></param>
    public void SetCalcTime(float calc)
    {
        timeCalc = calc;
    }

    void SetBar()
    {
        SetMaxTime();
        ReSetTimer();
        ReadyToPoison();
    }
    
    void SetMaxTime()
    {
        maxTime = player.GetPlayerHP();
    }
    
    void ReSetTimer()
    {
        hpTimer = maxTime;
    }

    void ReadyToPoison()
    {
        beginPoison = true;
    }
}

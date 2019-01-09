using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBehaviour : MonoBehaviour
{
    public float hpTimer;
    public float maxTime;
    public bool beginPoison = false;
    public HealthInfoChange infoChange;

    public void SetBar()
    {
        SetMaxTime();
        ReSetTimer();
        StartCoroutine(ReadyToPoison());
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
            hpTimer -= Time.deltaTime;
            infoChange.SetHeart(hpTimer);
        }
    }

    void SetMaxTime()
    {
        maxTime = PlayerHP.GetMaxHp();
    }
    
    void ReSetTimer()
    {
        hpTimer = maxTime;
    }
    
    IEnumerator ReadyToPoison()
    {
        yield return new WaitForSeconds(3f);

        beginPoison = true;
    }
}

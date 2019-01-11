using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthInfoChange : MonoBehaviour 
{
    /// <summary>
    /// Sprite (health status) holded in max -> min
    /// </summary>
    public Sprite[] healthStatus = new Sprite[6];
    public List<GameObject> healthHearts = new List<GameObject>();

    private static int index;
    
    private void Start()
    {
        if (healthStatus == null || healthHearts == null) Debug.Log("No health sprites added");
    }

    public void SetHeart(float amount)
    {
        if (amount > 80f && amount < 100f)
        {
            StatHealth( 4, amount);
        }
        else if (amount > 60f && amount < 80f)
        {
            StatHealth( 3, amount);
        }
        else if (amount > 40f && amount < 60f)
        {
            StatHealth( 2, amount);
        }
        else if (amount > 20f && amount < 40f)
        {
            StatHealth( 1, amount);
        }
        else if (amount > 0f && amount < 5f)
        {
            StatHealth( 0, amount);
        }
    }

    void StatHealth(int index, float amount)
    {
        var healt = healthHearts.ElementAt(index).GetComponent<SpriteRenderer>();

        if (IsHpFull(amount))
        {
           // Debug.Log("full");
            healt.sprite = healthStatus[0];
        }
        else if (IsHpAlmostFull(amount))
        {
           //Debug.Log("almost full");
            healt.sprite = healthStatus[1];
        }
        else if (IsHpCloseToHalf(amount))
        {
            //Debug.Log("close to half");
            healt.sprite = healthStatus[2];
        }
        else if (IsHpCloseToEmpty(amount))
        {
            //Debug.Log("close to empty");
            healt.sprite = healthStatus[3];
        }
        else if (IsHpAlmostEmpty(amount))
        {
            //Debug.Log("almost empty");
            healt.sprite = healthStatus[4];
        }
        else if (IsHpEmpty(amount))
        {
            //Debug.Log("empty");
            healt.sprite = healthStatus[5];
        }
    }

    #region Booleans checker

    
    bool IsHpFull(float amount)
    {
        bool x = ((amount <= 100f) && (amount >= 97f)) || ((amount <= 80f) && (amount >= 77f)) ||
                 ((amount <= 60f) && (amount >= 57f)) || ((amount <= 40f) && (amount >= 37f)) ||
                 ((amount <= 20f) && (amount >= 17f));
        return x;
    }

    bool IsHpAlmostFull(float amount)
    {
        bool x = ((amount <= 96f) && (amount >= 93f)) || ((amount <= 76f) && (amount >= 73f)) ||
                 ((amount <= 56f) && (amount >= 53f)) || ((amount <= 36f) && (amount >= 33f)) ||
                 ((amount <= 16f) && (amount >= 13f));
        return x;
    }
    bool IsHpCloseToHalf(float amount)
    {
        bool x = ((amount <= 93f) && (amount >= 90f)) || ((amount <= 73f) && (amount >= 70f)) ||
                 ((amount <= 53f) && (amount >= 50f)) || ((amount <= 33f) && (amount >= 30f)) ||
                 ((amount <= 13f) && (amount >= 10f));
        return x;
    }
    bool IsHpCloseToEmpty(float amount)
    {
        bool x = ((amount <= 90f) && (amount >= 87f)) || ((amount <= 70f) && (amount >= 67f)) ||
                 ((amount <= 50f) && (amount >= 47f)) || ((amount <= 30f) && (amount >= 27f)) ||
                 ((amount <= 10f) && (amount >= 7f));
        return x;
    }
    bool IsHpAlmostEmpty(float amount)
    {
        bool x = ((amount <= 87f) && (amount >= 83f)) || ((amount <= 67f) && (amount >= 63f)) ||
                 ((amount <= 47f) && (amount >= 43f)) || ((amount <= 27f) && (amount >= 23f)) ||
                 ((amount <= 7f) && (amount >= 3f));
        return x;
    }
    bool IsHpEmpty(float amount)
    {
        bool x = ((amount <= 83f) && (amount >= 80f)) || ((amount <= 63f) && (amount >= 60f)) ||
                 ((amount <= 43f) && (amount >= 40f)) || ((amount <= 23f) && (amount >= 20f)) ||
                 ((amount <= 3f) && (amount >= 0f));
        return x;
    }

    #endregion
}

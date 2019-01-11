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
    private int statIndex = 0;
    private float newTime = 100f;

    private static int index;
    
    private void Start()
    {
        if (healthStatus == null || healthHearts == null) Debug.Log("No health sprites added");
    }

    public void SetHeart(float amount)
    {
        if (amount > 100f)
        {
            StatHealth( 4, amount);
        }
        else if (amount > 80f && amount < 100f)
        {
            StatHealth( 3, amount);
        }
        else if (amount > 60f && amount < 80f)
        {
            StatHealth( 2, amount);
        }
        else if (amount > 40f && amount < 60f)
        {
            StatHealth( 1, amount);
        }
        else if (amount > 20f && amount < 40f)
        {
            StatHealth( 0, amount);
        }
    }

    void StatHealth(int index, float amount)
    {
        var healt = healthHearts.ElementAt(index).GetComponent<SpriteRenderer>();

        if ((amount >= 98f && amount <= 96f))
        {
            healt.sprite = healthStatus[0];
        }
        else if (amount)
        {
            healt.sprite = healthStatus[0];
        }
        else if (amount)
        {
            healt.sprite = healthStatus[0];
        }
        else if (amount)
        {
            healt.sprite = healthStatus[0];
        }
        else if (amount)
        {
            healt.sprite = healthStatus[0];
        }
        else if (amount)
        {
            healt.sprite = healthStatus[0];
        }
    }
}

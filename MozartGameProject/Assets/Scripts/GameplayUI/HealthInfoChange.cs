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

    public static int index;
    private void Start()
    {
        if (healthStatus == null || healthHearts == null) Debug.Log("No health sprites added");

        IndexDefault();
    }

    void IndexDefault()
    {
        index = healthStatus.Length-1;
    }

    public void SetHeart(float amount)
    {
        if (amount > 80f)
        {
            IndexDefault();
            FifthHealth(amount);
        }
        else if (amount > 60f && amount < 80f)
        {
            IndexDefault();
            FourthHealth(amount);
        }
        else if (amount > 40 && amount < 60)
        {
            ThirdHealth(amount);
        }
        else if (amount > 40 && amount < 20)
        {
            SecondHealth(amount);
        }
        else if (amount > 0 && amount < 20)
        {
            FirstHealth(amount);
        }
        
    }

    void FirstHealth(float amount)
    {
       
    }
    void SecondHealth(float amount)
    {
    }
    void ThirdHealth(float amount)
    {
    }
    void FourthHealth(float amount)
    {
    }
    void FifthHealth(float amount)
    {
        Debug.Log("InFirst" + healthStatus.Length);
        
        var healt = healthHearts.ElementAt(4).GetComponent<SpriteRenderer>();
        if (amount % 2.0f == 0)
            healt.sprite = healthStatus[index];
            index--;
    }
    
}

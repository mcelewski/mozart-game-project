using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthInfoChange : MonoBehaviour 
{
    /// <summary>
    /// Sprite (health status) holded in max -> min
    /// </summary>
    public Sprite[] healthStatus = new Sprite[6];
    public Dictionary<int, Sprite> healthHearts = new Dictionary<int, Sprite>();

    private void Start()
    {
        if (healthStatus == null || healthHearts == null) Debug.Log("No health sprites added");
    }

    void GetAllHearts()
    {
        var hpBar = GameObject.Find("HealthBar").GetComponent<GameObject>();

        for (int i = 0; i < hpBar.transform.childCount; i++)
        {
            healthHearts.Add(i,hpBar.GetComponentInChildren<Sprite>());
        }
    }
}

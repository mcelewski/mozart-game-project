using System;
using UnityEngine;
using UnityEngine.UI;

public class SetPoint : MonoBehaviour
{
    public Text points;
    public int PointToSet { get; set; }

    void Start()
    {
        points.text = String.Concat("Score: " + PointToSet);
    }

    public void UpdateIfNeed(int amount)
    {
        PointToSet += amount;
        points.text = String.Concat("Score: " + PointToSet);
    }
}

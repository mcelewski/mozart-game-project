using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPoints : MonoBehaviour
{
    public Text score;
    public float Score { get; set; }

    private void Update()
    {
        RefreshScore();
    }
    private void RefreshScore()
    {
        score.text = Score.ToString();
    }
}

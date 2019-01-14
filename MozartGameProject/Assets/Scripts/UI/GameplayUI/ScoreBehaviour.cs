using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour
{
    public Text actualScore;
    public Text scoreTarget;

    private static int score;
    private int target;

    private void Start()
    {
        DefaultScore();
        //DefaultTarget();
        SetScoreTarget(10);
    }

    void DefaultScore()
    {
        actualScore.text = score.ToString();
    }

    void DefaultTarget()
    {
        scoreTarget.text = target.ToString();
    }

    void SetScoreAmount()
    {
        actualScore.text = score.ToString();
    }

    void SetTargetAmount()
    {
        scoreTarget.text = target.ToString();
    }

    public void SetActualScore(int amount)
    {
        if (amount > 0 && amount < 5)
        {
            score += amount;
            SetScoreAmount();
        }
    }

    public void SetScoreTarget(int amount)
    {
        if (amount > 0 && amount < 100)
        {
            target = amount;
            SetTargetAmount();
        }
    }
}

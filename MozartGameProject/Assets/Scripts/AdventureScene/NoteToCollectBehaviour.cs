﻿using UnityEngine;

public class NoteToCollectBehaviour : MonoBehaviour
{
    public int itemAmount = 1;

    public ScoreBehaviour score;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        score.SetActualScore(itemAmount);
        gameObject.SetActive(false);
    }
}

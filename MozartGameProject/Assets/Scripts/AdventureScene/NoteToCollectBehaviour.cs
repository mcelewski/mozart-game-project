using UnityEngine;

public class NoteToCollectBehaviour : MonoBehaviour
{
    public int itemAmount = 1;

    public ScoreBehaviour score;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        if(!IsScoreNullReference())
            score.SetActualScore(itemAmount);
        else
        {
            score = FindObjectOfType<ScoreBehaviour>();
            score.SetActualScore(itemAmount);
        }

        gameObject.SetActive(false);
    }

    bool IsScoreNullReference()
    {
        return score == null;
    }
}

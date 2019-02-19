using UnityEngine;

public class SameNoteDetect : MonoBehaviour
{
    [SerializeField] SetPoint poiting;
    public void CheckIndex(int first, int second)
    {
        Debug.Log("Check index");
        if (first == second)
        {
            poiting.PointToSet += 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] NotesInfo info;
    [SerializeField] SetPoint setPoint;
    void Start()
    {
        info.SetInfo();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Finish")) return;

        setPoint.UpdateIfNeed(0);
        Debug.Log("Entered: " + info.item.id);
    }

    void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Finish")) return;
        
        if(info.isWhite)
            setPoint.UpdateIfNeed(1);
        if(!info.isWhite)
            setPoint.UpdateIfNeed(3);
        Debug.Log("Stay: " + info.item.id);
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Finish")) return;
        
        setPoint.UpdateIfNeed(0);
        Debug.Log("Exit: " + info.item.id);
    }
}

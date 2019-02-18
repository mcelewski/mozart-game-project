using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] NotesInfo info;
    void Start()
    {
        info.SetInfo();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Finish")) return;

        Debug.Log("Entered: " + info.item.id);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("sadsadsadsa");
    }
}

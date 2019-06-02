using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingSenderEvent : MonoBehaviour
{
    public static event Action<int> OnNoteEnter;
    public static event Action<int> OnNoteStay;
    private int _noteID = 0;
    private ItemInfo noteInfo = null;

    private void Awake()
    {
        if(noteInfo == null)
        {
           noteInfo = this.gameObject.GetComponent<ItemInfo>();
        }
    }
    private void Start()
    {
        _noteID = noteInfo.id;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish") && OnNoteEnter != null)
        {
            OnNoteEnter(_noteID);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Finish")  && OnNoteStay != null)
        {
            OnNoteStay(_noteID);
        }
    }
}

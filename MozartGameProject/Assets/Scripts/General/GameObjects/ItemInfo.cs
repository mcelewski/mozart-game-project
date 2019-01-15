using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public string name;
    public int id;
    public ItemInfo item;

    public int GetObjectID()
    {
        return id;
    }
}

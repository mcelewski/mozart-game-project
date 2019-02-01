using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ItemInfo : MonoBehaviour
{
    public string name;
    public ushort id;
    public ushort amount;
    public ItemInfo item;

    public void Print()
    {
        Debug.Log("Item Name: " + name +
                  "\tItem ID: " + id +
                  "\tItem Amount: " + amount);
    }
}

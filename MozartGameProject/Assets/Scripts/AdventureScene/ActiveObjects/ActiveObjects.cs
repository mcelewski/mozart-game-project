using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ItemName", menuName = "Active Objects/Item to use")]
public class ActiveObjects : ScriptableObject
{
    public string description;
    public int ID;
    public Sprite Icon;
}

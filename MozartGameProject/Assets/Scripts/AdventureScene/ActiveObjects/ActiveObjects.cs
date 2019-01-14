using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ItemName", menuName = "ActiveItem")]
public class ActiveObjects : ScriptableObject
{
    public string description;
    public int ID;
    public Sprite Icon;
}

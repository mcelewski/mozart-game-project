﻿using UnityEditor;
using UnityEngine;

[CreateAssetMenu (fileName = "New Dungeon", menuName = "Dungeon to enter")]
public class ActiveDungeon : ScriptableObject
{
    public string name;
    public Sprite icon;

    public void Print()
    {
        Debug.Log("Dungeon name: " + name +
                  "\nDungeon image: " + icon.name + 
                  "\nDungeon image path: " + AssetDatabase.GetAssetPath(icon));
    }
}
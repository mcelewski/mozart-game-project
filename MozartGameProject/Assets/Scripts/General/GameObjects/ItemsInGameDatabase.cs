﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsDatabase", menuName = "Database/Objects in Scene")]
public class ItemsInGameDatabase : ScriptableObject
{
    public List<ItemInfo> ItemsDatabase = new List<ItemInfo>();
    
    public List<ItemInfo> GetDatabase()
    {
        return ItemsDatabase;
    }
}
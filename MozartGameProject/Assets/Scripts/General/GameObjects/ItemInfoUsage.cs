using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoUsage
{
    private ushort id;
    private int minute;
    private int second;
    private bool isUsed;

    public ushort GetID { get { return id; } }
    public int Minute { get { return minute; } }
    public int Second { get { return second; } }
    public bool IsUsed { get { return isUsed; } }
    public ItemInfoUsage(ushort id, DateTime time, bool currentlyUsed)
    {
        this.id = id;
        this.minute = time.Minute;
        this.second = time.Second;
        this.isUsed = currentlyUsed;
    }
    public void SetUsage(ushort id, DateTime time, bool currentlyUsed)
    {
        this.id = id;
        this.minute = time.Minute;
        this.second = time.Second;
        this.isUsed = currentlyUsed;
    }
    /// <summary>
    /// Use this method if item may be enabled to use
    /// </summary>
    public void CurrentlyInUse()
    {
        this.isUsed = true;
    }
    /// <summary>
    /// Use this method if item may be disabled to use
    /// </summary>
    public void CurrneltyNotInUse()
    {
        this.isUsed = false;
    }
}

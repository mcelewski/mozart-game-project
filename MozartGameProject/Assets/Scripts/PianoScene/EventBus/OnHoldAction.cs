using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OnHoldAction : AbstractActions
{
    
    [SerializeField] private float point;
    public SetPoints setPoint;
    List<ItemInfoUsage> KeyInfoUsage = new List<ItemInfoUsage>();
    List<ItemInfoUsage> TriggerInfoUsage = new List<ItemInfoUsage>();
    //private Dictionary<ushort,DateTime> KeyInfo = new Dictionary<ushort, DateTime>();
    //private Dictionary<ushort,DateTime> TriggerInfo = new Dictionary<ushort, DateTime>();
    public int Difficulty
    {
        get { return _difficultyScale; }
        set { _difficultyScale = value; }
    }
    public void CheckData()
    {
        if (KeyInfoUsage.Count != 0 && TriggerInfoUsage.Count != 0)
        {
            foreach (var keyItem in KeyInfoUsage)
            {
                foreach (var triggerItem in TriggerInfoUsage)
                {
                    if (keyItem.GetID == triggerItem.GetID && 
                        (keyItem.IsUsed == AVAIABLE_TO_USE &&
                         triggerItem.IsUsed == AVAIABLE_TO_USE))
                    {
                        if (keyItem.Minute == triggerItem.Minute &&
                           (keyItem.Second == triggerItem.Second - _difficultyScale ||
                           keyItem.Second == triggerItem.Second + _difficultyScale ||
                           keyItem.Second == triggerItem.Second))
                        {
                            // FIXME: add specified poiting
                            setPoint.Score += point;
                            keyItem.CurrneltyNotInUse();
                            triggerItem.CurrneltyNotInUse();
                        }
                    }
                }
            }
        }
    }
    public void ClearDataAfterEndScene()
    {
        KeyInfoUsage.Clear();
        TriggerInfoUsage.Clear();
    }

    //public override Dictionary<ushort, DateTime> GetKeyData()
    //{
    //    return KeyInfo;
    //}

    //public override Dictionary<ushort, DateTime> GetTriggerData()
    //{
    //    return TriggerInfo;
    //}

    //public override void SetKeyData(ushort id)
    //{
    //    if (!KeyInfo.Any(a => a.Key == id))
    //    {
    //        KeyInfo.Add(id, DateTime.Now);
    //    }
    //}

    //public override void SetTriggerData(ushort id)
    //{
    //    if (!TriggerInfo.Any(a => a.Key == id))
    //    {
    //        TriggerInfo.Add(id, DateTime.Now);
    //    }
    //}

    //public override void Remove(ushort key, ushort trigger)
    //{
    //    if (key != 0)
    //    {
    //        KeyInfo.Remove(key);
    //    }
    //    if (trigger != 0)
    //    {
    //        TriggerInfo.Remove(trigger);
    //    }
    //}
    // Start is called before the first frame update

    public void SetKeyData(ushort id)
    {
        if (!KeyInfoUsage.Any(a => a.GetID == id))
        {
            KeyInfoUsage.Add(new ItemInfoUsage(id, DateTime.Now, true));
        }
    }

    public void SetTriggerData(ushort id)
    {
        if (!TriggerInfoUsage.Any(a => a.GetID == id))
        {
            TriggerInfoUsage.Add(new ItemInfoUsage(id, DateTime.Now, true));
        }
    }
    void Start()
    {
        if(setPoint == null)
        {
            throw new NullReferenceException("Missing reference in: " + this.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // FIXME: Only here
        CheckData();
    }
}

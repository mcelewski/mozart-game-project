using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OnPressAction : AbstractActions
{
    [SerializeField] private float point;
    public SetPoints setPoint;
    List<ItemInfoUsage> KeyInfoUsage = new List<ItemInfoUsage>();
    List<ItemInfoUsage> TriggerInfoUsage = new List<ItemInfoUsage>();
    //private Dictionary<ushort, KeyValuePair<DateTime, bool>> KeyInfo = new Dictionary<ushort, KeyValuePair<DateTime, bool>>();
    //private Dictionary<ushort, KeyValuePair<DateTime, bool>> TriggerInfo = new Dictionary<ushort, KeyValuePair<DateTime, bool>>();
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
                           (keyItem.Second <= triggerItem.Second - _difficultyScale ||
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
    //public override Dictionary<ushort, KeyValuePair<DateTime, bool>> GetKeyData()
    //{
    //    return KeyInfo;
    //}
    //public override Dictionary<ushort, KeyValuePair<DateTime, bool>> GetTriggerData()
    //{
    //    return TriggerInfo;
    //}
    //public override void SetKeyData(ushort id)
    //{
    //    if(!KeyInfo.Any(a => a.Key == id))
    //    {
    //        KeyInfo.Add(id, new KeyValuePair<DateTime, bool>(DateTime.Now, false));
    //    }
    //}
    //public override void SetTriggerData(ushort id)
    //{
    //    if(!TriggerInfo.Any(a => a.Key == id))
    //    {
    //        TriggerInfo.Add(id, new KeyValuePair<DateTime, bool>(DateTime.Now, false));
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
    private void Start()
    {
        if(setPoint == null)
        {
            throw new NullReferenceException("Missing reference in: " + this.name);
        }
    }
    private void Update()
    {
        // FIXME: Only here
        CheckData();
    }
}

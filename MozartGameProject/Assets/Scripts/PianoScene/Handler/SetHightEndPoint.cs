using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHightEndPoint : AbstractSetPoints
{
    public Object pointUI;
    public override void SetPoints(float amount)
    {
         Debug.Log("seted points: " + amount);
        // TODO: pointUI invoke change state
    }
}

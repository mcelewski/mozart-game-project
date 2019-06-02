using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLowerPoint : AbstractSetPoints
{
    public Object pointUI;
    public override void SetPoints(float amount)
    {
        Debug.Log("seted points: " + amount);
        // TODO: pointUI invoke change state

    }
}

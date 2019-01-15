using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public void SetLight()
    {
        var light = gameObject.GetComponent<Light>();

        if (!light.enabled)
        {
            light.enabled = true;
        }
    }
    
    public void DisableLight()
    {
        var light = gameObject.GetComponent<Light>();

        if (light.enabled)
        {
            light.enabled = false;
        }
    }
}

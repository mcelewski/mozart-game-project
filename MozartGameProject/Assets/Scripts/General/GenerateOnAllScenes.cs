using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateOnAllScenes : MonoBehaviour 
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}

using UnityEngine;

public class GenerateOnAllScenes : MonoBehaviour 
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}

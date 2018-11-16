using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    public List<GameObject> keyboardObjects;
    public List<KeyCode> keysCodes = new List<KeyCode>();
    public KeyState keyState = KeyState.Up;
    // 1st string nazwa klawisza 2nd gameobject z przypisanym juz dzwiekiem
    public Dictionary<KeyCode, GameObject> noteKeys = new Dictionary<KeyCode, GameObject>();

    public enum KeyState
    {
        Up, Down, Pressed
    }

    void Start()
    {
        for (int i = 0; i < keyboardObjects.Capacity; i++)
        {
            noteKeys.Add(keysCodes[i], keyboardObjects[i]);
        }
        if (noteKeys == null)
        {
            Debug.Log("Something went wrong:");
        }
    }
    void Update()
    {
        DetectKey();
    }
    void DetectKey()
    {

        foreach (var key in keysCodes)
        {
            if (Input.GetKeyDown(key))
            {
                noteKeys[key].GetComponent<AudioSource>().Play();
            }
        }
    }
}
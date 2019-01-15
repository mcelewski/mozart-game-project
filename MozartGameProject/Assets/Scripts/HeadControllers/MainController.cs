using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public ItemsInGameDatabase InGameItemsDB;

    public GameObject MenuUI;
  
    // Start is called before the first frame update
    void Awake()
    {
        if (!MenuUI || !InGameItemsDB) 
        {
            Debug.Log("Missing reference");
        }
        SetStartUIs();
        Print();
    }

    void SetStartUIs()
    {
        if (!IsMenuUIActive())
        {
            MenuUI.SetActive(true);
        }
    }

    bool IsMenuUIActive()
    {
        return MenuUI.activeSelf;
    }

    void Print()
    {
        foreach (var item in InGameItemsDB.ItemsDatabase)
        {
            Debug.Log("ItemId: " + item.id + " Item name: " + item.name);
        }
    }
}

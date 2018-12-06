using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PlayerMove : MonoBehaviour
{
    private MenuUIController menu;

    private void Awake()
    {
        menu = GameObject.Find("Controllers").GetComponentInChildren<MenuUIController>();
    }
    

}

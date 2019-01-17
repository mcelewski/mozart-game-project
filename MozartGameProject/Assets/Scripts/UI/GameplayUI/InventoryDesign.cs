using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDesign : MonoBehaviour
{
    readonly Vector3 startInventoryUIPosition = new Vector3(0,-300,0);
    readonly Vector3 openInventoryPosition = new Vector3(0,300,0);
    
    public float smootchTime = 15f;
    public GameObject Inventory;
    private bool opened;

    private void Awake()
    {
        Inventory.transform.localPosition = startInventoryUIPosition;
    }

    IEnumerator OnClose()
    {
        yield return new WaitForSeconds(.5f);
        Inventory.transform.position =
            Vector3.Lerp(Inventory.transform.position, startInventoryUIPosition, Time.deltaTime / smootchTime);
        opened = false;
    }

    IEnumerator OnOpen()
    {
        yield return new WaitForSeconds(.5f);
        Inventory.transform.position = 
            Vector3.Lerp(Inventory.transform.position,openInventoryPosition,Time.deltaTime / smootchTime);
        opened = true;
    }
    
    public void OpenCloseInventory()
    {
        //TODO fix locations
        if (!opened)
            StartCoroutine(OnOpen());
        else
            StartCoroutine(OnClose());
    }
}

using System.Collections;
using UnityEngine;

public class InventoryDesign : MonoBehaviour
{
    readonly Vector3 startInventoryUIPosition = new Vector3(0,-250,0);
    readonly Vector3 openInventoryPosition = new Vector3(0,-150,0);
    [SerializeField] private InventoryStat inventoryStatus = InventoryStat.Closed;
    public InventorySpace _inventory;
    enum InventoryStat
    {
        Opened,
        Closed
    }
    
    public float smootchTime = 15f;
    public GameObject Inventory;

    void Awake()
    {
        Inventory.transform.localPosition = startInventoryUIPosition;
    }

    IEnumerator OnClose()
    {
        yield return new WaitForSeconds(.5f);
        Inventory.transform.localPosition = startInventoryUIPosition;
           // Vector3.Lerp(Inventory.transform.position, startInventoryUIPosition, Time.deltaTime / smootchTime);
        inventoryStatus = InventoryStat.Closed;
    }

    IEnumerator OnOpen()
    {
        yield return new WaitForSeconds(.5f);
        Inventory.transform.localPosition = openInventoryPosition;
           // Vector3.Lerp(Inventory.transform.position,openInventoryPosition,Time.deltaTime / smootchTime);
        inventoryStatus = InventoryStat.Opened;
    }

    void OnOpenToward()
    {
        Inventory.transform.position = Vector3.MoveTowards(Inventory.transform.position, openInventoryPosition, Time.deltaTime * 10);
        inventoryStatus = InventoryStat.Opened;
    }
    void OnCloseToward()
    {
        Inventory.transform.position = Vector3.MoveTowards(Inventory.transform.position, startInventoryUIPosition, Time.deltaTime * 10);
        inventoryStatus = InventoryStat.Closed;
    }

    public void OpenCloseInventory()
    {
        //TODO fix locations

        if (!IsOpened())
            StartCoroutine(OnOpen());
        else
            StartCoroutine(OnClose());
    }

    public void AddToInventory()
    {
        _inventory.AddToInventory();
    }

    bool IsOpened()
    {
        return inventoryStatus == InventoryStat.Opened;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class InventorySpace : MonoBehaviour 
{
    public List<GameObject> slots = new List<GameObject>();
    public ItemsInGameDatabase InGameItemsDB;

    private int itemIdToAdd;
    
    public void AddToInventory()
    {
        StartCoroutine(PushToInventory(SearchFreeSlot(), GetCurrentItemId()));
    }

    public void SetIntemToAdd(int itemID)
    {
        itemIdToAdd = itemID;
    }

    int SearchFreeSlot()
    {
        int i = 0;

        for (; i < slots.Count-1; i++)
        {
            if (!slots[i].activeSelf)
            {
                break;
            }
        }
        return i;
    }

    IEnumerator PushToInventory(int index, int itemId)
    {
        yield return new WaitForSeconds(.5f);
        
        //Debug.Log("inventory slot, " + index + " item ID: " + itemId);
        slots[index].SetActive(true);
        slots[index].GetComponent<Image>().sprite = SearchForItemSprite(itemId);
        slots[index].GetComponentInChildren<Text>().text = SearchForItemAmount(itemId).ToString();
        //StartCoroutine(DeactivateItemOnScene(itemId));
        DeactivateItemOnScene(itemId);
    }

    int GetCurrentItemId()
    {
        return itemIdToAdd;
    }

    Sprite SearchForItemSprite(int itemID)
    {
        Sprite temp = null;

        if (itemID != 0)
        {
            foreach (var item in InGameItemsDB.ItemsDatabase)
            {
                if (item.id == itemID)
                {
                    temp = item.GetComponent<SpriteRenderer>().sprite;
                }
            }
        }
        if (temp == null) Debug.Log("Couldn't find item sprite");

        return temp;
    }

    int SearchForItemAmount(int itemID)
    {
        if (itemID != 0)
        {
            foreach (var item in InGameItemsDB.ItemsDatabase)
            {
                if (item.id == itemID)
                {
                    itemID = item.amount;
                }
            }

        }
        return itemID;
    }

    void DeactivateItemOnScene(int itemID)
    {
        //yield return new WaitForFixedUpdate();
        GameObject obj = null;
        if (itemID != 0)
        {
            foreach (var item in InGameItemsDB.ItemsDatabase)
            {
                if (item.id == itemID)
                {
                    obj = GameObject.Find(item.name);
                }
            }
        }

        if (obj != null) 
        {
            obj.SetActive(false);
            StartCoroutine(DestroyOnScene(obj));
        }
    }

    IEnumerator DestroyOnScene(GameObject gameObject)
    {
        yield return new WaitForFixedUpdate();
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}


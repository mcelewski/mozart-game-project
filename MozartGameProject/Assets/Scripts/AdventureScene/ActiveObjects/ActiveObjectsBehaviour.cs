using UnityEngine;

[RequireComponent(typeof(ActiveObjects))]
public class ActiveObjectsBehaviour : MonoBehaviour
{
    public ActiveObjects item;
    int itemId;

    void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = item.Icon;
        itemId = item.ID;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
    }

    public int SendItemID()
    {
        return itemId;
    }
}

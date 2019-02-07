using UnityEngine;
 
public class ItemInfo : MonoBehaviour
{
    public new string name;
    public ushort id;
    public ushort amount;
    public ItemInfo item;

    public void Print()
    {
        Debug.Log("Item Name: " + name +
                  "\tItem ID: " + id +
                  "\tItem Amount: " + amount);
    }
}

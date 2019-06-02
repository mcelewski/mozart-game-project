using UnityEngine;
 
public class ItemInfo : MonoBehaviour, IObjectInfo
{
    public new string name;
    public ushort id;
    public ushort amount;
    public ItemInfo item;

    ///<summary>
    /// Returns object current position as Vector3
    ///</summary>
    public Vector3 CurrentObjectPosition()
    {
        return this.transform.localPosition;
    }
    ///<summary>
    /// Print to console object basic info
    ///</summary>
    public void Print()
    {
        Debug.Log("Item Name: " + name +
                  "\tItem ID: " + id +
                  "\tItem Amount: " + amount);
    }
    ///<summary>
    /// Returns object basic info as string array
    ///</summary>
    public string[] GetItemInfo()
    {
        return new string[] 
        {
            "Item Name: " + name,
            "\tItem ID: " + id,
            "\tItem Amount: " + amount
        };
    }
}

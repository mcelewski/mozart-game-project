using UnityEngine;

public class ItemsID : MonoBehaviour 
{
	[SerializeField]
	public int itemID;

	public int GetItemID()
	{
		return itemID;
	}
}

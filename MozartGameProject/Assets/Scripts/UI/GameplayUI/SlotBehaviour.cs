using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBehaviour : MonoBehaviour
{
	public int slotNumber;
	static bool activeOnload;
	
	void Start () 
	{
		if (IsSlotActive() && !gameObject.activeSelf)
		{
			gameObject.SetActive(true);
		}
		else if (!IsSlotActive() && gameObject.activeSelf)
		{
			gameObject.SetActive(false);
		}
	}

	public int GetSlotNumber()
	{
		return slotNumber;
	}

	public static bool IsSlotActive()
	{
		return activeOnload;
	}

	/// <summary>
	/// Active slot on load autosave
	/// </summary>
	/// <param name="active"></param>
	public static void SetActiveOnLoad(bool active)
	{
		activeOnload = active;
	}
}

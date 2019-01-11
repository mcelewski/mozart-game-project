using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleLadder : MonoBehaviour 
{
	private static bool activateMiddle;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
			activateMiddle = true;
		LowerLadder.UpdateIfNeed();
		//Debug.Log("Middle active");
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
			activateMiddle = false;
		LowerLadder.UpdateIfNeed();
		//Debug.Log("Middle unactive");
	}

	public static bool GetActivateStatus()
	{
		return activateMiddle;
	}
}

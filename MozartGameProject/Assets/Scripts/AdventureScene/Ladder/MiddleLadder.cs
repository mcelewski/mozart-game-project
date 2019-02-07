using UnityEngine;

public class MiddleLadder : MonoBehaviour 
{
	static bool activateMiddle;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
			activateMiddle = true;
		LowerLadder.UpdateIfNeed();
		//Debug.Log("Middle active");
	}

	void OnTriggerExit2D(Collider2D other)
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

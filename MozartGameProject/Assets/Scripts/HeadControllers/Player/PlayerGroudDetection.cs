using UnityEngine;

public class PlayerGroudDetection : MonoBehaviour
{

	static bool isGrounded;
	public static bool IsGrounded()
	{
		return isGrounded;
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (!other.CompareTag("Ground")) return;
	
		isGrounded = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (!other.CompareTag("Ground")) return;
		
		isGrounded = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroudDetection : MonoBehaviour
{

	private static bool isGrounded;

	public BoxCollider2D groundCollider;
	public static bool IsGrounded()
	{
		return isGrounded;
	}
	
	private void OnTriggerStay2D(Collider2D other)
	{
		if (!other.CompareTag("Ground")) return;
	
		isGrounded = true;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (!other.CompareTag("Ground")) return;
		
		isGrounded = false;
	}
}

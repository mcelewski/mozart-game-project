using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroudDetection : MonoBehaviour
{

	private static bool isGrounded;

	public static bool IsGroundedAlready()
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
		isGrounded = true;
	}
}

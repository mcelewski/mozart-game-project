﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour 
{
	public Animator animator;

	private string _idleAnimation = "Mozart_idle";
	private string _climbAnimation = "Mozart_climb";
	private string _walkAnimation = "Mozart_walk";
	private string _jumpAnimation = "Mozart_jump";
	private string _inventoryAnimation = "Mozart_inventory";


	#region Idle animations
	public void EndIdleAnimation()
	{
		//animator.Play("Mozart_Idle");
    }

	public void StartIdleAnimation()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName(_jumpAnimation) ||
		    animator.GetCurrentAnimatorStateInfo(0).IsName(_climbAnimation) ||
		    animator.GetCurrentAnimatorStateInfo(0).IsName(_walkAnimation))
		{
			animator.Play("Mozart_idle");
		}
	}
	

	#endregion
	#region Moving animations
    
	public void EndMoveAnimation()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName(_walkAnimation))
		{
			animator.ResetTrigger("Mozart_Move");
		}
	}

	public void StartMoveAnimation()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName(_idleAnimation) ||
		    animator.GetCurrentAnimatorStateInfo(0).IsName(_climbAnimation) ||
		    animator.GetCurrentAnimatorStateInfo(0).IsName(_inventoryAnimation))
		{
			animator.SetTrigger("Mozart_Move");
		}
	}
	#endregion

	#region Jumping animations

	public void EndJumpAnimation()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName(_jumpAnimation))
		{
			animator.ResetTrigger("Mozart_Jump");
		}
	}

	public void StartJumpAnimation()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName(_idleAnimation) ||
		    animator.GetCurrentAnimatorStateInfo(0).IsName(_walkAnimation))
		{
			animator.SetTrigger("Mozart_Jump");
		}
	}

	#endregion
    
	#region Climbing animations

	public void EndClimbAnimation()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName(_climbAnimation))
		{
			animator.ResetTrigger("Mozart_Climb");
		}
	}

	public void StartClimbAnimation()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName(_idleAnimation) || 
		    animator.GetCurrentAnimatorStateInfo(0).IsName(_walkAnimation))
		{
			animator.SetTrigger("Mozart_Climb");
		}
	}

	#endregion
	
	#region Torch animation

	public void EndTorchAnimation()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName(_inventoryAnimation))
		{
			animator.ResetTrigger("Mozart_Torch");
		}
	}

	public void StartTorchAnimation()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName(_idleAnimation) || 
		    animator.GetCurrentAnimatorStateInfo(0).IsName(_walkAnimation))
		{
			animator.SetTrigger("Mozart_Torch");
		}
	}

	#endregion
}
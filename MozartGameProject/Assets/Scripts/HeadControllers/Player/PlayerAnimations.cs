using UnityEngine;

public class PlayerAnimations : MonoBehaviour 
{
	public Animator animator;

	string _idleAnimation = "Mozart_idle";
	string _climbAnimation = "Mozart_climb";
	string _walkAnimation = "Mozart_walk";
	string _jumpAnimation = "Mozart_jump";
	string _inventoryAnimation = "Mozart_inventory";
    string _onLadder = "Mozart_onladder";
    string _die = "Mozart_dead";


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

    #region Idle animations
    public void EndLadderIdleAnimation()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(_onLadder))
        {
            animator.ResetTrigger("Mozart_OnLadder");
        }
    }

    public void StartLadderIdleAnimation()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(_climbAnimation))
        {
            animator.SetTrigger("Mozart_OnLadder");
        }
    }


    #endregion
    
    #region Death animation
    public void EndDeathAnimation()
    {
	    if (animator.GetCurrentAnimatorStateInfo(0).IsName(_die))
	    {
		    animator.ResetTrigger("Mozart_Die");
	    }
    }

    public void StartDeathAnimation()
    {
	    if (animator.GetCurrentAnimatorStateInfo(0).loop)
	    {
		    animator.SetTrigger("Mozart_Die");
	    }
    }


    #endregion
}

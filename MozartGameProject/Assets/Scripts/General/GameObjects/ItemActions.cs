using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// - Event bus
/// - Holds own actions
///</summary>
public class ItemActions : MonoBehaviour
{
    ///<summary>
    /// Occurs when input is down
    ///</summary>
    public static event Action<ushort> OnInputPress;
    ///<summary>
    /// Occurs when input is holded for more than 2 seconds
    ///</summary>
    public static event Action<ushort> OnInputHold;
    ///<summary>
    /// Occurs when input is up
    ///</summary>
    public static event Action<ushort> OnInputRelease;
    ///<summary>
    /// Occurs when object is beign collide or trigger with another
    ///</summary>
    public static event Action OnColliderEnter;
    ///<summary>
    /// Occurs when object is stay collide or trigger with another
    ///</summary>
    public static event Action OnColliderStay;
    ///<summary>
    /// Occurs when object is over collide or trigger with another
    ///</summary>
    public static event Action OnColliderLeave;
    // FIXME: remember to delete debugs !
    #region Event Methods
    public static void OnPress(ushort id)
    {
        if(OnInputPress != null)
        {
            //Debug.Log("Press: " + id + " at " + DateTime.Now);
        }
    }
    public static void OnHold(ushort id)
    {
        if(OnInputHold != null)
        {
            //Debug.Log("Hold: " + id + " at " + DateTime.Now);
        }
    }
    public static void OnRelease(ushort id)
    {
        if (OnInputRelease != null)
        {
            //Debug.Log("Release: " + id + " at " + DateTime.Now);
        }
    }
    public static void OnEnter(ushort id)
    {
        if (OnColliderEnter != null)
        {
            //Debug.Log("Enter: " + id + " at " + DateTime.Now);
        }
    }
    public static void OnStay(ushort id)
    {
        if (OnColliderStay != null)
        {
            //Debug.Log("Stay: " + id + " at " + DateTime.Now);
        }
    }
    public static void OnExit(ushort id)
    {
        if (OnColliderLeave != null)
        {
            //Debug.Log("Exit: " + id + " at " + DateTime.Now);
        }
    }
    #endregion
}

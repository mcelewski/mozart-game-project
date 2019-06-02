using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

///<summary>
/// Publisher trigger events
///</summary>
public class NoteEnemyBehaviour : MonoBehaviour
{
    public OnPressAction pressAction;
    public OnHoldAction holdAction;
    public OnReleaseAction releaseAction;
    // TODO: add summary to all of them 
    public ItemInfo item;
    public float ZLenght;
    public bool IsWhite;
    public ItemsInGameDatabase KeysDB;
    private Vector3 _blackYPos = new Vector3(0.0f, 0.5f, 0.0f);
    private Vector3 _whiteYPos = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 _blackScale = new Vector3(0.5f, 1.0f, 2.0f);
    private Vector3 _whiteScale = new Vector3(1.0f, 1.0f, 4.0f);
    #region Private methods
    ///<summary>
    /// Search for object with same id and set it's x position
    ///</summary>
    private void SetProperPosition()
    {
        Vector3 properPosition = KeysDB.GetDatabase().FirstOrDefault(f=> f.id == item.id).CurrentObjectPosition();
        if(IsWhiteDefault())
        {
            this.transform.localPosition = new Vector3(properPosition.x ,this._whiteYPos.y,this.transform.localPosition.z);
        }
        if(!IsWhiteDefault())
        {
            this.transform.localPosition = new Vector3(properPosition.x ,this._blackYPos.y,this.transform.localPosition.z);
        }
    }
    ///<summary>
    /// Set proper object scale based on color
    ///</summary>
    private void SetProperScale(float scale)
    {
        if(IsWhiteDefault())
        {
            this.transform.localScale = new Vector3(_whiteScale.x, _whiteScale.y, scale);
        }
        if(!IsWhiteDefault())
        {
            this.transform.localScale = new Vector3(_blackScale.x, _blackScale.y, scale);
        }
    }
    ///<summary>
    /// Register a default object events
    ///</summary>
    private void RegisterEvents()
    {
        ItemActions.OnColliderEnter += TriggerEnterned;
        ItemActions.OnColliderStay += TriggerStayed;
        ItemActions.OnColliderLeave += TriggerLeaved;
    }
    ///<summary>
    /// Detect if object is disabled and unregister events
    ///</summary>
    private void OnDestroy()
    {
        if(!this.isActiveAndEnabled)
        {
            Debug.Log("destroyed");
            UnregisterEvents();
        }
    }
    private void TriggerEnterned()
    {
        
    }
    private void TriggerStayed()
    {
        
    }
    private void TriggerLeaved()
    {
        
    }
    #endregion
    #region Unity
    private void Start()
    {
        if(KeysDB != null && item != null)
        {
            SetProperPosition();
            SetProperScale(ZLenght);
            RegisterEvents();
        }
        else
        {
            throw new MissingReferenceException ("There is one or more missing reference in " + this.name + " game object");
        }
    }
    private void Update()
    {
        OnDestroy();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Finish")) 
        {
            return;
        }
        else
        {
            pressAction.SetTriggerData(item.id);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(!other.CompareTag("Finish"))
        {
            return;
        }
        else
        {
            holdAction.SetTriggerData(item.id);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Finish"))
        {
            return;
        }
        else
        {
            releaseAction.SetTriggerData(item.id);
        }
    }
    #endregion
    #region Methods
    ///<summary>
    /// Unregister events
    ///</summary>
    public virtual void UnregisterEvents()
    {
        ItemActions.OnColliderEnter -= TriggerEnterned;
        ItemActions.OnColliderStay -= TriggerStayed;
        ItemActions.OnColliderLeave -= TriggerLeaved;
    }
    #endregion
    private bool IsWhiteDefault()
    {
        return IsWhite;
    }
}

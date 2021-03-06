﻿using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

/// <summary>
/// Main UI panel for began of game and in game
/// 
///     Default settings: Story, How to panels, Autosave are disabled
///     Changes will take place in buttons:
///         Start -> Continue
///         Leave -> Back
///         Autosave: Disabled -> Enabled
/// 
/// </summary>
public class MenuUIController : MonoBehaviour 
{
    public GameObject menuUI;
    public GameObject gameplayUI;
    public Button autosaveBtn;
    public Button startBtn;
    public Button storyBtn;
    public Button howtoBtn;
    public Button leaveBtn;
    public GameObject storyUI;
    public GameObject howToUI;

    string leave = "Leave";
    string back = "Back";
    string resume = "Resume";

    #region Private Methods
    void Start()
    {
        MenuDefaultSetting();
    }
    
    void CheckUIPanelState()
    {
        if (storyUI.activeSelf || howToUI.activeSelf)
        {
            storyUI.SetActive(false);
            howToUI.SetActive(false);
        }
    }

    void SetExitBtnText(bool leaveGame)
    {
        var btnText = leaveBtn.GetComponentInChildren<Text>();
        
        if (leaveGame)
            btnText.text = leave;
        else
            btnText.text = back;
    }
    
    void MenuDefaultSetting()
    {
        CheckUIPanelState();
        DeactivePlayerUI();
        SetExitBtnText(true);
        AutosaveButtonOnStart();
        Time.timeScale = 0;
        SceneMovementController.SetPauseMenu();
    }

    void ChangeStateMenuButtons(bool enable)
    {
        startBtn.gameObject.SetActive(enable);
        storyBtn.gameObject.SetActive(enable);
        howtoBtn.gameObject.SetActive(enable);
    }

    void AutosaveButtonOnStart()
    {
        if (autosaveBtn.isActiveAndEnabled)
        {
            autosaveBtn.gameObject.SetActive(false);
            autosaveBtn.enabled = false;
        }
    }
    void AutosaveButtonOnPauseMenu()
    {
        if (!autosaveBtn.isActiveAndEnabled)
        {
            autosaveBtn.gameObject.SetActive(true);
            autosaveBtn.enabled = true;
        }
    }

    #endregion
    
    public void DeactivePlayerUI()
    {
        gameplayUI.SetActive(false);
    }

    public void ActivatePlayerUI()
    {
        gameplayUI.SetActive(true);
    }

    public void OnAutosave()
    {
        Debug.Log("autosave load");
    }

    public void OnStart()
    {
        DisableMenu();
    }
    
    public void OnStory()
    {
        storyUI.SetActive(true);
        SetExitBtnText(false);
        ChangeStateMenuButtons(false);
    }
    
    public void OnHowTo()
    {
        howToUI.SetActive(true);
        SetExitBtnText(false);
        ChangeStateMenuButtons(false);
    }
    
    public void OnLeave()
    {
        CheckUIPanelState();
        SetExitBtnText(true);
        ChangeStateMenuButtons(true);
    }
    
    public void EnableMenu()
    {
        var resumeText = startBtn.GetComponentInChildren<Text>();

        resumeText.text = resume;
        menuUI.SetActive(true);
        DeactivePlayerUI();
        Time.timeScale = 0;
    }

    public void DisableMenu()
    {
        menuUI.SetActive(false);
        ActivatePlayerUI();
        Time.timeScale = 1;
    }
    
}

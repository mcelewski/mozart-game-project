﻿using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

/// <summary>
/// Main UI panel for began of game and in game
/// 
///     Default settings: Story, How to panels are disabled
///     Changes will take place in buttons:
///         Start -> Continue
///         Leave -> Back
/// 
/// </summary>
public class MenuUIController : MonoBehaviour 
{
    /*
     * Get all UI objects
     */
    public GameObject menuUI;
    public GameObject gameplayUI;
    public Button startBtn;
    public Button storyBtn;
    public Button howtoBtn;
    public Button leaveBtn;
    public GameObject storyUI;
    public GameObject howToUI;

    public HealthBarBehaviour healthBar;

    private string leave = "Leave";
    private string back = "Back";
    private string resume = "Resume";

    #region Private Methods
    private void Start()
    {
        MenuDefaultSetting();
        //TODO fix start game
    }
    
    private void CheckUIPanelState()
    {
        if (storyUI.activeSelf || howToUI.activeSelf)
        {
            storyUI.SetActive(false);
            howToUI.SetActive(false);
        }
    }

    private void DeactivePlayerUI()
    {
        gameplayUI.SetActive(false);
    }

    private void ActivatePlayerUI()
    {
        gameplayUI.SetActive(true);
    }

    private void SetExitBtnText(bool leaveGame)
    {
        var btnText = leaveBtn.GetComponentInChildren<Text>();
        
        if (leaveGame)
            btnText.text = leave;
        else
            btnText.text = back;
    }
    
    private void MenuDefaultSetting()
    {
        CheckUIPanelState();
        DeactivePlayerUI();
        SetExitBtnText(true);
    }

    private void ChangeStateMenuButtons(bool enable)
    {
        startBtn.gameObject.SetActive(enable);
        storyBtn.gameObject.SetActive(enable);
        howtoBtn.gameObject.SetActive(enable);
    }

    #endregion
    
    public void OnStart()
    {
        DisableMenu();
        healthBar.SetBar();
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

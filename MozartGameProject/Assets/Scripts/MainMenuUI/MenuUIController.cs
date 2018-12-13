using UnityEngine;
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
    public Button startBtn;
    public Button storyBtn;
    public Button howtoBtn;
    public Button leaveBtn;
    public GameObject storyUI;
    public GameObject howToUI;

    private string leave = "Leave";
    private string back = "Back";
    private string resume = "Resume";

    #region Private Methods
    private void Start()
    {
        MenuDefaultSetting();
    }
    
    private void CheckUIPanelState()
    {
        if (storyUI.activeSelf || howToUI.activeSelf)
        {
            storyUI.SetActive(false);
            howToUI.SetActive(false);
        }
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
        SceneMovementController.SetActualLoadedScene(SceneMovementController.SceneLoaded.Adventure);
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
    // TODO fix enable / disable object
    public void EnableMenu()
    {
        var resumeText = startBtn.GetComponentInChildren<Text>();
        resumeText.text = resume;
        menuUI.SetActive(true);
    }

    public void DisableMenu()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1;
    }
}

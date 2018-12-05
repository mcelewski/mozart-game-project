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

    #region Private Methods
    private void Start()
    {
        MenuDefaultSetting();
        DontDestroy();
    }

    private void DontDestroy()
    {
        DontDestroyOnLoad(menuUI);
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
        Debug.Log("Open main scene");
    }
    
    public void OnStory()
    {
        storyUI.SetActive(true);
        SetExitBtnText(false);
        ChangeStateMenuButtons(false);
        Debug.Log("Open story line");
    }
    
    public void OnHowTo()
    {
        howToUI.SetActive(true);
        SetExitBtnText(false);
        ChangeStateMenuButtons(false);
        Debug.Log("Tutorial how to play");
    }
    
    public void OnLeave()
    {
        CheckUIPanelState();
        SetExitBtnText(true);
        ChangeStateMenuButtons(true);
        Debug.Log("Leave game");
    }
    
    public void EnableMenu()
    {
        menuUI.SetActive(true);
    }

    public void DisableMenu()
    {
        menuUI.SetActive(false);
    }
}

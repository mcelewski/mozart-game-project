using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevelUIController : MonoBehaviour
{
    public GameObject EndLevelUI;
    public MenuUIController MainMenuUI;
    
    public Text notesScoreTxt;
    public Text totalScoreTxt;
    public Text decripctionTxt;

    public Button mozartHeroBtn;
    public Button endLevelButton;
    
    static string mozartHeroName = "MozartHero";

    public void SetEndUI(int notesCount, int totalScore, bool enableUI, bool enableEndBtn)
    {
        EndLevelUI.SetActive(enableUI);
        notesScoreTxt.text = notesCount.ToString();
        totalScoreTxt.text = totalScore.ToString();
        endLevelButton.enabled = enableEndBtn;
    }

    public void EnableEndMenu()
    {
        EndLevelUI.SetActive(true);
        MainMenuUI.DeactivePlayerUI();
        endLevelButton.enabled = false;
        Time.timeScale = 0;
    }

    public void DisableEndMenu()
    {
        EndLevelUI.SetActive(false);
    }

    public void OnMozartHeroBtnClick()
    {
        if (EndCurrentLevelBehaviour.CanPlayerEndScene())
        {
            SceneManager.LoadSceneAsync(mozartHeroName, LoadSceneMode.Single);
        }
    }

    public void OnEndLevelBtnClick()
    {
        Debug.Log("End game");
    }
}

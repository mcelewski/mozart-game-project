using UnityEngine;

public class PlayerDeatchUI : MonoBehaviour
{
    [SerializeField] private GameObject _menuUI;
    [SerializeField] private GameObject _inventoryUI;
    [SerializeField] private GameObject _healthBarUI;
    [SerializeField] private GameObject _scoreUI;
    [SerializeField] private GameObject _deathUI;
    [SerializeField] private GameObject _player;
    [SerializeField] private Sprite _deatch;
    
    public void OnOkButton()
    {
       Debug.Log("okbtn clicked");
       SetMenuUI(true);
       DisableGameplayUIs();
       SetDeadUI(false);
    }

    void SetDeadUI(bool set)
    {
        _deathUI.SetActive(set);
    }

    void SetMenuUI(bool set)
    {
        _menuUI.SetActive(set);
    }

    void DisableGameplayUIs()
    {
        _inventoryUI.SetActive(false);
        _scoreUI.SetActive(false);
    }

    public void OnUIShow()
    {
        DisableGameplayUIs();
        SetDeadUI(true);
        PauseGameTime();
        SetPlayerDeatchSprite();
    }

    void PauseGameTime()
    {
        if (!ZeroTimeScale())
            Time.timeScale = 0;
    }

    bool ZeroTimeScale()
    {
        return Time.timeScale == 0;
    }

    void SetPlayerDeatchSprite()
    {
        _player.GetComponent<SpriteRenderer>().sprite = _deatch;
    }
}

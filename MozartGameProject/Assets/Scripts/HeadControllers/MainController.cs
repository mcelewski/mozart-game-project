using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject MenuUI;
  
    // Start is called before the first frame update
    void Awake()
    {
        if (!MenuUI) 
        {
            Debug.Log("Missing reference");
        }
        SetStartUIs();
    }

    void SetStartUIs()
    {
        if (!IsMenuUIActive())
        {
            MenuUI.SetActive(true);
        }
    }

    bool IsMenuUIActive()
    {
        return MenuUI.activeSelf;
    }
}

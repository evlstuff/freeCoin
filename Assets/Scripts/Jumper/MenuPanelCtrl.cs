using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanelCtrl : MonoBehaviour
{
    private CanvasGroup UI;

    void Awake()
    {
        UI = gameObject.AddComponent<CanvasGroup>();
        Hide();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Show()
    {
        UI.alpha = 1;
        UI.interactable = true;
    }

    public void Hide()
    {
        UI.alpha = 0;
        UI.interactable = false;
    }
}

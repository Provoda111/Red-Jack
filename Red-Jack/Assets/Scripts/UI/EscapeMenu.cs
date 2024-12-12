using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public GameObject escMenuPanel;
    public GameObject settingsMenu;

    public void GoToSettings()
    {
        settingsMenu.SetActive(true);
    }
    public void LeaveSettings()
    { 
        settingsMenu.SetActive(false); 
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(sceneName: "UI_Test");
    }
    public void ReturnToGame()
    {
        Debug.Log("4");
        escMenuPanel.SetActive(false);
    }
}

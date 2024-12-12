using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void GoToSettings()
    {
        settingsMenu.SetActive(true);
    }
    void LeaveSettings()
    { 
        settingsMenu.SetActive(false); 
    }
    void GoToMainMenu()
    {
        SceneManager.LoadScene(sceneName: "UI_Test");
    }
    void ReturnToGame()
    {
        mainMenu.SetActive(false);
    }
}

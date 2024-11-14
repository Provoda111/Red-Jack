    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInit : MonoBehaviour
{
    public void SwitchToGame()
    {
        SceneManager.LoadScene(sceneName: "DemoScene");
    }
    
}

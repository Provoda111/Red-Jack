using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OverTextController : MonoBehaviour
{
    bool YouWon = false;
    public GameObject WonText;
    public GameObject LoseText;
    void Start()
    {
        if (YouWon == true)
        {
            WonText.SetActive(true);
            LoseText.SetActive(false);
        }
        else if (YouWon == false) 
        {
            WonText.SetActive(false);
            LoseText.SetActive(true);
        }
    }

}

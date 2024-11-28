using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blackjack : MonoBehaviour
{
    public TextMeshPro CardSumm;
    public static int cardSumm = 0;
    void Start()
    {
        
    }
    void Update()
    {
        CardSumm.text = cardSumm + "/21";
        if (cardSumm <= 21)
        {
            CardSumm.color = Color.green;
        }
        else if (cardSumm > 21)
        {
            CardSumm.color = Color.red;
        }
    }
}

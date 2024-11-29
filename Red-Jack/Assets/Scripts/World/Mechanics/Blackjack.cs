using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blackjack : MonoBehaviour
{
    public TextMeshPro CardSumm;
    //public static int cardSumm = 0;

    private Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();  
    }
    void Update()
    {
        CardSumm.text = player.gamerValues + "/21";
        if (player.gamerValues <= 21)
        {
            CardSumm.color = Color.green;
        }
        else if (player.gamerValues > 21)
        {
            CardSumm.color = Color.red;
        }
    }
}

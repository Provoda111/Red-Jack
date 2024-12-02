using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Blackjack : MonoBehaviour
{
    public TextMeshPro CardSumm;

    public bool player1;
    public bool player2;
    //public static int cardSumm = 0;

    private Player player;

    void Start()
    {
        player1 = GamerChooser.playerMove;
        player2 = GamerChooser.enemyMove;
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

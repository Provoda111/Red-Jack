using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Blackjack : MonoBehaviour
{
    public TextMeshPro CardSumm;
    public TextMeshPro EnemyCardSumm;

    public bool player1;
    public bool player2;
    //public static int cardSumm = 0;

    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    void Start()
    {
        player1 = GamerChooser.playerMove;
        player2 = GamerChooser.enemyMove;
    }
    void Update()
    {
        CardSumm.text = player.gamerValues + "/21";
        EnemyCardSumm.text = enemy.gamerValues + "/21";
        if (player.gamerValues <= 21 || enemy.gamerValues <= 21)
        {
            CardSumm.color = Color.green;
            EnemyCardSumm.color = Color.green;
        }
        else if (player.gamerValues > 21 || enemy.gamerValues > 21)
        {
            CardSumm.color = Color.red;
            EnemyCardSumm.color = Color.red;
        }
    }
}

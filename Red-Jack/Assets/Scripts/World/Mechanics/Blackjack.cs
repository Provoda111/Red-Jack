using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Blackjack : MonoBehaviour
{
    public TextMeshPro CardSumm;
    public TextMeshPro EnemyCardSumm;

    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    private GameCard enemyFirstCard;

    void Start()
    {
        
    }
    void Update()
    {
        if (enemy.gameCards.Count > 0)
        {
            enemyFirstCard = enemy.gameCards[0].GetComponent<GameCard>();
        }
        CardSummText();
    }
    private void CardSummText()
    {
        CardSumm.text = player.gamerValues + "/21";
        if (enemyFirstCard != null && !GameManager.GameEnd)
        {
            EnemyCardSumm.text = $"? + {enemy.gamerValues - enemyFirstCard.cardValue} /21";
        }
        else
        {
            EnemyCardSumm.text = $"{enemy.gamerValues}/21";
        }
        if (player.gamerValues < 21)
        {
            CardSumm.color = Color.white;
            //EnemyCardSumm.color = Color.green; ?
        }else if (player.gamerValues == 21)
        {
            CardSumm.color = Color.green;
        }
        else if (player.gamerValues > 21)
        {
            CardSumm.color = Color.red;
        }
        if (enemy.gamerValues <= 21)
        {
            EnemyCardSumm.color = Color.white;
        }
        else if (enemy.gamerValues > 21)
        {
            EnemyCardSumm.color = Color.red;
        }
    }
}

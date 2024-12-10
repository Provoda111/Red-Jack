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
        else if (enemy.gamerValues - enemyFirstCard.cardValue > 21)
        {
            EnemyCardSumm.color = Color.red;
        }
    }

    private void EndGameCheck()
    {
        
    }
    public void TurnOnSummText()
    { 
        CardSumm.gameObject.SetActive(true);
        EnemyCardSumm.gameObject.SetActive(true);
    }
    public void TurnOffSummText()
    {
        CardSumm.gameObject.SetActive(false);
        EnemyCardSumm.gameObject.SetActive(false);
    }
    internal void PlayerLost()
    {
        Player.hasLost = true;
    }
    internal void EnemyLost()
    {
        Enemy.hasLost = true;
    }
}

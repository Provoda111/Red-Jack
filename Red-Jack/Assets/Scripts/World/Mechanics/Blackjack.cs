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
    [SerializeField] private Revolver revolver;

    private GameCard enemyFirstCard;
    string whoShoot;
    
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

    internal void EndGameCheck()
    {
        if (Player.skipMove && Enemy.skipMove)
        {
            string result = "";

            // Kuka voitti pelin?
            if (player.gamerValues <= 21 && (player.gamerValues > enemy.gamerValues || enemy.gamerValues > 21))
            {
                result = "Player wins!";
                whoShoot = "Player";
                CardSumm.color = Color.green;
                EnemyCardSumm.color = Color.red;
            }
            else
            {
                result = "Enemy wins!";
                whoShoot = "Enemy";
                CardSumm.color = Color.red;
                EnemyCardSumm.color = Color.green;
            }

            Debug.Log(result);

            if (whoShoot == "Player")
            {
                revolver.TryToShot();
            }
            else
            {
                revolver.EnemyTryShot();
            }
        }
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

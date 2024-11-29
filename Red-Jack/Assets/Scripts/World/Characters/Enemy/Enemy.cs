using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : Gamer
{
    public GameObject carddd;
    private GameObject selectCard;
    public void Start()
    {
        gamerSlots = GameObject.FindGameObjectsWithTag("Enemy's card").ToList();
        
    }
    public void Update()
    {
        
    }
    internal void ChooseRandomCardFromCenter()
    {
        if (GamerChooser.enemyMove)
        {
            var centerCards = GameObject.Find("CardsAtTheCenter").transform
            .GetComponentsInChildren<GameCard>()
            .Where(card => card.isAtTheCenter)
            .ToList();
            if (centerCards.Count > 0)
            {
                GameCard chosenCard = centerCards[Random.Range(0, centerCards.Count)];
                if (!chosenCard.isAtTheHand)
                {
                    chosenCard.GoToPlayer(this.gameObject);
                    chosenCard.isAtTheCenter = false;
                    chosenCard.isAtTheHand = true;
                }
                GamerChooser.EnemyHasMoved();
            }
        }
    }
}

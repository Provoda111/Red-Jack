using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : Gamer
{
    public void Start()
    {
        gamerSlots = GameObject.FindGameObjectsWithTag("Enemy's card").ToList();
        gamerSlots.Sort((x, y) => x.name.CompareTo(y.name));
    }
    public void Update()
    {

    }
    public void ChooseRandomCardFromCenter()
    {
        if (Deck.cardHasBeenSharedToCenter)
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
                        GamerChooser.EnemyHasMoved();
                    }
                }
            }
        }
    }
    public void MoveOrNo()
    {
        skipMove = false;
        int randomNumber = Random.Range(0, 2);
        GamerChooser.EnemyHasMoved();
        if (randomNumber == 0)
        {
            skipMove = false;
            deck.GiveCardToPlayer(this.gameObject);
        }
        if (randomNumber == 1)
        {
            SkipMove();
        }
    }
    internal IEnumerator StandOrNo()
    {
        yield return null;
    }
    private void SkipMove()
    {
        Debug.Log("Enemy doesn't wan't to move");
        skipMove = true;
    }

    private void UseEnemyBuffCard()
    {
        if (buffCards.Count == 0)
        {
            Debug.LogWarning("No buff cards available.");
            return;
        }

        int randomNumber = Random.Range(0, buffCards.Count);
        UseBuffCard(buffCards[randomNumber]);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : Gamer
{
    public bool EnemySkip = false;
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
        EnemySkip = false;
        int randomNumber = Random.Range(0, 2);
        if (randomNumber == 0)
        {
            deck.GiveCardToPlayer(this.gameObject);
        }
        if (randomNumber == 1)
        {
            SkipMove();
        }
        GamerChooser.EnemyHasMoved();
    }
    internal IEnumerator StandOrNo()
    {
        yield return null;
    }
    private void SkipMove()
    {
        Debug.Log("Enemy doesn't wan't to move");
        EnemySkip = true;
    }

    private void UseEnemyBuffCard()
    {
        int randomNumber = Random.Range(0, buffCards.Count + 1);
        UseBuffCard(buffCards[randomNumber]);
    }
}

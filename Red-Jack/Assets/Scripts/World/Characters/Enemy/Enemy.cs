using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : Gamer
{
    public GameObject carddd;
    private GameObject selectCard;
    [SerializeField] private Deck deck;
    public void Start()
    {
        gamerSlots = GameObject.FindGameObjectsWithTag("Enemy's card").ToList();
        gamerSlots.Sort(delegate (GameObject x, GameObject y)
        {
            return x.name.CompareTo(y.name);
        });
        buffSlots = GameObject.FindGameObjectsWithTag("Enemy's buff").ToList();
    }
    public void Update()
    {
        if (GamerChooser.enemyMove)
        {
            StartCoroutine(HitOrNo());
        }
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
    internal IEnumerator HitOrNo()
    {
        int randomNumber = Random.Range(0, 2);
        if (GamerChooser.enemyMove)
        {
            GamerChooser.EnemyHasMoved();
            yield return new WaitForSeconds(5f);
            switch (randomNumber)
            {
                case 0:
                    deck.GiveCardToPlayer(this.gameObject);
                    break;
                case 1:
                    SkipMove();
                    break;
            }
        }
    }
    private void SkipMove()
    {
        Debug.Log("Enemy doesn't wan't to move");
    }
}

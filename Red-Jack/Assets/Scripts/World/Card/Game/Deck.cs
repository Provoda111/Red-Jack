using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Deck : MonoBehaviour
{
    [SerializeField] private Animator deckAnimator;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform cardSpawner;
    [SerializeField] internal List<GameObject> cardDeck = new List<GameObject>();

    [SerializeField] internal bool cardHasBeenSharedToCenter = false;

    public event Action oneCardOnCenter;

    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    private void Start()
    {
        
    }
    internal void CallCardsToCenter()
    {
        StartCoroutine(CardsToCenter());
    }
    internal IEnumerator CardsToCenter()
    {
        yield return new WaitForSeconds(3.5f);
        for (int i = 0; i < 3; i++)
        {
            deckAnimator.SetTrigger("GiveCardsToCenter");
            int cardIndex = UnityEngine.Random.Range(0, cardDeck.Count);
            GameObject cardObject = Instantiate(cardDeck[cardIndex], cardSpawner.position, 
                cardDeck[cardIndex].transform.rotation);
            GameCard card = cardObject.GetComponent<GameCard>();
            card.GoToCenter();
            cardDeck.Remove(cardDeck[cardIndex]);
            card.gameObject.name = $"Card{i + 1}";
            yield return new WaitForSeconds(3.5f);
        }
        cardHasBeenSharedToCenter = true;
    }

    
    internal void GiveCardToPlayer(GameObject whoGetsCard)
    {
        Quaternion newCardRotation = Quaternion.Euler(-90, 90, 90);
        int cardIndex = UnityEngine.Random.Range(0, cardDeck.Count);
        GameObject cardObject = Instantiate(cardDeck[cardIndex], cardSpawner.position,
                newCardRotation);
        GameCard card = cardObject.GetComponent<GameCard>();
        card.GoToPlayer(whoGetsCard);
        cardDeck.Remove(cardDeck[cardIndex]);
    }
    internal IEnumerator GiveCardToGamers() // NEEDS TO BE OPTIMIZED
    {
        for (int i = 0; i < 1; i++)
        {
            GiveCardToPlayer(player.gameObject);
            yield return new WaitForSeconds(3f);
            GiveCardToPlayer(enemy.gameObject);
            yield return new WaitForSeconds(3f);
            /*if (GamerChooser.playerMove)
            {
                GiveCardToPlayer(player.gameObject);
                GamerChooser.PlayerHasMoved();
                yield return new WaitForSeconds(3f);
            }
            if (GamerChooser.enemyMove)
            {
                GiveCardToPlayer(enemy.gameObject);
                GamerChooser.EnemyHasMoved();
                yield return new WaitForSeconds(3f);
            }*/
            yield return new WaitForSeconds(2f);
        }
    }
    internal void GiveCardToEnemy()
    {
        
    }
    internal void GiveCardToPlayer()
    {

    }
}
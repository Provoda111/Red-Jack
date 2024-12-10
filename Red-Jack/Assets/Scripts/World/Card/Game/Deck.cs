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
    [SerializeField] internal List<GameObject> buffCardDeck = new List<GameObject>();

    [SerializeField] static public bool cardHasBeenSharedToCenter = false;
    [SerializeField] static public bool cardHasBeenSharedToGamers = false;
    internal bool isRotated = false;

    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    private void Start()
    {
        
    }
    public void CallCardsToCenter()
    {
        StartCoroutine(CardsToCenter());
    }
    public void CallCardsToGamers()
    {
        StartCoroutine(GiveCardToGamers());
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
            Debug.Log($"Card{i + 1} has been given to center");
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
        yield return new WaitForSeconds(3f);
        if (player.gameCards.Count == 1 && enemy.gameCards.Count == 1)
        {
            GiveCardToPlayer(player.gameObject);
            yield return new WaitForSeconds(3f);
            GiveCardToPlayer(enemy.gameObject);
            cardHasBeenSharedToGamers = true;
            yield return new WaitForSeconds(5f);
        }
    }

    internal void GiveBuffCardToGamers()
    {
        
    }
}
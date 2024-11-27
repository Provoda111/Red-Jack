using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private Animator deckAnimator;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform cardSpawner;
    [SerializeField] internal List<GameObject> cardDeck = new List<GameObject>();

    public event Action oneCardOnCenter;

    internal void CallCardsToCenter()
    {
        StartCoroutine(CardsToCenter());
    }
    internal IEnumerator CardsToCenter()
    {
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
        gameManager.cardHasBeenSharedToCenter = true;
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

}

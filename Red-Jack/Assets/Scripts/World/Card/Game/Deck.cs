using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private Animator deckAnimator;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform cardSpawner;
    internal List<GameObject> cardDeck = new List<GameObject>();
    
    internal void CallCardsToCenter()
    {
        StartCoroutine(CardsToCenter());
    }
    internal IEnumerator CardsToCenter()
    {
        for (int i = 0; i < 3; i++)
        {
            int cardIndex = Random.Range(0, gameManager.cardDeck.Count);
            GameObject cardObject = Instantiate(gameManager.cardDeck[cardIndex], cardSpawner, false);
            GameCard card = cardObject.GetComponent<GameCard>();
            card.GoToCenter();
            //card.gameObject.name = $"Card{i + 1}";
            gameManager.cardDeck.Remove(gameManager.cardDeck[cardIndex]);
            yield return new WaitForSeconds(3.5f);
        }
    }
    internal void GiveCardToPlayer()
    {
        int cardIndex = Random.Range(0, gameManager.cardDeck.Count);
        GameObject cardObject = Instantiate(gameManager.cardDeck[cardIndex], cardSpawner.transform);
        GameCard card = cardObject.GetComponent<GameCard>();
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.AddCardToSlot(cardObject);
        gameManager.cardDeck.Remove(gameManager.cardDeck[cardIndex]);
    }
}

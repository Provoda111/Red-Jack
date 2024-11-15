using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private Animator deckAnimator;
    GameManager gameManager;
    private Transform cardSpawner;
    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    internal void CallGetCardForCenter()
    {
        StartCoroutine(GetCardForCenter());
    }
    public IEnumerator GetCardForCenter()
    {
        for (int i = 0; i < 3; i++)
        {
            int cardIndex = Random.Range(0, gameManager.cardDeck.Count);
            GameObject cardObject = Instantiate(gameManager.cardDeck[cardIndex], cardSpawner.transform);
            GameCard card = cardObject.GetComponent<GameCard>();
            //card.GoToPlayer();
            card.gameObject.name = $"Card{i + 1}";
            gameManager.cardDeck.Remove(gameManager.cardDeck[cardIndex]);
            yield return new WaitForSeconds(3.5f);
        }
    }
    public void GiveCardToPlayer()
    {
        int cardIndex = Random.Range(0, gameManager.cardDeck.Count);
        GameObject cardObject = Instantiate(gameManager.cardDeck[cardIndex], cardSpawner.transform);
        GameCard card = cardObject.GetComponent<GameCard>();
        gameManager.cardDeck.Remove(gameManager.cardDeck[cardIndex]);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cardDeckObject;
    //[SerializeField] private GameCard card;
    public Player player;
    public Transform cardSpawner;
    private Deck deck;

    internal Quaternion cardRotation;

    private void Start()
    {
        deck = GameObject.Find("Deck").GetComponent<Deck>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.H)) //If test №1
        {
            StartCoroutine(deck.CardsToCenter());
        }
        if (Input.GetKeyUp(KeyCode.J)) //If test №2
        {
            deck.GiveCardToPlayer();
        }
    }
    /*IEnumerator GivePlayerCardFromDeck()
    {
        for (int i = 0; i < 1; i++)
        {
            int cardIndex = Random.Range(0, cardDeck.Count);
            GameObject cardSpawner = GameObject.Find("CardSpawner");
            GameObject cardObject = Instantiate(cardDeck[cardIndex], cardSpawner.transform);
            GameCard card = cardObject.GetComponent<GameCard>();
            //card.GoToPlayer();
            cardDeck.Remove(cardDeck[cardIndex]);
        }
        yield return new WaitForSeconds(1f);
    }*/
}
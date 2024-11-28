using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private Deck deck;

    private void Start()
    {
        deck = GameObject.Find("Deck").GetComponent<Deck>();
        GamerChooser.MoveDeterminer();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.V))
        {
            StartCoroutine(deck.GiveCardToGamers());
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            enemy.ChooseRandomCardFromCenter();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            CardGoesBackToDeck();
        }
    }
    private void CardGoesBackToDeck()
    {
        Transform cardsAtTheCenterObject = GameObject.Find("CardsAtTheCenter").transform;
        GameCard lastCardCenter;
        if (deck.cardHasBeenSharedToCenter && cardsAtTheCenterObject.childCount == 1)
        {
            Debug.Log("The last card on center can be returned");
            lastCardCenter = cardsAtTheCenterObject.GetComponentInChildren<GameCard>();
            lastCardCenter.GoToDeck();
            //.Where(card => card.isAtTheCenter);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private Deck deck;
    static internal bool GameEnd = false;

    private void Start()
    {
        deck = GameObject.Find("Deck").GetComponent<Deck>();
        //GamerChooser.MoveDeterminer();
    }

    private void Update()
    {
        
    }
    internal void CardGoesBackToDeck()
    {
        Transform cardsAtTheCenterObject = GameObject.Find("CardsAtTheCenter").transform;
        GameCard lastCardCenter;
        if (Deck.cardHasBeenSharedToCenter && cardsAtTheCenterObject.childCount == 1)
        {
            Debug.Log("The last card on center can be returned");
            lastCardCenter = cardsAtTheCenterObject.GetComponentInChildren<GameCard>();
            lastCardCenter.GoToDeck();
            //.Where(card => card.isAtTheCenter);
        }
    }
    internal void GamersChooseCard()
    {
        for (int i = 0; i < 1; i++)
        {
            if (GamerChooser.playerMove)
            {
                GamerChooser.playerMove = true;
            }
            if (GamerChooser.enemyMove)
            {
                enemy.ChooseRandomCardFromCenter();
            }
        }
    }
}
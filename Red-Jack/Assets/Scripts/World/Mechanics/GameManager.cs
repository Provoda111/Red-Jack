using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private Deck deck;
    [SerializeField] private Blackjack blackjack;
    [SerializeField] private Revolver revolver;
    static internal bool GameEnd = false;

    private void Start()
    {
        deck = GameObject.Find("Deck").GetComponent<Deck>();
        //GamerChooser.MoveDeterminer();
    }

    private void Update()
    {
        /*if (Player.skipMove) Debug.Log("PlayerSkipMove: TRUE");
        if (Enemy.skipMove) Debug.Log("EnemySkipMove: TRUE");

        if (Player.skipMove && Enemy.skipMove)
        {
            blackjack.EndGameCheck();
        }*/
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
    internal void ShowAllCards()
    {

    }

    internal void ResetGame()
    {
        revolver.Start();
        DestroyAllCards();
        player.gamerValues = 0;
        enemy.gamerValues = 0;
        Player.skipMove = false;
        Enemy.skipMove = false;
    }

    void DestroyAllCards()
    {
        
        

    }
}

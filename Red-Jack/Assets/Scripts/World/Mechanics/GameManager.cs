using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    private Deck deck;


    // For Deck.cs
    internal bool cardHasBeenSharedToCenter = false;

    internal Quaternion cardRotation;

    private void Start()
    {
        deck = GameObject.Find("Deck").GetComponent<Deck>();
        GamerChooser.MoveDeterminer();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.V))
        {
            StartCoroutine(GiveCardToGamers());
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            enemy.ChooseRandomCardFromCenter();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            StartCoroutine(CardGoesBackToDeck());
        }
    }
    private IEnumerator GiveCardToGamers() // NEEDS TO BE OPTIMIZED
    {
        for (int i = 0; i < 1; i++)
        {
            if (GamerChooser.playerMove)
            {
                deck.GiveCardToPlayer(player.gameObject);
                GamerChooser.PlayerHasMoved();
                yield return new WaitForSeconds(3f);
            }
            else if (GamerChooser.enemyMove)
            {
                deck.GiveCardToPlayer(enemy.gameObject);
                GamerChooser.EnemyHasMoved();
                yield return new WaitForSeconds(3f);
            }
        }
    }
    private IEnumerator CardGoesBackToDeck()
    {
        Transform cardsAtTheCenterObject = GameObject.Find("CardsAtTheCenter").transform;
        GameCard lastCardCenter;
        if (cardHasBeenSharedToCenter && cardsAtTheCenterObject.childCount == 1)
        {
            lastCardCenter = cardsAtTheCenterObject.GetComponentInChildren<GameCard>();
            lastCardCenter.GoToDeck();
            //.Where(card => card.isAtTheCenter);
        }
        yield return new WaitForSeconds(2f);
    }
}
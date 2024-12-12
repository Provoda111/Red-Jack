using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using Random = System.Random;

public class Deck : MonoBehaviour
{
    [SerializeField] private Animator deckAnimator;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform cardSpawner;
    [SerializeField] internal List<GameObject> cardDeck = new List<GameObject>();
    [SerializeField] internal List<GameObject> buffCardDeck = new List<GameObject>();

    [SerializeField] internal List<GameObject> allgameCards;

    [SerializeField] static public bool cardHasBeenSharedToCenter = false;
    [SerializeField] static public bool cardHasBeenSharedToGamers = false;
    
    internal bool isRotated = false;

    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(GiveBuffCardToGamers());
        }
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
    internal IEnumerator GiveBuffCardToGamers()
    {
        int randomBuffCard = UnityEngine.Random.Range(0, buffCardDeck.Count + 1);
        GameObject buffSpawner = GameObject.Find("BuffSpawn");
        for (int i = 0; i < 2; i++)
        {
            Debug.Log("b");
            GameObject buffCard = Instantiate(buffCardDeck[randomBuffCard], buffSpawner.transform.position,
                buffCardDeck[randomBuffCard].transform.rotation);
            CardMover mover = buffCard.AddComponent<CardMover>();
            GameObject targetPosition = GameObject.Find("TargetPositionBuff");
            mover.SetTarget(targetPosition.transform.position, 0.8f);
            mover.OnReachedTarget += () =>
            {
                player.buffCards.Add(buffCard);
                if (player.buffCards.Count < 1)
                {
                    enemy.buffCards.Add(buffCard);
                }
                buffSpawner.transform.position = new Vector3(buffSpawner.transform.position.x,
                    buffSpawner.transform.position.y, buffSpawner.transform.position.z + 1.069f);
                targetPosition.transform.position = new Vector3(targetPosition.transform.position.x
                    , targetPosition.transform.position.y,targetPosition.transform.position.z + 1.069f);
            };
            yield return new WaitForSeconds(3f);
        }
        // z + 1.069
    }
}
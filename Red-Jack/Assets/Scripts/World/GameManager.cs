﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> cardDeck = new List<GameObject>();
    public GameObject cardDeckObject;
    public GameObject foo;
    [SerializeField] private GameCard card;
    public Animator deckAnimator;
    public Player player;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.H)) //If test №1
        {
            StartCoroutine(GiveCards());
        }
    }
    private void CardChooseStep()
    {

    }
    IEnumerator gameStart()
    {
        deckAnimator.SetTrigger("HasShuffled");
        yield return new WaitForSeconds(5f);
        deckAnimator.SetTrigger("HasFlipped");
    }
    IEnumerator GiveCards()
    {
        for (int i = 0; i < 3; i++)
        {
            int cardIndex = Random.Range(0, cardDeck.Count);
            GameObject cardSpawner = GameObject.Find("CardSpawner");
            GameObject cardObject = Instantiate(cardDeck[cardIndex], cardSpawner.transform);
            GameCard card = cardObject.GetComponent<GameCard>();
            card.targetPosition = GameObject.Find("CheckpointForCenter");
            card.GoToCenter();
            /*while (Vector3.Distance(card.gameObject.transform.position, card.targetPosition.transform.position) > 0.01f)
            {
                card.GoToCenter();
            }*/
            cardDeck.Remove(cardDeck[cardIndex]);
            yield return new WaitForSeconds(3.5f);

        }
    }
}
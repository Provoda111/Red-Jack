using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    [SerializeField] internal int cardValue;
    private Animator cardAnimator;
    [SerializeField] internal bool isAtTheHand = false;
    internal bool isAtTheCenter = false;
    [SerializeField] internal Vector3 targetPosition;
    static internal Vector3 targetOffset;
    [SerializeField] private Deck deck;
    private bool hasBeenRevealed;

    public Blackjack blackjack;

    CardMover mover;

    private void Start()
    {
        cardAnimator = GetComponent<Animator>();
        deck = GameObject.Find("Deck").GetComponent<Deck>();
    }

    private void Update()
    {
        if (isAtTheHand)
        {
            WriteCardInfo();
        }
    }
    internal void GoToPlayer(GameObject caller)
    {
        AddCardMover();
        if (!isAtTheHand)
        {
            Gamer gamer = caller.GetComponent<Gamer>();
            gamer.AddCardToSlot(this.gameObject);
            this.targetPosition = gamer.slotPosition;
            mover.SetTarget(targetPosition, 1f);
        }
        mover.OnReachedTarget += () =>
        {
            isAtTheHand = true;
        };
    }
    public void GoToDeck()
    {
        Vector3 deckPosition = GameObject.Find("Deck").transform.position;
        AddCardMover();
        this.targetPosition = deckPosition;
        mover.SetTarget(this.targetPosition, 1f);
        mover.OnReachedTarget += () =>
        {
            Destroy(this.gameObject);
        };
        deck.cardDeck.Add(this.gameObject);
    }
    public void GoToCenter()
    {
        this.targetPosition = GameObject.Find("CheckpointForCenter").transform.position;
        targetPosition += targetOffset;

        AddCardMover();
        mover.SetTarget(this.targetPosition, 1f);

        mover.OnReachedTarget += OnReachedCenter;
    }
    private void OnReachedCenter()
    {
        isAtTheCenter = true;
        targetOffset = new Vector3(
            targetOffset.x + 0.226f,
            targetOffset.y,
            targetOffset.z);
        transform.SetParent(GameObject.Find("CardsAtTheCenter").transform, true);
    }
    private void AddCardMover()
    {
        mover = gameObject.AddComponent<CardMover>();
    }
    internal void WriteCardInfo()
    {
        TextMeshPro cardValueText = GetComponentInChildren<TextMeshPro>();
        cardValueText.text = $"{cardValue}";
        Blackjack.cardSumm =+ cardValue;
    }
    internal void FromPlayerToCenter(GameObject caller)
    {

    }
}
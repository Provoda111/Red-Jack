using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    [SerializeField] private int cardValue;
    private Animator cardAnimator;
    [SerializeField] internal bool isAtTheTable = false;
    [SerializeField] internal bool isAtTheHand = false;
    [SerializeField] internal Vector3 targetPosition;
    static internal Vector3 targetOffset;
    [SerializeField] private Deck deck;

    private void Start()
    {
        cardAnimator = GetComponent<Animator>();
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
        CardMover mover = gameObject.AddComponent<CardMover>();
        if (!isAtTheHand)
        {
            Gamer gamer = caller.GetComponent<Gamer>();
            if (gamer == null)
            {
                Debug.LogError("Caller is not a Gamer!");
                return;
            }

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

    }
    public void GoToCenter()
    {
        this.targetPosition = GameObject.Find("CheckpointForCenter").transform.position;
        targetPosition += targetOffset;

        CardMover mover = gameObject.AddComponent<CardMover>();
        mover.SetTarget(this.targetPosition, 1f);

        mover.OnReachedTarget += OnReachedCenter;
    }
    private void OnReachedCenter()
    {
        isAtTheTable = true;
        targetOffset = new Vector3(
            targetOffset.x + 0.226f,
            targetOffset.y,
            targetOffset.z);
        transform.SetParent(GameObject.Find("CardsAtTheCenter").transform, true);
    }

    internal void WriteCardInfo()
    {
        TextMeshPro cardValueText = GetComponentInChildren<TextMeshPro>();
        cardValueText.text = $"{cardValue}";
    }
}
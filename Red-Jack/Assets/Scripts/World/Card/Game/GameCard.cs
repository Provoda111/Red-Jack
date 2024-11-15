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
    [SerializeField] internal GameObject targetPosition;

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
        CardMover mover = gameObject.AddComponent<CardMover>(); ;
        if (!isAtTheHand)
        {
            Gamer gamer = caller.GetComponent<Gamer>();
            gamer.AddCardToSlot(this.gameObject);
            targetPosition.transform.position = gamer.slotPosition;
            mover.SetTarget(targetPosition.transform, 1f);
        }
        mover.OnReachedTarget += () =>
        {
            isAtTheHand = true;
            //Destroy(slotObject); 
        };

    }
    public void GetCard(GameObject caller)
    {
        /*CardMover mover = gameObject.AddComponent<CardMover>();
        if (!isAtTheHand)
        {
            Gamer gamer = caller.GetComponent<Gamer>();
            gamer.AddCardToSlot(this.gameObject);
            targetPosition.transform.position = gamer.slotPosition;
            mover.SetTarget(targetPosition.transform, 1f);
        }
        mover.OnReachedTarget += () =>
        {
            isAtTheHand = true;
        };*/
    }
    public void GoToDeck()
    {

    }
    public void GoToCenter()
    {
        targetPosition = GameObject.Find("CheckpointForCenter");

        CardMover mover = gameObject.AddComponent<CardMover>();
        mover.SetTarget(targetPosition.transform, 1f);

        mover.OnReachedTarget += OnReachedCenter;
    }
    private void OnReachedCenter()
    {
        isAtTheTable = true;
        targetPosition.transform.position = new Vector3(
            targetPosition.transform.position.x + 0.226f,
            targetPosition.transform.position.y,
            targetPosition.transform.position.z);
        transform.SetParent(GameObject.Find("CardsAtTheCenter").transform, true);
        
    }

    internal void WriteCardInfo()
    {
        TextMeshPro cardValueText = GetComponentInChildren<TextMeshPro>();
        cardValueText.text = $"{cardValue}";
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    [SerializeField] private int cardValue;
    private Animator cardAnimator;
    internal bool isAtTheTable = false;
    internal bool isAtTheHand = true;
    [SerializeField] internal GameObject targetPosition;

    private void Start()
    {
        cardAnimator = GetComponent<Animator>();
        
        targetPosition = GameObject.Find("CheckpointForCenter");
    }

    private void Update()
    {
        /// <summary>
        /// Fix card's permanent position
        /// /// </summary>
        //transform.position = new Vector3(startPosition.x, transform.position.y, startPosition.z); // Collider problem
        if (isAtTheTable)
        {
            if (targetPosition.name == "CheckpointForCenter")
            {
                targetPosition.transform.position = new Vector3(targetPosition.transform.position.x + 0.226f,
                targetPosition.transform.position.y,
                targetPosition.transform.position.z);
            }
            Destroy(GetComponent<CardMover>());
            isAtTheTable = false;
        }
        if (isAtTheHand)
        {
            WriteCardInfo();
        }
    }
    internal void GoToPlayer(GameObject caller)
    {
        Gamer gamer = caller.GetComponent<Gamer>();
        //targetPosition = GameObject.Find($"Slot 1");
        gamer.AddCardToSlot(this.gameObject);
        targetPosition.transform.position = gamer.slotPosition;
        
        /// <summary>
        /// Assignment: check if the caller of this void is player, then it goes to player's card slot.
        /// If the caller is enemy, then card goes to his card slot. 
        /// </summary>
        gameObject.AddComponent<CardMover>();
        gameObject.GetComponent<CardMover>().enabled = true;
    }
    public void GoToDeck()
    {

    }
    public void GoToCenter()
    {
        gameObject.AddComponent<CardMover>();
        gameObject.GetComponent<CardMover>().enabled = true;
        targetPosition = GameObject.Find("CheckpointForCenter");
        /*if (Vector3.Distance(transform.position, targetPosition.transform.position) < 0.01f)
        {
            targetPosition.transform.position = new Vector3(targetPosition.transform.position.x + 0.226f,
            targetPosition.transform.position.y,
            targetPosition.transform.position.z);
        }*/
        /*if (Vector3.Distance(transform.position, targetPosition.transform.position) < 0.01f)
        {
            transform.SetParent(GameObject.Find("CardsAtTheCenter").transform, true);
        }*/
    }
    internal void WriteCardInfo()
    {
        /*TextMeshPro cardValueText = GetComponentInChildren<TextMeshPro>();
        cardValueText.text = $"{cardValue}";*/
    }
}
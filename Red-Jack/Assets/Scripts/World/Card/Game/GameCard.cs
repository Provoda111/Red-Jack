using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    [SerializeField] private int cardValue;
    private Animator cardAnimator;
    private Vector3 startPosition;
    internal bool isAtTheTable = false;
    GameObject targetPosition;

    private void Start()
    {
        cardAnimator = GetComponent<Animator>();
        startPosition = transform.position;
        targetPosition = GameObject.Find("CheckpointForCenter");
    }

    private void LateUpdate()
    {
        //transform.position = new Vector3(startPosition.x, transform.position.y, startPosition.z); // Collider problem
        //if (isAtTheTable) { UpdatePosition(); } // Collider problem
        if (isAtTheTable)
        {
            targetPosition.transform.position = new Vector3(targetPosition.transform.position.x + 0.226f,
                targetPosition.transform.position.y,
                targetPosition.transform.position.z);
            gameObject.GetComponent<CardMover>().enabled = false;
            isAtTheTable = false;
        }
    }
    private void UpdatePosition()
    {
        
    }
    public void IsPointedAnimation()
    {
        cardAnimator.SetBool("cardRaise", true);
    }
    public void IsNotPointedAt()
    {
        cardAnimator.SetBool("cardRaise", false);
    }
    public void GoToPlayer()
    {

    }
    public void GoToDeck()
    {

    }
    public void GoToCenter()
    {
        gameObject.AddComponent<CardMover>();
        gameObject.GetComponent<CardMover>().enabled = true;
    }
}
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
    internal bool isAtTheHand = true;
    internal GameObject targetPosition;

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
            if (targetPosition.name == "CheckpointForCenter")
            {
                targetPosition.transform.position = new Vector3(targetPosition.transform.position.x + 0.226f,
                targetPosition.transform.position.y,
                targetPosition.transform.position.z);
            }
            //gameObject.GetComponent<CardMover>().enabled = false;
            Destroy(GetComponent<CardMover>());
            isAtTheTable = false;
        }
        if (isAtTheHand)
        {
            WriteCardInfo();
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
    internal void GoToPlayer()
    {
        gameObject.AddComponent<CardMover>();
        gameObject.GetComponent<CardMover>().enabled = true;
        targetPosition = GameObject.Find("Slot 1");
        
        
    }
    public void GoToDeck()
    {

    }
    public void GoToCenter()
    {
        gameObject.AddComponent<CardMover>();
        gameObject.GetComponent<CardMover>().enabled = true;
        targetPosition = GameObject.Find("CheckpointForCenter");
    }
    internal void WriteCardInfo()
    {
        TextMeshPro cardValueText = GetComponentInChildren<TextMeshPro>();
        cardValueText.text = $"{cardValue}";
    }
}
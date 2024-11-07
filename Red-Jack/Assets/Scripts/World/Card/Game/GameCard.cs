using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    [SerializeField] private int cardValue;
    private Animator cardAnimator;
    private Vector3 startPosition;

    public bool isAtTheTable = true;

    private void Start()
    {
        cardAnimator = GetComponent<Animator>();
        startPosition = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(startPosition.x, transform.position.y, startPosition.z); // Collider problem
        if (isAtTheTable) { UpdatePosition(); } // Collider problem
    }
    private void UpdatePosition()
    {
        
    }
    public void IsPointedAnimation()
    {
        Debug.Log("The card is watched at");
        cardAnimator.SetBool("cardRaise", true);
    }
    public void IsNotPointedAt()
    {
        Debug.Log("The card isn't watched at");
        cardAnimator.SetBool("cardRaise", false);
    }
    public void GoToPlayer()
    {

    }
    public void GoToDeck()
    {

    }
}
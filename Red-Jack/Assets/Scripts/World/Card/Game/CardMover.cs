using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardMover : MonoBehaviour
{
    GameCard cardController;
    private void Start()
    {
        cardController = gameObject.GetComponent<GameCard>();
    }
    void Update()
    {
        if (cardController.targetPosition != null)
        {
            float distance = Vector3.Distance(transform.position, cardController.targetPosition.transform.position);
            if (distance < 0.01f)
            {
                //if (cardController.target)
                //transform.SetParent(GameObject.Find("CardsAtTheCenter").transform, true);
                gameObject.GetComponent<GameCard>().isAtTheTable = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, cardController.targetPosition.transform.position,
                    Time.deltaTime * 1f);
            }
        }
    }
}
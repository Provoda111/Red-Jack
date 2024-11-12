using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardMover : MonoBehaviour
{
    void Update()
    {
        GameObject targetPosition = GameObject.Find("CheckpointForCenter");
        if (targetPosition != null)
        {
            float distance = Vector3.Distance(transform.position, targetPosition.transform.position);
            if (distance < 0.01f)
            {
                transform.SetParent(GameObject.Find("CardsAtTheCenter").transform, true);
                gameObject.GetComponent<GameCard>().isAtTheTable = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition.transform.position,
                    Time.deltaTime * 1f);
            }
        }
    }
}
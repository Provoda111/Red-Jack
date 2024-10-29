using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    [SerializeField] private int cardValue;
    private bool isPointedAt;

    private void Update()
    {
        if (isPointedAt)
        {
            Debug.Log("The card is watched at");
        }
    }
}

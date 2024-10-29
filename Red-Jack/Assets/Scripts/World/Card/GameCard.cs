using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    [SerializeField] private int cardValue;
    public bool isPointedAt;

    private void Update()
    {
        if (isPointedAt)
        {
            isPointedAnimation();
        }
    }
    private void isPointedAnimation()
    {
        Debug.Log("The card is watched at");
    }
}

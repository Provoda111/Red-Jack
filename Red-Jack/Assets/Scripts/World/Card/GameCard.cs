using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    [SerializeField] private int cardValue;
    [SerializeField] private Animator cardAnimator;

    private void Update()
    {
    }
    public void isPointedAnimation()
    {
        Debug.Log("The card is watched at");
        cardAnimator.SetTrigger("cardRaise");
    }
}

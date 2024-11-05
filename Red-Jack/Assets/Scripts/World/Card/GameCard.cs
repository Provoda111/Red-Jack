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
}

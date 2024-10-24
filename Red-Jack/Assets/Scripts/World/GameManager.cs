using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> cardDeck = new List<GameObject>();
    [SerializeField] private GameCard card;

    public Animator deckAnimator;

    private void Update()
    {
        
    }
    private void CardChooseStep()
    {

    }
    IEnumerator gameStart()
    {
        
        yield return new WaitForSeconds(5f);
    }
}

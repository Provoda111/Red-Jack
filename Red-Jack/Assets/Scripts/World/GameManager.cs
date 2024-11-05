using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> cardDeck = new List<GameObject>();
    [SerializeField] private GameCard card;
    public Animator deckAnimator;
    public Player player;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.H)) //If test №1
        {
            StartCoroutine(gameStart());
        }
    }
    private void CardChooseStep()
    {

    }
    IEnumerator gameStart()
    {
        deckAnimator.SetTrigger("HasShuffled");
        yield return new WaitForSeconds(5f);
        deckAnimator.SetTrigger("HasFlipped");
    }
}

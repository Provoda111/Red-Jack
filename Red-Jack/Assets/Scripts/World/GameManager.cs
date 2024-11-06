using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> cardDeck = new List<GameObject>();
    public GameObject cardDeckObject;
    [SerializeField] private GameCard card;
    public Animator deckAnimator;
    public Player player;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.H)) //If test №1
        {
            StartCoroutine(GiveCards());
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
    IEnumerator GiveCards()
    {
        yield return new WaitForSeconds(3.5f);
        for (int i = 0; i < 2; i++)
        {
            int cardIndex = Random.Range(0, cardDeck.Count);
            Debug.Log(cardIndex);
            Instantiate(cardDeck[cardIndex], cardDeckObject.transform);
            cardDeck.Remove(cardDeck[cardIndex]);
        }
    }
}

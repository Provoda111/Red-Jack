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
        for (int i = 0; i < 3; i++)
        {
            int cardIndex = Random.Range(0, cardDeck.Count);
            GameCard selectedCard = cardDeck[cardIndex].GetComponent<GameCard>();
            Debug.Log(cardIndex);
            Instantiate(cardDeck[cardIndex], cardDeckObject.transform);
            StartCoroutine(selectedCard.GoToCenter());
            //selectedCard.StartCoroutine(GoToCenter()); | TEST IT #1
            cardDeck.RemoveAt(cardIndex);
            yield return new WaitForSeconds(3.5f);

        }
    }
}
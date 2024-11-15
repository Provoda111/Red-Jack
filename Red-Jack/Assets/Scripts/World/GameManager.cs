using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> cardDeck = new List<GameObject>();
    public GameObject cardDeckObject;
    //[SerializeField] private GameCard card;
    public Animator deckAnimator;
    public Player player;
    public Transform cardSpawner;

    internal Quaternion cardRotation;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.H)) //If test №1
        {
            StartCoroutine(GiveCards());
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            GivePlayerCard();
        }
    }
    private void CardChooseStep()
    {

    }
    
    public void GiveCardsActivator() // For demo
    {
        StartCoroutine(GiveCards());
    }
    public void GivePlayerCard() // For demo
    {
        int cIndex = Random.Range(0, cardDeck.Count);
        GameObject cardSpawner = GameObject.Find("CardSpawner");
        GameObject cardObject = Instantiate(cardDeck[cIndex], cardSpawner.transform);
        GameCard card = cardObject.GetComponent<GameCard>();
        card.GoToPlayer(GameObject.Find("Player"));
        cardDeck.Remove(cardDeck[cIndex]);
    }
    IEnumerator gameStart()
    {
        deckAnimator.SetTrigger("HasShuffled");
        yield return new WaitForSeconds(5f);
        deckAnimator.SetTrigger("HasFlipped");
    }
    public IEnumerator GiveCards()
    {
        for (int i = 0; i < 3; i++)
        {
            int cardIndex = Random.Range(0, cardDeck.Count);
            cardRotation.eulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
            GameObject cardObject = Instantiate(cardDeck[cardIndex], cardSpawner.transform.position, cardRotation);
            //cardObject.transform.SetParent(GameObject.Find("CardToCenter").transform, true);
            GameCard card = cardObject.GetComponent<GameCard>();
            card.GoToCenter();
            card.gameObject.name = $"Card{i + 1}";
            cardDeck.Remove(cardDeck[cardIndex]);
            yield return new WaitForSeconds(3.5f);
        }
    }
    /*IEnumerator GivePlayerCardFromDeck()
    {
        for (int i = 0; i < 1; i++)
        {
            int cardIndex = Random.Range(0, cardDeck.Count);
            GameObject cardSpawner = GameObject.Find("CardSpawner");
            GameObject cardObject = Instantiate(cardDeck[cardIndex], cardSpawner.transform);
            GameCard card = cardObject.GetComponent<GameCard>();
            //card.GoToPlayer();
            cardDeck.Remove(cardDeck[cardIndex]);
        }
        yield return new WaitForSeconds(1f);
    }*/
}
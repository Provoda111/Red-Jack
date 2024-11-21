using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cardDeckObject;
    //[SerializeField] private GameCard card;
    public Player player;
    public Enemy enemy;
    public Transform cardSpawner;
    private Deck deck;

    internal Quaternion cardRotation;

    private void Start()
    {
        deck = GameObject.Find("Deck").GetComponent<Deck>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.H)) //If test №1
        {
            StartCoroutine(deck.CardsToCenter());
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            StartCoroutine(GiveCardToGamers());
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            enemy.ChooseRandomCardFromCenter();
        }
    }
    private IEnumerator GiveCardToGamers()
    {
        for (int i = 0; i < 1; i++)
        {
            if (GamerChooser.playerMove)
            {
                deck.GiveCardToPlayer(player.gameObject);
                yield return new WaitForSeconds(3f);
                deck.GiveCardToPlayer(enemy.gameObject);
            }
        }
        yield return new WaitForSeconds(3f);
    }
}
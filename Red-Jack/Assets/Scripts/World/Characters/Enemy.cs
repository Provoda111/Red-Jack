using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : Gamer
{
    public GameObject carddd;
    private GameObject selectCard;
    public void Start()
    {
        gamerSlots = GameObject.FindGameObjectsWithTag("Enemy's card").ToList();
        gameCards = new List<GameObject>();
        buffCards = new List<GameObject>();
        hasLost = false;
    }
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            GameCard card = carddd.GetComponent<GameCard>();
            card.GoToPlayer(this.gameObject);
        }
    }
}

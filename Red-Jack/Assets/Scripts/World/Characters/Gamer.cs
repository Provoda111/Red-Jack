using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamer : MonoBehaviour
{
    [SerializeField] internal List<GameObject> slots = new List<GameObject>();
    internal List<GameObject> gameCards = new List<GameObject>();
    internal List<GameObject> buffCards = new List<GameObject>();

    protected bool hasLost;

    internal void SelectCard()
    {

        GameCard card = GetComponent<GameCard>();
    }

    /*protected Gamer(List<GameObject> slots, List<GameObject> gameCards, List<GameObject> buffCards, bool hasLost)
    {
        this.slots = slots;
        this.gameCards = gameCards;
        this.buffCards = buffCards;
        this.hasLost = hasLost;
    }*/
}

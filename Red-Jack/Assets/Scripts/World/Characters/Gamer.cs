using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamer : MonoBehaviour
{
    [SerializeField] internal List<GameObject> gamerSlots = new List<GameObject>();
    internal List<GameObject> gameCards = new List<GameObject>();
    internal List<GameObject> buffCards = new List<GameObject>();

    protected bool hasLost;

    internal Vector3 slotPosition;

    public GameObject helpCardObject;
    private Deck deck;
    private void Start()
    {
        deck = GameObject.Find("Deck").GetComponent<Deck>();
    }
    internal void AddCardToSlot(GameObject cardObject)
    {
        helpCardObject = cardObject;
        Transform slotDetect = gamerSlots.Find(x => x.name.Contains("Slot")).transform;
        if (slotDetect.childCount == 0)
        {
            slotPosition = slotDetect.position;
            //deck.GiveCardToPlayer();
            gameCards.Add(cardObject);
            gamerSlots.RemoveAt(0);
        }
        //Vector3 slotPosition = gamerSlots.Find(x => x.name.Contains("Slot")).transform.position;
        // GameObject slotPosition = GameObject.Find("Slot", emptySlots.Find(cardObject));
    }
    internal void RemoveCardFromSlot(GameObject cardObject)
    {
        if (gamerSlots.Count > 0)
        {
            gamerSlots.Add(cardObject);
        }
    }
}
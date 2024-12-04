using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamer : MonoBehaviour
{
    [SerializeField] internal List<GameObject> gamerSlots = new List<GameObject>();
    [SerializeField] internal List<GameObject> buffSlots = new List<GameObject>();
    [SerializeField] internal List<GameObject> gameCards = new List<GameObject>();
    [SerializeField] internal List<GameObject> buffCards = new List<GameObject>();
    internal int gamerValues;

    static internal bool hasLost = false;

    internal Vector3 slotPosition;
  
    [SerializeField] internal Deck deck;
    private void Start()
    {
        deck = GameObject.Find("Deck").GetComponent<Deck>();
    }
    internal void AddCardToSlot(GameObject cardObject)
    {
        if (gameCards.Count <= 5)
        {
            GameObject slotDetect = gamerSlots.Find(x => x.name.Contains("Slot"));
            Transform slotTransform = slotDetect.transform;
            if (slotTransform.childCount == 0)
            {
                slotPosition = slotTransform.position;
                gameCards.Add(cardObject);
                gamerSlots.Remove(slotDetect);
                cardObject.transform.SetParent(slotTransform, true);
            }
            else
            {
                Debug.LogError("Slot already occupied!");
            }
            gamerValues += cardObject.GetComponent<GameCard>().cardValue;
        }
    }
    internal void RemoveCardFromSlot(GameObject cardObject)
    {
        if (gamerSlots.Count > 0)
        {
            gameCards.Remove(cardObject);
            gamerValues -= cardObject.GetComponent<GameCard>().cardValue;
        }
    }
    internal void AddBuffCard(GameObject buffCardObject)
    {
        var slotDetect = gamerSlots.Find(x => x.name.Contains("Slot"));

        Transform slotTransform = slotDetect.transform;
        buffCards.Add(buffCardObject);
        buffSlots.Remove(slotDetect);
    }
    internal void RemoveBuffCard(GameObject buffCardObject)
    {
        if (buffCards.Count > 0)
        {

        }
    }
    internal void Surrender()
    {

    }
}
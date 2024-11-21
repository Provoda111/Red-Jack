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

        if (gamerSlots == null || gamerSlots.Count == 0)
        {
            Debug.LogError("No available slots in gamerSlots!");
            return;
        }

        var slotDetect = gamerSlots.Find(x => x.name.Contains("Slot"));
        if (slotDetect == null)
        {
            Debug.LogError("No suitable slot found in gamerSlots!");
            return;
        }

        Transform slotTransform = slotDetect.transform;
        if (slotTransform.childCount == 0)
        {
            slotPosition = slotTransform.position;
            gameCards.Add(cardObject);
            gamerSlots.Remove(slotDetect);
        }
        else
        {
            Debug.LogError("Slot already occupied!");
        }
    }
    internal void RemoveCardFromSlot(GameObject cardObject)
    {
        if (gamerSlots.Count > 0)
        {
            gamerSlots.Add(cardObject);
        }
    }
}
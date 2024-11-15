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

    internal void AddCardToSlot(GameObject cardObject)
    {
        // Find the first available slot from gamers possible slots?
        // set the cards targetposition to move to
        // Signal the move?
        // Tell the slot is taken
        if (gamerSlots.Count < 5)
        {
            
        }
        Transform slotDetect = gamerSlots.Find(x => x.name.Contains("Slot")).transform;
        if (slotDetect.childCount == 0)
        {
            slotPosition = slotDetect.position;
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

    /*protected Gamer(List<GameObject> slots, List<GameObject> gameCards, List<GameObject> buffCards, bool hasLost)
    {
        this.slots = slots;
        this.gameCards = gameCards;
        this.buffCards = buffCards;
        this.hasLost = hasLost;
    }*/
}

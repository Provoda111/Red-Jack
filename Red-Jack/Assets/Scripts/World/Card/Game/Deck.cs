using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private Animator deckAnimator;
    public void GetCard(GameObject caller)
    {
        GameObject slotObject = new GameObject("SlotPosition");
        CardMover mover = gameObject.AddComponent<CardMover>();
        

        Gamer gamer = caller.GetComponent<Gamer>();
        gamer.AddCardToSlot(this.gameObject);

        slotObject.transform.position = gamer.slotPosition;
        mover.SetTarget(slotObject.transform, 1f);
        mover.OnReachedTarget += () =>
        {
            Destroy(slotObject);
        };
    }
}

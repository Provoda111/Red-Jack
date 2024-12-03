using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject cardStandText;
    [SerializeField] private GameObject cardHitText;
    [SerializeField] private GameObject cardSurrenderText;
    [SerializeField] private Player player;
    [SerializeField] private Deck deck;

    // Update is called once per frame
    void Update()
    {
        if (deck.cardHasBeenSharedToGamers)
        {
            if (GamerChooser.playerMove)
            {
                ShowButtonUI();
                if (Input.GetKeyUp(KeyCode.H))
                {
                    BlackJackHit();
                    GamerChooser.PlayerHasMoved();
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    BlackJackStand();
                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    BlackJackSurrender();
                }
            }
        }
        else
        {
            HideButtonUI();
        }
    }
    private void ShowButtonUI()
    {
        cardStandText.SetActive(true);
        cardHitText.SetActive(true);
        cardSurrenderText.SetActive(true);
    }
    private void HideButtonUI()
    {
        cardStandText.SetActive(false);
        cardHitText.SetActive(false);
        cardSurrenderText.SetActive(false);
    }
    private void BlackJackHit()
    {
        Debug.Log("1");
        deck.GiveCardToPlayer(player.gameObject);
        Debug.Log("2");
    }
    private void BlackJackStand()
    {
        if (GamerChooser.playerMove)
        {
            Debug.Log("Player doesn't wan't to move");
            GamerChooser.PlayerHasMoved();
        }
    }
    private void BlackJackSurrender()
    {
        if (GamerChooser.playerMove)
        {
            Debug.Log("Surrender");
        }
    }
}

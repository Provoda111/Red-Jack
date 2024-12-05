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
    private void OnEnable()
    {
        GamerChooser.OnPlayerMoveChanged += UpdateUIVisibility; 
    }

    private void OnDisable()
    {
        GamerChooser.OnPlayerMoveChanged -= UpdateUIVisibility; 
    }

    private void UpdateUIVisibility()
    {
        if (Deck.cardHasBeenSharedToGamers && GamerChooser.playerMove)
        {
            ShowButtonUI();
        }
        else
        {
            HideButtonUI();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Deck.cardHasBeenSharedToGamers)
        {
            if (GamerChooser.playerMove)
            {
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
        UpdateUIVisibility();
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
        deck.GiveCardToPlayer(player.gameObject);
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
        Player.skipMove = false;
        if (GamerChooser.playerMove)
        {
            Debug.Log("Surrender");
            Player.skipMove = true;
        }
    }
}
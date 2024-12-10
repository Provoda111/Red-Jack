using System;
using UnityEngine;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject cardStandText;
    [SerializeField] private GameObject cardHitText;
    [SerializeField] private GameObject cardSurrenderText;
    [SerializeField] private Player player;
    [SerializeField] private Deck deck;
    [SerializeField] private GameObject buffCardUI;
    [SerializeField] private GameObject escapeMenu;

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
        if (Deck.cardHasBeenSharedToGamers && GamerChooser.playerMove)
        {
            HandlePlayerInput();
        }
        UpdateUIVisibility();
    }

    private void HandlePlayerInput()
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
        if (Input.GetKeyUp(KeyCode.T))
        {
            ShowBuffCardUI();
        }
        if (Input.GetKeyUp(KeyCode.Escape)) 
        {
            if (buffCardUI.activeSelf == true)
            {
                HideBuffCardUI();
            }
            else if (escapeMenu.activeSelf == false)
            {
                ShowEscmenu();
            }
            else if (escapeMenu.activeSelf == true)
            {
                HideEscmenu();
            }
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
        deck.GiveCardToPlayer(player.gameObject);
    }
    private void BlackJackStand()
    {
        if (!GamerChooser.playerMove) return;
        GamerChooser.PlayerHasMoved();
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
    private void ShowBuffCardUI() => buffCardUI.SetActive(true);
    private void HideBuffCardUI() => buffCardUI.SetActive(false);
    private void ShowEscmenu() => escapeMenu.SetActive(true);
    private void HideEscmenu() => escapeMenu.SetActive(false);
}
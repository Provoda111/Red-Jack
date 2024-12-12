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
        if (Deck.cardHasBeenSharedToGamers)
        {
            HandlePlayerInput();
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            BuffcardUI buffcardUI = GameObject.Find("buffCardUIController").GetComponent<BuffcardUI>();
            buffcardUI.DrawCardOnMenu();
            //ShowBuffCardUI();
        }
        UpdateUIVisibility();
    }

    private void HandlePlayerInput()
    {
        Player.skipMove = false;
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
            if (Input.GetKeyUp(KeyCode.T))
            {
                //BuffcardUI buffcardUI = GameObject.Find("buffCardUIController").GetComponent<BuffcardUI>();
                //buffcardUI.DrawCardOnMenu();
                //ShowBuffCardUI();
            }
        }
        if (Input.GetKeyUp(KeyCode.Escape)) 
        {
            Debug.Log("3");
            if (buffCardUI.activeSelf == true && !escapeMenu.activeSelf)
            {
                HideBuffCardUI();
            }
            if (!escapeMenu.activeSelf)
            {
                Debug.Log("1");
                escapeMenu.SetActive(true);
            }
            else if (escapeMenu.activeSelf)
            {
                Debug.Log("2");
                escapeMenu.SetActive(false);
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
        Player.skipMove = false;
        deck.GiveCardToPlayer(player.gameObject);
    }
    private void BlackJackStand()
    {
        Player.skipMove = true;
        if (!GamerChooser.playerMove) return;
        GamerChooser.PlayerHasMoved();
    }
    private void BlackJackSurrender()
    {
        if (GamerChooser.playerMove)
        {
            Debug.Log("Surrender");
        }
    }
    private void ShowBuffCardUI() => buffCardUI.SetActive(true);
    private void HideBuffCardUI() => buffCardUI.SetActive(false);
    /*public void TryEndGame()
    {
        if (Player.skipMove && Enemy.skipMove)
        {
            Debug.Log("Both players chose to stand. Checking game results.");
            FindObjectOfType<Blackjack>().EndGameCheck();
        }
    }*/
}
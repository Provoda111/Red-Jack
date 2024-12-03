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
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GamerChooser.playerMove)
        {
            ShowButtonUI();
        }
        if (GamerChooser.enemyMove)
        {
            HideButtonUI();
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            BlackJackHit();
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
        Debug.Log("A");
        if (GamerChooser.playerMove)
        {
            deck.GiveCardToPlayer(player.gameObject);
            GamerChooser.PlayerHasMoved();
        }
    }
    private void BlackJackStand()
    {
        if (GamerChooser.playerMove)
        {
            Debug.Log("Player doesn't wan't to move");
        }
    }
    private void BlackJackSurrender()
    {
        if (GamerChooser.playerMove)
        {

        }
    }
}

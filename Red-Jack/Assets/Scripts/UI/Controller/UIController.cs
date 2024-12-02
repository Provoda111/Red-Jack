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
        if (Input.GetKeyUp(KeyCode.H))
        {
            if (GamerChooser.playerMove)
            {
                player.AddCardToSlot(player.gameObject);
            }
            GamerChooser.PlayerHasMoved();
        }
    }
    private void BlackJackStand()
    {
        if (GamerChooser.playerMove)
        {

        }
    }
    private void BlackJackSurrender()
    {
        if (GamerChooser.playerMove)
        {

        }
    }
}

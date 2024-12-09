using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;
using UnityEngine.Playables;
public class Cutscene : MonoBehaviour
{
    // Classes and Game objects
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Deck deck;
    [SerializeField] private PlayerCamera playerCamera;
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    // Audio controller



    // Animation controller

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator deckAnimator;


    // Variables

    [SerializeField] private bool firstStepDone = false;

    [SerializeField] private int gameStep;

    [SerializeField] private PlayableDirector director1;


    // Start is called before the first frame update
    void Start()
    {
        gameStep = 1;
    }
    
    void Update()
    {
        GameFirstStep();
    }
    static internal void PauseTimeline()
    {

    }
    private void GameFirstStep()
    {
        switch (gameStep)
        {
            case 1:
                if (Deck.cardHasBeenSharedToCenter)
                {
                    StartCoroutine(deck.GiveCardToGamers());
                    if (enemy.gameCards.Count == 2 && player.gameCards.Count == 2) // bug
                    {
                        gameStep++;
                    }
                }
                break;
            case 2:
                if (GamerChooser.enemyMove)
                {
                    enemy.MoveOrNo();
                }
                break;
        }
        /*switch (gameStep)
        {
            case 1:
                StartCoroutine(player.LaunchAwakeAnimation());
                gameStep++;
                break;
            case 2:
                if (!playerAnimator.GetBool("Awake"))
                {
                    //gameStep++;
                }
                break;
            case 3:           
                StartCoroutine(deck.CardsToCenter());
                StartCoroutine(WaitTime(3f));
                gameStep++;
                break;
            case 4:
                StartCoroutine(WaitTime(3f));
                if (Deck.cardHasBeenSharedToCenter)
                {
                    enemy.ChooseRandomCardFromCenter();
                    if (player.gamerSlots.Count < 5 && enemy.gamerSlots.Count < 5)
                    {
                        gameManager.CardGoesBackToDeck();
                        gameStep++;
                    }
                }
                break;
            case 5:
                StartCoroutine(deck.GiveCardToGamers());
                gameStep++;
                break;
            case 6:
                if (Deck.cardHasBeenSharedToGamers)
                {
                    if (GamerChooser.enemyMove)
                    {
                        enemy.MoveOrNo();
                        GamerChooser.enemyMove = false;
                    }
                }
                break;
        }*/
    }
}

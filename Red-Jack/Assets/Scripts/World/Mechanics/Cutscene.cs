using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;
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


    // Start is called before the first frame update
    void Start()
    {
        GamerChooser.MoveDeterminer();
        gameStep = 1;
    }
    private void Awake()
    {
        StartCoroutine(GameFirstStep());
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(GameFirstStep());
    }
    private IEnumerator GameFirstStep()
    {
        switch (gameStep)
        {
            case 1:
                playerAnimator.SetBool("Awake", true);
                yield return new WaitForSeconds(14f);
                playerAnimator.SetBool("Awake", false);
                yield return new WaitForSeconds(2f);
                gameStep += 1;
                yield break;
            case 2:
                StartCoroutine(deck.CardsToCenter());
                if (deck.cardHasBeenSharedToCenter)
                {
                    enemy.ChooseRandomCardFromCenter();
                    gameStep += 1;
                }
                yield break;
            case 3:
                enemy.ChooseRandomCardFromCenter();
                yield break;
            case 4:
                yield return new WaitForSeconds(10f);
                StartCoroutine(deck.GiveCardToGamers());
                yield break;
            case 5:
                yield break;
        }
        Debug.Log("");
    }
}

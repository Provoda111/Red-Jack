using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    // Classes and Game objects
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Deck deck;
    [SerializeField] private PlayerCamera playerCamera;

    // Audio controller



    // Animation controller

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator deckAnimator;


    // Variables

    [SerializeField] private bool firstStepDone = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
        // Closing eyes thing (MAYBE)
        

        playerAnimator.SetBool("Awake", true);
        yield return new WaitForSeconds(14f);
        playerAnimator.SetBool("Awake", false);
        

        yield return new WaitForSeconds(2f);

        StartCoroutine(deck.CardsToCenter());
    }
}

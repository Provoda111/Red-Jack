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

    // Audio controller



    // Animation controller

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator deckAnimator;


    // Variables

    [SerializeField] private bool firstStepDone = false;

    [SerializeField] private PostProcessVolume postProcessingVolume; // Assign via Inspector
    [SerializeField] private AnimationCurve openingCurve; // Define in Inspector

    // Variables
    [SerializeField] private float vignetteDuration = 2f; // Eye-opening effect duration

    private Vignette vignette;

    // Start is called before the first frame update
    void Start()
    {
        GamerChooser.MoveDeterminer();
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

        yield return new WaitForSeconds(4f);

    }
    private IEnumerator OpenEyes()
    {
        if (postProcessingVolume.profile.TryGetSettings(out Vignette v))
        {
            vignette = v;
        }
        else
        {
            Debug.LogError("Vignette effect is not set in the Post-Processing Volume.");
            yield break;
        }

        // Step 1: Eye-opening effect
        float elapsedTime = 0f;
        float initialIntensity = 1f;
        vignette.intensity.value = initialIntensity;

        while (elapsedTime < vignetteDuration)
        {
            elapsedTime += Time.deltaTime;

            // Smoothly reduce intensity using the animation curve
            float t = elapsedTime / vignetteDuration;
            vignette.intensity.value = Mathf.Lerp(initialIntensity, 0f, openingCurve.Evaluate(t));

            yield return null;
        }

        // Ensure vignette intensity is fully off at the end
        vignette.intensity.value = 0f;
    }
}

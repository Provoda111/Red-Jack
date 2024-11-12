using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    private bool hasLost;
    [SerializeField] private List<GameObject> playerCards = new List<GameObject>();
    private List<BuffCard> buffCards = new List<BuffCard>();
    private GameObject card;
    private GameObject rayHitCard;
    public UnityEngine.Camera cursorCamera;
    private string hitTag;

    private Camera gameCamera;

    [SerializeField] LayerMask layersToHit;
    Ray ray;
    RaycastHit hit;

    public Animator animator;

    private GameCard cardController;

    // Audio variables

    private void Start()
    {
        gameCamera = GetComponent<Camera>();
    }
    private void Update()
    {
        ray = cursorCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2 + 10, 0));
        Debug.DrawRay(ray.origin, ray.direction * 1000);
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            if (hit.collider.CompareTag("Card"))
            {
                /*rayHitCard = hit.collider.gameObject;
                card = rayHitCard;
                cardController = card.GetComponent<GameCard>();*/
            }
        }
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            hitTag = hit.collider.tag;
            /*if (gameCamera.canMoveCamera)
            {
                if (hit.collider.CompareTag("Card")) { cardController.IsPointedAnimation(); }
                else { cardController.IsNotPointedAt(); }
            }*/
        }
        AnimationHandler();
    }
    private void OnGUI()
    {
        //GUI.Label(new Rect(10, 10, 1000, 100), hitTag);
    }
    private void AnimationHandler()
    {
    }
}
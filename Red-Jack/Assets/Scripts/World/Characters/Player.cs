using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : Gamer
{
    private GameObject card;
    private GameObject rayHitCard;
    public UnityEngine.Camera cursorCamera;
    private string hitTag;

    private PlayerCamera gameCamera;

    [SerializeField] LayerMask layersToHit;
    Ray ray;
    RaycastHit hit;

    public Animator animator;

    public GameObject carddd;

    // Audio variables

    public void Start()
    {
        gamerSlots = GameObject.FindGameObjectsWithTag("Player's card").ToList();
        gameCards = new List<GameObject>();
        buffCards = new List<GameObject>();
        hasLost = false;
        gameCamera = GetComponent<PlayerCamera>();
    }
    private void Update()
    {
        ray = cursorCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2 + 10, 0));
        Debug.DrawRay(ray.origin, ray.direction * 1000);
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            hitTag = hit.collider.tag;
            if (hitTag == "Card")
            {
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    GameCard card = hit.collider.gameObject.GetComponent<GameCard>();
                    card.GoToPlayer(this.gameObject);
                }
                /*rayHitCard = hit.collider.gameObject;
                card = rayHitCard;
                cardController = card.GetComponent<GameCard>();*/
            }
        }
    }
    private void OnGUI()
    {
        //GUI.Label(new Rect(10, 10, 1000, 100), hitTag);
    }
}
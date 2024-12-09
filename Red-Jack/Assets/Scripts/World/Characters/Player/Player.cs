using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : Gamer
{

    public UnityEngine.Camera cursorCamera;
    private string hitTag;

    [SerializeField] private PlayerCamera gameCamera;

    [SerializeField] LayerMask layersToHit;
    Ray ray;
    RaycastHit hit;

    public Animator animator;

    // Audio variables

    public void Start()
    {
        gamerSlots = GameObject.FindGameObjectsWithTag("Player's card").ToList();
        gamerSlots.Sort(delegate (GameObject x, GameObject y)
        {
            return x.name.CompareTo(y.name);
        });
        buffSlots = GameObject.FindGameObjectsWithTag("Player's buff").ToList();
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
                    ChooseCardByMouse();
                }
            }
        }
    }
    private void ChooseCardByMouse()
    {
        if (GamerChooser.playerMove)
        {
            GameCard card = hit.collider.gameObject.GetComponent<GameCard>();
            if (card.isAtTheCenter)
            {
                card.GoToPlayer(this.gameObject);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    private bool hasLost;
    [SerializeField] private List<GameObject> playerCards = new List<GameObject>();
    public List<BuffCard> buffCards = new List<BuffCard>();
    private GameCard card;

    [SerializeField] LayerMask layersToHit;

    Ray ray;
    RaycastHit hit;

    public Animator animator;

    // Audio variables

    private void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, 20, layersToHit))
        {
            if (hit.collider.tag == "Card")
            {
                Debug.Log($"Player's raycast has hit the {hit.collider.gameObject.name}");
                card.isPointedAt = true;
            }
        }
        AnimationHandler();
    }
    private void AnimationHandler()
    {
        
    }
}

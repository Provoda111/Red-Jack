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
    public List<BuffCard> buffCards = new List<BuffCard>();
    private GameCard card;
    public UnityEngine.Camera cursorCamera;
    private string hitTag;

    [SerializeField] LayerMask layersToHit;
    Ray ray;
    RaycastHit hit;

    public Animator animator;

    // Audio variables

    private void Update()
    {
        ray = cursorCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2 + 10, 0));
        Debug.DrawRay(ray.origin, ray.direction * 1000);
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            hitTag = hit.collider.tag;
            if (hit.collider.tag == "Card")
            {
                card.isPointedAnimation();
            }
        }
        
        AnimationHandler();
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 1000, 100), hitTag);
    }
    private void AnimationHandler()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    [SerializeField] private int cardValue;
    private Animator cardAnimator;
    private Vector3 startPosition;

    public bool isAtTheTable = true;

    private void Start()
    {
        cardAnimator = GetComponent<Animator>();
        startPosition = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(startPosition.x, transform.position.y, startPosition.z); // Collider problem
        if (isAtTheTable) { UpdatePosition(); } // Collider problem
    }
    private void UpdatePosition()
    {
        
    }
    public void IsPointedAnimation()
    {
        cardAnimator.SetBool("cardRaise", true);
    }
    public void IsNotPointedAt()
    {
        cardAnimator.SetBool("cardRaise", false);
    }
    public void GoToPlayer()
    {

    }
    public void GoToDeck()
    {

    }
    public IEnumerator GoToCenter()
    {
        GameObject targetPosition = GameObject.Find("CheckpointForCenter");
        
        while (Vector3.Distance(transform.position, targetPosition.transform.position) < 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition.transform.position, 2.0f * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition.transform.position;
        targetPosition.transform.position = new Vector3(targetPosition.transform.position.x - 0.37296f, targetPosition.transform.position.y, targetPosition.transform.position.z);
        //cardAnimator.SetTrigger("cardToTheCenter");
        //yield return new WaitForSeconds(3.5f); | TEST IT #1
    }
}
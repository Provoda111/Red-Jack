using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMover : MonoBehaviour
{
    private Vector3 target;
    private float speed = 1f;

    public event Action OnReachedTarget;
   
    public void SetTarget(Vector3 targetPosition, float moveSpeed)
    {
        target = targetPosition;
        speed = moveSpeed;
    }

    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, target) < 0.01f)
            {
                OnReachedTarget?.Invoke();
                Destroy(this); 
            }
        }
    }

}
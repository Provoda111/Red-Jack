using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardMover : MonoBehaviour
{
    private Transform target;
    private float speed = 1f;

    public event Action OnReachedTarget;
   
    public void SetTarget(Transform targetPosition, float moveSpeed)
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
                target.position,
                Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, target.position) < 0.01f)
            {
                OnReachedTarget?.Invoke();
                Destroy(this); 
            }
        }
    }

}
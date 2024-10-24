using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool hasLost;
    public List<BuffCard> buffCards = new List<BuffCard>();
    [SerializeField] private List<GameObject> enemyCards = new List<GameObject>();
}

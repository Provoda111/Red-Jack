using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Gamer
{
    public void Start()
    {
        slots = new List<GameObject>();
        gameCards = new List<GameObject>();
        buffCards = new List<GameObject>();
        hasLost = false;
    }
}

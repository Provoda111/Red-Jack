using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GamerChooser
{
    [SerializeField] static internal bool playerMove = false;
    [SerializeField] static internal bool enemyMove = true;
    static internal string whoMoves;
    static private int randomNumber;

    /*internal static void MoveDeterminer() // NEEDS TO BE OPTIMIZED
    {
        randomNumber = Random.Range(0, 2);
        switch (randomNumber)
        {
            case 0:
                playerMove = true;
                whoMoves = "Player";
                break;
            case 1:
                enemyMove = true;
                whoMoves = "Enemy";
                break;
        }
    }*/
    internal static void PlayerHasMoved() // NEEDS TO BE OPTIMIZED
    {
        Debug.Log("Enemy is moving");
        playerMove = false;
        enemyMove = true;
    }
    internal static void EnemyHasMoved() // NEEDS TO BE OPTIMIZED
    {
        Debug.Log("Player is moving");
        playerMove = true;
        enemyMove = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GamerChooser
{
    static internal bool playerMove = false;
    static internal bool enemyMove = false;
    static internal string whoMoves;
    static private int randomNumber;

    internal static void MoveDeterminer()
    {
        randomNumber = Random.Range(1, 2);
        switch (randomNumber)
        {
            case 1:
                playerMove = true;
                whoMoves = "Player";
                break;
            case 2:
                enemyMove = true;
                whoMoves = "Enemy";
                break;
        }
    }

    internal static void PlayerHasMoved()
    {
        playerMove = false;
        enemyMove = true;
    }
    internal static void EnemyHasMoved()
    {
        playerMove = true;
        enemyMove = false;
    }
}

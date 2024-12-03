using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GamerChooser
{
    [SerializeField] static internal bool playerMove = false;
    [SerializeField] static internal bool enemyMove = true;
    static internal string whoMoves;
    static private int randomNumber;

    internal static void PlayerHasMoved() // NEEDS TO BE OPTIMIZED
    {
        Debug.Log("A");
        playerMove = false;
        enemyMove = true;
        Debug.Log("B");
    }
    internal static void EnemyHasMoved() // NEEDS TO BE OPTIMIZED
    {
        playerMove = true;
        enemyMove = false;
    }
}

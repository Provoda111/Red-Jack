using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GamerChooser
{
    [SerializeField] static internal bool playerMove = false;
    [SerializeField] static internal bool enemyMove = true;

    public static event System.Action OnPlayerMoveChanged;

    internal static void PlayerHasMoved()
    {
        playerMove = false;
        enemyMove = true;
        OnPlayerMoveChanged?.Invoke();
    }
    internal static void EnemyHasMoved()
    {
        playerMove = true;
        enemyMove = false;
        OnPlayerMoveChanged?.Invoke();
    }
}

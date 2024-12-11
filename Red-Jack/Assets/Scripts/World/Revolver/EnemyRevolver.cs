using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRevolver : MonoBehaviour
{
    private Revolver revolver;
    private Blackjack blackjack;
    void Start()
    {
        revolver = GetComponent<Revolver>();
        blackjack = GetComponent<Blackjack>();
    }

    void EnemyTryShot()
    {
        if(revolver.ShootQue == revolver.WhereBullet)
        {
            EnemyShoot();
        }else
        {
            EnemyMisFire();
        }
    }
    void EnemyShoot()
    {
        blackjack.PlayerLost();
    }
    void EnemyMisFire()
    {
        revolver.ShootQue++;
    }
}

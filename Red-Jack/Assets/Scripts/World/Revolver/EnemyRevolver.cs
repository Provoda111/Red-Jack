using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("GameOver");
    }
    void EnemyMisFire()
    {
        revolver.ShootQue++;
    }
}

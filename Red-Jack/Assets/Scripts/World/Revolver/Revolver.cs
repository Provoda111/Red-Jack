using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;

public class Revolver : MonoBehaviour
{
    private Blackjack blackjack;
    public int ShootQue = 1;
    public int WhereBullet;
    bool Shooting = false;
    bool MissFire = false;
    public void Start()
    {
        WhereBullet = Random.Range(1, 7);

        blackjack = GetComponent<Blackjack>();
    }

    public void TryToShot ()
    {
        if (ShootQue == WhereBullet)
        {
            Shoot();
        }
        else
        {
            MisFire();
        }
    }
    void Shoot()
    {
        Shooting = true;
        blackjack.EnemyLost();
        SceneManager.LoadScene("WinScene");
    }
    public void MisFire()
    {
        MissFire = true;
        ShootQue++;
        MissFire = false;
    }


    void EnemyTryShot()
    {
        if (ShootQue == WhereBullet)
        {
            EnemyShoot();
        }
        else
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
        ShootQue++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Revolver : MonoBehaviour
{
    private Blackjack blackjack;
    public int ShootQue = 1;
    public int WhereBullet;
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
        blackjack.EnemyLost();
        SceneManager.LoadScene("WinScene");
    }
    public void MisFire()
    {
        ShootQue++;
    }
}

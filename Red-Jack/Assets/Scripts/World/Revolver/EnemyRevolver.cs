using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyRevolver : MonoBehaviour
{
    private Revolver revolver;
    private Blackjack blackjack;

    public GameObject Revolver;
    void Start()
    {
        revolver = GetComponent<Revolver>();
        blackjack = GetComponent<Blackjack>();

        Revolver.SetActive(false);
    }

    public void RevActive()
    {
        Revolver.SetActive(true);
    }
    public void RevNotActive()
    {
        Revolver.SetActive(false);
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

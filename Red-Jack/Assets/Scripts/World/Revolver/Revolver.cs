using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;

public class Revolver : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private Blackjack blackjack;
    public int ShootQue = 1;
    public int WhereBullet;

    private Animator animator;
    public void Start()
    {
        WhereBullet = Random.Range(1, 7);

        blackjack = GetComponent<Blackjack>();

        animator = GetComponent<Animator>();
    }

    internal void TryToShot ()
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
    internal void Shoot()
    {
        RevolverAnimation("Shoot");
        blackjack.EnemyLost();
        SceneManager.LoadScene("WinScene");
    }
    public void MisFire()
    {
        RevolverAnimation("MisFire");
        ShootQue++;
        gameManager.ResetGame();
    }
    public void RevolverAnimation(string Trigger)
    {
            animator.SetTrigger(Trigger); 
    }

    internal void EnemyTryShot()
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
        RevolverAnimation("EnemyShoot");
        blackjack.PlayerLost();
        SceneManager.LoadScene("GameOver");
    }
    void EnemyMisFire()
    {
        RevolverAnimation("EnemyMis");
        ShootQue++;
        gameManager.ResetGame();
    }
}

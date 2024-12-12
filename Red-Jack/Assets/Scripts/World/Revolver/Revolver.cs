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
    void Shoot()
    {
        RevolverAnimation("Shoot");
        blackjack.EnemyLost();
    }
    public void MisFire()
    {
        RevolverAnimation("MisFire");
        ShootQue++;
        gameManager.ResetGame();
    }
    public void RevolverAnimation(string PlayerShoot)
    {
        if (animator != null)
        {
            animator.SetTrigger(PlayerShoot); 
        }
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
    }
    void EnemyMisFire()
    {
        RevolverAnimation("EnemyMis");
        ShootQue++;
        gameManager.ResetGame();
    }
}

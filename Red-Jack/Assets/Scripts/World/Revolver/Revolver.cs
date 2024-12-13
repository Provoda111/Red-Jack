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

    public GameObject PlayerControl;
    public GameObject Music;

    private Animator animator;
    public void Start()
    {
        Debug.Log("Shoot " + ShootQue);
        WhereBullet = Random.Range(1, 7);

        blackjack = GetComponent<Blackjack>();

        animator = GetComponent<Animator>();
    }

    internal void TryToShot ()
    {
        Music.SetActive(false);
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
        
        PlayerControl.SetActive(false);
        RevolverAnimation("Shoot");
        StartCoroutine(OverScreen("Player"));
    }
    public void MisFire()
    {
        RevolverAnimation("MisShoot");
        MisFireShared();
        
    }
    public void RevolverAnimation(string TriggerName)
    {
            animator.SetTrigger(TriggerName); 
    }

    internal void EnemyTryShot()
    {
        Music.SetActive(false);
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
        
        PlayerControl.SetActive(false);
        RevolverAnimation("EnemyShoot");
        StartCoroutine(OverScreen("Enemy"));

    }
    void EnemyMisFire()
    {
        RevolverAnimation("EnemyMis");
        MisFireShared();
    }

    void MisFireShared()
    {
        ShootQue++;
        Music.SetActive(true);
        StartCoroutine(OverScreen(""));
            gameManager.ResetGame();
    }
    IEnumerator OverScreen(string Shooter)
    {
        yield return new WaitForSeconds(4f);
        if(Shooter == "Player")
        {
            SceneManager.LoadScene("WinScene");
        }else if (Shooter == "Enemy")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}

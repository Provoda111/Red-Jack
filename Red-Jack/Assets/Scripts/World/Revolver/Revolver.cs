using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour
{
    int ShootQue = 1;
    int WhereBullet;
    private void Start()
    {
        WhereBullet = Random.Range(1, 7);
    }

    void TryToShot ()
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

    }
    void MisFire()
    {
        ShootQue++;
    }
}

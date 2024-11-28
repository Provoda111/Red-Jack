using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public bool Shoot = false;
    void Start()
    {
        //particleSystem.Stop();
    }


    void Update()
    {
        if (Input.GetKeyUp("a"))
        {
            Shoot = true;
        }
    }
    public void Shot()
    {
        
        //particleSystem.Play();
        //Shoot = false;  
    }


}

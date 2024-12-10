using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleSystem;
    void Start()
    {
        particleSystem.Stop();
    }


    void Update()
    {
        if (Input.GetKeyUp("a"))
        {
            Shot();
        }
    }
    public void Shot()
    {
        StartCoroutine(PlayAndWait()); 
    }

    private IEnumerator PlayAndWait()
    {
        particleSystem.Play();
        yield return new WaitForSeconds(1f);
        particleSystem.Stop();
    }


}

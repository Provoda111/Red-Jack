using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public new ParticleSystem particleSystem;

    public AudioSource audioSource; 
    public AudioClip audioClip;
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = audioClip;
    }

    public void PlaySound()
    {
        audioSource.Play(); 
    }

    void Update()
    {

    }
    public void Shot()
    {
        particleSystem.Play();
    }
}

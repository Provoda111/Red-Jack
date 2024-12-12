using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public new ParticleSystem particleSystem;

    public AudioSource audioSource; 
    public AudioClip ShootAudioClip;
    public AudioClip MissAudioClip;
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        
    }

    public void PlayShootSound()
    {
        audioSource.clip = ShootAudioClip;
        audioSource.Play(); 
    }

    void Update()
    {

    }
    public void Shot()
    {
        particleSystem.Play(); // Toimii vain yhden kerran
    }
    public void Miss()
    {
        audioSource.clip = MissAudioClip;
        audioSource.Play();
    }
}

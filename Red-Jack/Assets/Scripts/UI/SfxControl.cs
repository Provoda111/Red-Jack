using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxControl : MonoBehaviour
{
    private AudioSource buttonSfx;
    private void Start()
    {
        buttonSfx = GetComponent<AudioSource>();
    }
    public void UIclick()
    {
        buttonSfx.pitch = Random.Range(0.88f, 1.12f);
        buttonSfx.Play();
    }
}

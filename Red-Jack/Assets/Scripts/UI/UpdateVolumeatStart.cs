using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UpdateVolume : MonoBehaviour
{
    public GameObject AudioController;
    // Start is called before the first frame update
    void Start()
    {
        AudioController.GetComponent<AudioControl>().UpdateVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

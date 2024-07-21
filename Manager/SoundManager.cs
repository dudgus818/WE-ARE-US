using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource tutorialBgm;
    // Start is called before the first frame update
    void Start()
    {
        tutorialBgm.Play();
    }

    // Update is called once per frames
    void Update()
    {
        
    }
}

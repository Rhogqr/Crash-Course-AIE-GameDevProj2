using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AmbientSoundBehaviour : MonoBehaviour
{
    public AudioClip ambientNoise;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1/10000 chance every frame to play a swappable noise
        int audioChance = Random.Range(0, 10000);
        if (audioChance == 0)
        {
            audioSource.clip = ambientNoise;
            audioSource.Play();
        }
    }
}

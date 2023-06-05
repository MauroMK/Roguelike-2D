using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip deathClip;

    public AudioClip[] impactSounds;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayRandomImpactSound()
    {
        int soundSelected = Random.Range(0, impactSounds.Length);
        deathClip = impactSounds[soundSelected];
        audioSource.clip = deathClip;
        audioSource.Play();
    }
}

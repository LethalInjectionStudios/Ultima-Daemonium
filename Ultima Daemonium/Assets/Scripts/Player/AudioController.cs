using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    private AudioSource _audioSource;
    
    public AudioClip jump;
    public AudioClip takeDamage;
    public AudioClip death;
    public AudioClip attack;
    public AudioClip interact;

    private void Awake()
    {
        _audioSource = GetComponentInParent<AudioSource>();
    }

    public void PlayJump()
    {
        if (!jump)
        {
            return;
        }

        _audioSource.PlayOneShot(jump);
    }
}

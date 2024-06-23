using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    public AudioClip disparoJugadorClip;
    public AudioClip disparoEnemigoClip;
    public AudioClip explosionClip;
    public AudioClip destruccionNaveClip;
    public AudioClip muerteJugadorClip;

    private AudioSource audioSource;

    void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDisparoJugador()
    {
        audioSource.PlayOneShot(disparoJugadorClip);
    }

    public void PlayDisparoEnemigo()
    {
        audioSource.PlayOneShot(disparoEnemigoClip);
    }

    public void PlayExplosion()
    {
        audioSource.PlayOneShot(explosionClip);
    }

    public void PlayDestruccionNave()
    {
        audioSource.PlayOneShot(destruccionNaveClip);
    }

    public void PlayMuerteJugador()
    {
        audioSource.PlayOneShot(muerteJugadorClip);
    }
}


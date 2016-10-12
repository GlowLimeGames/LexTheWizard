using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Plays Sounds from clips passed into the Playsound method
/// </summary>
public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource efxSource;

    public static SoundManager instance = null;

    [Range(0.0f, 1.0f)]
    public float volume;

    void Awake()
    {
        //Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    public void PlaySingle(AudioClip clip)
    {
        efxSource.PlayOneShot(clip, volume);
    }

}

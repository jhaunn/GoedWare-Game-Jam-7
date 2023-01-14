using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource audioSrc;

    [SerializeField] private AudioClip[] sounds;
    public AudioClip[] Sounds { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Sounds = sounds;
    }

    public void PlayAudio(AudioClip sound)
    {
        audioSrc.PlayOneShot(sound);
    }
}

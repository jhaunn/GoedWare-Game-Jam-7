using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager instance;

    [SerializeField] private AudioSource audioSrc;

    public GameObject[] particles;
    public AudioClip[] sounds;

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

    public void PlaySound(AudioClip sound)
    {
        audioSrc.PlayOneShot(sound);
    }

    public void InvokeRestartGame(float time)
    {
        Invoke("RestartGame", time);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Restart game");
    }
}

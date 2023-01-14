using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager instance;

    [SerializeField] private GameObject[] particles;
    public GameObject[] Particles { get; set; }

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
        Particles = particles;
    }

    public void SetRestartGame(float time)
    {
        Invoke("RestartGame", time);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

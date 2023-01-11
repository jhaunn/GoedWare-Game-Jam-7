using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    [SerializeField] private GameObject[] enemies;

    [SerializeField] private Vector2 minArea;
    [SerializeField] private Vector2 maxArea;

    [SerializeField] private int maxEnemies;
    [HideInInspector] public int CurrentEnemies { get; set; }

    [SerializeField] private float spawnInterval;
    private float currentSpawnInterval;

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
        Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector2(Random.Range(minArea.x, maxArea.x), Random.Range(minArea.y, maxArea.y)), Quaternion.identity);

        CurrentEnemies++;
        currentSpawnInterval = spawnInterval;
    }

    private void Update()
    {
        currentSpawnInterval -= Time.deltaTime;

        if (currentSpawnInterval <= 0f && CurrentEnemies < maxEnemies)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector2(Random.Range(minArea.x, maxArea.x), Random.Range(minArea.y, maxArea.y)), Quaternion.identity);

            CurrentEnemies++;
            currentSpawnInterval = spawnInterval;
        }
    }
}

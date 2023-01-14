using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private EnemyScriptableObject enemy;

    private EnemyMovement enemyMovement;
    private EnemyShoot enemyShoot;

    public int Life { get; set; }
    public int Score { get; set; }

    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = enemy.color;

        enemyMovement = gameObject.AddComponent<EnemyMovement>();
        enemyShoot = gameObject.AddComponent<EnemyShoot>();
    }

    private void Start()
    {
        Life = enemy.life;
        Score = enemy.GetScore();

        enemyMovement.SetSpeed(enemy.moveSpeed, enemy.spinSpeed, enemy.moveInterval);
        enemyShoot.SetShootStats(enemy.shootForce, enemy.shootInterval, enemy.bullets);
    }

    private void Update()
    {
        if (Life <= 0)
        {
            EnemySpawner.instance.CurrentEnemies--;
            ScoreManager.instance.Score += Score;
            Instantiate(EffectsManager.instance.Particles[2], transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

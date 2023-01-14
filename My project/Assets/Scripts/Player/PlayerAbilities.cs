using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAbilities : MonoBehaviour
{
    private PlayerStats playerStats;
    private PlayerShoot playerShoot;

    [SerializeField] private TextMeshProUGUI qText;
    [SerializeField] private TextMeshProUGUI eText;
    [SerializeField] private TextMeshProUGUI rText;

    [SerializeField] private float qTimer;
    [SerializeField] private float eTimer;
    [SerializeField] private float rTimer;
    private float currentQTimer;
    private float currentETimer;
    private float currentRTimer;

    [SerializeField] private float qShootInterval;
    [SerializeField] private float rRadius;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        playerShoot = GetComponent<PlayerShoot>();
    }

    private void Start()
    {
        currentQTimer = qTimer;
        currentETimer = eTimer;
        currentRTimer = rTimer;
    }

    private void Update()
    {
        currentQTimer -= Time.deltaTime;
        currentETimer -= Time.deltaTime;
        currentRTimer -= Time.deltaTime;

        UpdateAbilitiesText();

        AbilitiesInput();
    }

    private void UpdateAbilitiesText()
    {
        qText.text = $"Q-Rapid\n{currentQTimer.ToString("0.0")}";
        eText.text = $"E-Heal\n{currentETimer.ToString("0.0")}";
        rText.text = $"R-Instakill\n{currentRTimer.ToString("0.0")}";


        if (currentQTimer <= 0f)
        {
            qText.text = $"Q-Rapid\nReady";
        }

        if (currentETimer <= 0f)
        {
            eText.text = $"E-Heal\nReady";
        }

        if (currentRTimer <= 0f)
        {
            rText.text = $"R-Instakill\nReady";
        }
    }

    private void AbilitiesInput()
    {
        if (Input.GetKeyDown(KeyCode.Q) && currentQTimer <= 0f)
        {
            currentQTimer = qTimer;

            playerShoot.SetShootStats(qShootInterval);
            Invoke("ResetQ", 2f);
        }

        if (Input.GetKeyDown(KeyCode.E) && currentETimer <= 0f)
        {
            currentETimer = eTimer;

            playerStats.Health++;
        }

        if (Input.GetKeyDown(KeyCode.R) && currentRTimer <= 0f)
        {
            currentRTimer = rTimer;

            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, rRadius);

            foreach (Collider2D enemy in enemies)
            {
                if (enemy.GetComponent<EnemyStats>())
                {
                    enemy.GetComponent<EnemyStats>().Life = 0;
                }
            }
        }
    }

    private void ResetQ()
    {
        playerShoot.SetShootStats(playerStats.ShootInterval);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, rRadius);
    }
}

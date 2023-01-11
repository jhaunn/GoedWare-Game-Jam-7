using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private PlayerScriptableObject player;

    private PlayerMovement playerMovement;
    private PlayerShoot playerShoot;
    public int Health { get; set; }
    private int initialHealth;
    [SerializeField] private TextMeshProUGUI healthText;
    private float currentRegenInterval;

    private void Awake()
    {
        playerMovement = gameObject.AddComponent<PlayerMovement>();
        playerShoot = gameObject.AddComponent<PlayerShoot>();
    }

    private void Start()
    {
        Health = player.health;
        initialHealth = Health;
        currentRegenInterval = player.healthRegen;

        playerMovement.SetMovement(player.moveSpeed);
        playerShoot.SetShootStats(player.shootInterval, player.shootForce, player.bullet);
    }

    private void Update()
    {
        healthText.text = Health.ToString();

        if (Health <= 0)
        {
            EffectsManager.instance.InvokeRestartGame(5f);
            Destroy(gameObject);
        }

        if (Health < initialHealth)
        {
            RegenHealth();
        }

        
    }

    private void RegenHealth()
    {
        currentRegenInterval -= Time.deltaTime;

        if (currentRegenInterval <= 0f)
        {
            Health++;

            currentRegenInterval = player.healthRegen;
        }
    }
}

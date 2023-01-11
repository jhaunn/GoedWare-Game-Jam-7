using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool FromPlayer { get; set; }

    public void DestroyBullet(float value)
    {
        Destroy(gameObject, value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (FromPlayer)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Instantiate(EffectsManager.instance.particles[0], transform.position, Quaternion.identity);
                EffectsManager.instance.PlaySound(EffectsManager.instance.sounds[1]);

                collision.gameObject.GetComponent<EnemyStats>().Life--;
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Instantiate(EffectsManager.instance.particles[0], transform.position, Quaternion.identity);
                EffectsManager.instance.PlaySound(EffectsManager.instance.sounds[1]);

                collision.gameObject.GetComponent<PlayerStats>().Health--;
                Destroy(gameObject);
            }
        }

    }
}

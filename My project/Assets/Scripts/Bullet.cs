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
                collision.gameObject.GetComponent<EnemyStats>().Life--;
                Destroy(gameObject);
                Instantiate(EffectsManager.instance.Particles[1], transform.position, transform.rotation);
                SoundManager.instance.PlayAudio(SoundManager.instance.Sounds[2]);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerStats>().Health--;
                Destroy(gameObject);
                Instantiate(EffectsManager.instance.Particles[1], transform.position, transform.rotation);
                SoundManager.instance.PlayAudio(SoundManager.instance.Sounds[2]);
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private List<Transform> shootPoints = new List<Transform>();
    private GameObject[] bullets;

    private float shootInterval;
    private float currentShootInterval;
    private float shootForce;

    private void Awake()
    {
        foreach (Transform child in gameObject.transform) 
        {
            if (child.CompareTag("ShootPoint"))
            {
                shootPoints.Add(child);
            }
        }
    }

    private void Start()
    {
        currentShootInterval = shootInterval;
    }

    private void Update()
    {
        currentShootInterval -= Time.deltaTime;

        if (currentShootInterval <= 0f)
        {
            currentShootInterval = shootInterval;

            foreach (Transform shootPoint in shootPoints)
            {
                GameObject bullet = Instantiate(bullets[0], shootPoint.position, shootPoint.rotation);

                bullet.GetComponent<Rigidbody2D>().AddForce(shootPoint.transform.up * shootForce, ForceMode2D.Impulse);
            }
        }
    }

    public void SetShootStats(float shootForce, float shootInterval, GameObject[] bullets)
    {
        this.shootForce = shootForce;
        this.shootInterval = shootInterval;
        this.bullets = bullets;
    }
}

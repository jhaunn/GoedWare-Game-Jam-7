using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private List<Transform> shootPoints = new List<Transform>();
    private GameObject bullet;

    private float shootInterval;
    private float currentShootInterval;
    private float shootForce;
    private float bulletLife;

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
        bulletLife = 2f;
    }
    private void Update()
    {
        currentShootInterval -= Time.deltaTime;

        if (currentShootInterval <= 0f)
        {
            currentShootInterval = shootInterval;
            
            GameObject cur = Instantiate(bullet, shootPoints[0].position, shootPoints[0].rotation);

            cur.GetComponent<Bullet>().FromPlayer = true;
            cur.GetComponent<Rigidbody2D>().AddForce(shootPoints[0].up * shootForce, ForceMode2D.Impulse);
            cur.GetComponent<Bullet>().DestroyBullet(bulletLife);
        }
    }

    public void SetShootStats(float shootInterval, float shootForce, GameObject bullet)
    {
        this.shootInterval = shootInterval;
        this.shootForce = shootForce;
        this.bullet = bullet;
    }
}

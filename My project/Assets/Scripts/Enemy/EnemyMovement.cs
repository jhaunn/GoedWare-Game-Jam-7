using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float moveSpeed;
    private float spinSpeed;
    private Vector2 movement;

    [SerializeField] private float moveInterval;
    private float currentMoveInterval;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        UpdateMovement();
    }

    private void Update()
    {
        currentMoveInterval -= Time.deltaTime;

        if (currentMoveInterval <= 0f)
        {
            UpdateMovement();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        transform.Rotate(Vector3.forward * spinSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Wall"))
        {
            UpdateMovement();
        }
    }

    public void SetSpeed(float moveSpeed, float spinSpeed, float moveInterval)
    {
        this.moveSpeed = moveSpeed;
        this.spinSpeed = spinSpeed;
        this.moveInterval = moveInterval;
    }

    private void UpdateMovement()
    {
        movement.x = Random.Range(-1, 2);
        movement.y = Random.Range(-1, 2);

        currentMoveInterval = moveInterval;
    }
}

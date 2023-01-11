using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera cam;

    [SerializeField] private float moveSpeed;

    private Vector2 movement;
    private Vector2 mousePos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 look = mousePos - rb.position;
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void SetMovement(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }
}

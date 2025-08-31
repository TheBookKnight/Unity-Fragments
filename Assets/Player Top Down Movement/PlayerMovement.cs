using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 moveInput;
    public float movementSpeed = 3.0f;
    public float rotationSpeed;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the user's vertical input ( Up / Down arrow keys or W / S keys)
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        if (moveInput.sqrMagnitude > 0.01f) // Only rotate if moving
        {
            // Calculate the angle in degrees that the character will face based on movement
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90); // -90 if sprite faces up by default
        }
    }

    void FixedUpdate()
    {
        // Move the Rigidbody2D
        rb.MovePosition(rb.position + moveInput.normalized * movementSpeed * Time.fixedDeltaTime);
    }
}

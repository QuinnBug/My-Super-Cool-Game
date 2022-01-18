using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public float turnSpeed;
    private Vector2 moveDirection;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInputs();

        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(new Vector2(moveDirection.x, moveDirection.y) * acceleration * Time.deltaTime);
        }

        if (moveDirection != Vector2.zero)
        {
            Vector3 newDirection = Vector3.Lerp(transform.up, rb.velocity, turnSpeed * Time.deltaTime);
            float angle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }

    private void MovementInputs()
    {
        moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x += -1;
        }

        if (moveDirection.magnitude >= 1)
        {
            moveDirection.Normalize();
        }
    }

    public bool IsMoving()
    {
        return moveDirection != Vector2.zero;
    }
}
